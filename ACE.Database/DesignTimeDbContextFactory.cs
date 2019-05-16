using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace ACE.Database
{
    /// <summary>
    /// Creates database when performing migrations.
    /// </summary>
    public class DesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
        where TContext : DbContext
    {
        public TContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.Development.json")
                 .AddEnvironmentVariables().Build();
            var connectionString = configuration.GetConnectionString(typeof(TContext).Name);
            return (TContext)Activator.CreateInstance(typeof(TContext), new DbContextOptionsBuilder<TContext>().UseSqlServer(connectionString).Options);
        }
    }
}
