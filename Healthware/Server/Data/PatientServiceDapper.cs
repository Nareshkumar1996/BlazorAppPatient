using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Healthware.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Healthware.Server.Data
{
    public class PatientServiceDapper
    {
        private string connectionString = "";

        public PatientServiceDapper()
        {
            connectionString =
                @"Server=ZS-DSK-0003\SQLEXPRESS; Database=WeatherForecast; User Id=sa; Password=Password@1; Integrated Security=False;";
        }

        public IDbConnection Connection {
            get {
                return new SqlConnection(connectionString);
            }
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
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
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            string sQuery = @"SELECT * FROM PATIENT WHERE PatientId=@Id";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    return dbConnection.Query<Patient>(sQuery, new {Id = id}).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        public void CreatePatient(Patient patient)
        {
            string sQuery = @"INSERT INTO PATIENT (PatientName, Speciality, Location) VALUES (@PatientName, @Speciality, @Location)";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, patient);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task UpdatePatient(Patient patient)
        {
            string sQuery = @"UPDATE PATIENT SET PatientName=@PatientName,Speciality=@Speciality,Location=@Location WHERE PatientId=@PatientId";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, patient);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        public async Task DeletePatientById(int id)
        {
            string sQuery = @"DELETE FROM PATIENT WHERE PatientId=@Id";
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new{Id=id});
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
