using ACD.Shared.Config;
using ACE.Database;
using ACE.Service.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ace.Test.Shared
{
    public class TestBase
    {
        protected enum AuthenticationType
        {
            None,
            Anonymous,
            CurrentUser,
            OtherUser
        }
        protected static AceConfiguration AcdConfigurationTest { get; set; } = AceConfiguration.InstanceFactory;

        protected IServiceProvider aceProvider;

        protected IServiceCollection Services;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            aceProvider = BuildServices();
            //CleanDb(aceProvider);
        }

        public IServiceProvider BuildServices()
        {
            Services = Services = new ServiceCollection();
            Services.AddAceExecutionServices();
            aceProvider = Services.BuildServiceProvider();
            return aceProvider;
        }

        public static void CleanDb(IServiceProvider provider)
        {
            DeleteDatabases(provider);
        }

        private static void DeleteDatabases(IServiceProvider provider)
        {
            try
            {
                var dbContext = provider.GetService<AceDbContext>();
                if (dbContext != null)
                {
                    dbContext.Database.EnsureDeleted();
                }
                else
                {
                    var errorMsg = $"The TContext is null! Ensure that DbContext and connectionString is defined correctly. TContext name is {dbContext}";
                    throw new Exception(errorMsg);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
