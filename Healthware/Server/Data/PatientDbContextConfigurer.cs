using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Healthware.Server.Data
{
    public static class PatientDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PatientDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PatientDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
