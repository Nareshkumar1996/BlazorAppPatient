using Healthware.Assist.Core.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Healthware.Server.Data
{
  
    public  class PatientPortalEntityFrameworkModule 
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        private readonly IConfigurationRoot _appConfiguration;
        private readonly PatientDbContext _patientPortalDbContext;
        //     protected internal IIocManager IocManager { get; internal set; }

        public PatientPortalEntityFrameworkModule(IConfigurationRoot appConfiguration, PatientDbContext patientPortalDbContext)
        {
            this._appConfiguration = appConfiguration;
            this._patientPortalDbContext = patientPortalDbContext;
        }
        
        public  void Initialize()
        { 
            var builder = new DbContextOptionsBuilder<PatientDbContext>();
            PatientDbContextConfigurer.Configure(builder, _appConfiguration.GetConnectionString(Portal.ConnectionStringName));
            //_patientPortalDbContext.Database.MigrateAsync();
        }
    }
}
