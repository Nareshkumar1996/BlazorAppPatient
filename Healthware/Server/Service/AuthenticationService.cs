using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Healthware.Server.Repositories;
using Healthware.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Healthware.Server.Service
{
    public interface IAuthenticationService
    {
        Task<ActionResult<LoginResponseDto>> Authenticate(AuthenticateDto authenticateDto);
    }
    public class AuthenticationService :IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository userRepository,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<ActionResult<LoginResponseDto>> Authenticate(AuthenticateDto authenticateDto)
        {
            if (await _userRepository.DoesUserExists(authenticateDto.UserName))
            {
                var user = await _userRepository.GetUserByEmailAddress(authenticateDto.UserName);
                if (authenticateDto.Password.Equals(user.Password))
                {
                    var tokenStr = GenerateJSONWebToken(user);
                    return new LoginResponseDto() {Token = tokenStr};
                }

                return new LoginResponseDto() { Token = null };
            }

            return new LoginResponseDto() { Token = null };
        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Email, user.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );
            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }
    }
}
