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
        public virtual DbSet<SessionActivity> SessionActivities { get; set; }
        public virtual DbSet<ServiceAuditTrail> ServiceAuditTrails { get; set; }
        public virtual DbSet<JournalEntry> JournalEntries { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserHasRoles> UserHasRoles { get; set; }
    }
}
