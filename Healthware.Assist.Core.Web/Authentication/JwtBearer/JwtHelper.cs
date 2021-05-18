using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using Healthware.Assist.Core.Security;
using Healthware.Shared;

namespace Healthware.Assist.Core.Web.Authentication.JwtBearer
{
    
    public interface IJwtHelper
    {
        public string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null);
        public List<Claim> CreateJwtClaims(ClaimsIdentity identity, string role);
        public string GetEncryptedAccessToken(string accessToken);

    }
    public class JwtHelper : IJwtHelper
    {
        private readonly TokenAuthConfiguration _tokenAuthConfiguration;
        
        public JwtHelper(TokenAuthConfiguration tokenAuthConfiguration)
        {
          _tokenAuthConfiguration = tokenAuthConfiguration;
        }
        
        public string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            var now = DateTime.UtcNow;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenAuthConfiguration.Issuer,
                audience: _tokenAuthConfiguration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration ?? _tokenAuthConfiguration.Expiration),
                signingCredentials: _tokenAuthConfiguration.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
        
        public  List<Claim> CreateJwtClaims(ClaimsIdentity identity, string role)
        {
            var claims = identity.Claims.ToList();
            var nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(new[]
            {   new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            });

            return claims;
        }
        
        public string GetEncryptedAccessToken(string accessToken)
        {
            return SimpleStringCipher.Instance.Encrypt(accessToken, "gsKxGZ012HLL3MI5");
        }

        private bool verifyExpiredToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenValues = handler.ReadToken(token) as JwtSecurityToken;
            string tokenlifeTime = new JwtSecurityTokenHandler().ReadToken(token).ValidTo.ToString();
            DateTime tokenValidTime = DateTime.Parse(tokenlifeTime);
            if (DateTime.Now > tokenValidTime)
            {
                return true;
            }
            return false;
        } 
    }
}