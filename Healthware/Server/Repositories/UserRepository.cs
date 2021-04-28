using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Healthware.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Healthware.Server.Repositories
{
    public interface IUserRepository : IUserStore<User>, IUserPasswordStore<User>
    {
        Task<User> GetUserByEmailAddress(string userName);
        Task<bool> DoesUserExists(string userName);
    }
    public class UserRepository: IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection Connection {
            get {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<User> GetUserByEmailAddress(string userName)
        {
            string sQuery = @"SELECT * FROM USERS WHERE EmailAddress=@userName";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    return dbConnection.Query<User>(sQuery, new { UserName = userName }).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task<bool> DoesUserExists(string userName)
        {
            string sQuery = @"SELECT * FROM USERS WHERE EmailAddress=@userName";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    var user = dbConnection.Query<User>(sQuery, new { UserName = userName }).FirstOrDefault();
                    if (user != null)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
