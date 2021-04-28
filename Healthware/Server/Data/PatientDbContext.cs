using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Healthware.Shared;
using Microsoft.EntityFrameworkCore;

namespace Healthware.Server.Data
{
    public class PatientDbContext: DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
