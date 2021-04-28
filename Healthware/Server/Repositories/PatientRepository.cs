using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Healthware.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Healthware.Server.Repositories
{
    public interface IPatientRepository: IGenericRepository<Patient>
    {
       
    }
    public class PatientRepository: IPatientRepository
    {
        private readonly IConfiguration _configuration;

        public PatientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection Connection {
            get {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
        public async Task<IEnumerable<Patient>> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    return await dbConnection.QueryAsync<Patient>("SELECT * FROM PATIENT");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task<Patient> GetById(int id)
        {
            string sQuery = @"SELECT * FROM PATIENT WHERE PatientId=@Id";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    return dbConnection.Query<Patient>(sQuery, new { Id = id }).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task Add<T>(T entity)
        {
            string sQuery = @"INSERT INTO PATIENT (PatientName, Speciality, Location) VALUES (@PatientName, @Speciality, @Location)";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, entity);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task Update<T>(T entity)
        {
            string sQuery = @"UPDATE PATIENT SET PatientName=@PatientName,Speciality=@Speciality,Location=@Location WHERE PatientId=@PatientId";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, entity);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task Delete(int id)
        {
            string sQuery = @"DELETE FROM PATIENT WHERE PatientId=@Id";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { Id = id });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
