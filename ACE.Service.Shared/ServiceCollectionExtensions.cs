using ACD.Shared.Config;
using ACE.Database;
using ACE.Repositories;
using ACE.Repositories.Interfaces;
using ACE.Service.Managers;
using ACE.Service.Managers.Interfaces;
using ACE.Service.Mapping;
using ACE.Shared.Config;
using ACE.Shared.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ACE.Service.Shared
{
    public static class ServiceCollectionExtensions
    {
        #region shared
        public static ServiceProvider AddSharedServices(this IServiceCollection services)
        {
            if (!services.Any(x => x.ServiceType == typeof(IAceConfiguration)))// to avoid adding configuration multiple times
            {
                services.AddSingleton<IAceConfiguration, AceConfiguration>();
            }
            return services.BuildServiceProvider();

        }
        #endregion shared
        public static void AddAceExecutionServices(this IServiceCollection services)
        {
            services.AddSharedServices();
            string aceConnection = AceConfiguration.InstanceFactory.GetConnectionString("AceDbContext");
            services
                .AddEntityFrameworkSqlServer()
                    .AddDbContext<AceDbContext>(options =>
                    {
                        options.UseSqlServer(aceConnection);
#if DEBUG
                        options.EnableSensitiveDataLogging(true);
#endif
                    })
                .AddScoped<IRepositoryFactory, RepositoryFactory>(provider => new RepositoryFactory(provider))
                .AddScoped<IDistrictRepository, DistrictRepository>()
                .AddScoped<IMemberRepository, MemberRepository>()
                .AddScoped<IFamilyRepository, FamilyRepository>()
                .AddScoped<IContributionRepository, ContributionRepository>()
                .AddScoped<IContributionTypeRepository, ContributionTypeRepository>()
                .AddScoped<IFamilyManager, FamilyManager>()
                .AddScoped<IMemberManager, MemberManager>()
                .AddScoped<IDataService, DataService>()
                ;
            //services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true))
        }
    }

}
