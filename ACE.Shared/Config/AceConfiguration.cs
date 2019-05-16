using ACD.Shared.Enumeration;
using ACE.Shared.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace ACD.Shared.Config
{
    public class AceConfiguration: IAceConfiguration
    {


        public AcdEnvironment HostingEnvironment
        {
            get
            {
                //var environmentNameStr = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                //if (string.IsNullOrWhiteSpace(environmentNameStr)) throw new Exception($"The environment [ASPNETCORE_ENVIRONMENT] is not set");

                //if (!Enum.TryParse(environmentNameStr, out AcdEnvironment environmentName))
                //{
                //    throw new Exception($"The environment name {environmentNameStr} is invalid");
                //}

                //return environmentName;
                return AcdEnvironment.Development;
            }
        }



        /// <summary>
        /// http://csharpindepth.com/Articles/General/Singleton.aspx
        /// </summary>
        private static readonly Lazy<AceConfiguration> Lazy = new Lazy<AceConfiguration>(() => new AceConfiguration());

        public static AceConfiguration InstanceFactory => Lazy.Value;

        public IConfiguration Configuration { get; private set; }

        public string this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private AceConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{HostingEnvironment}.json", optional: true, reloadOnChange: true)
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                     {"TestHost:UseWebpackDevMiddleware", "false"}
                })
                .Build();
        }

        public string GetConnectionString(string name)
        {
            var connectionString = Configuration.GetConnectionString(name);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string missing for {name}");
            }
            return connectionString;
        }

        public IConfigurationSection GetSection(string key)
        {
            return Configuration.GetSection(key);
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return Configuration.GetChildren();
        }

        public IChangeToken GetReloadToken()
        {
            return Configuration.GetReloadToken();
        }

        //private string LogFolderName
        //{
        //    get
        //    {
        //        var logFolderPath = Environment.GetEnvironmentVariable("ISG_LOG_FOLDER_PATH");

        //        if (string.IsNullOrWhiteSpace(logFolderPath)) throw new Exception($"The environmentVariable [ISG_LOG_FOLDER_PATH] is not set");

        //        return logFolderPath;
        //    }
        //}

        //private static string buidId = string.Empty;
        //public static string BuildId
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(buidId))
        //        {
        //            buidId = $"{DateTime.UtcNow.ToString("yyyyMMdd")}.1";
        //        }
        //        return buidId;
        //    }
        //}

        //public ILogger CreateLog(ILoggerFactory loggerFactory, string logName)
        //{
        //    var logPath = CreateLoggingFullPath(logName);
        //    var logLevel = Configuration.GetValue<LogLevel>("Logging:LogLevel:Default");
        //    loggerFactory.AddFile(logPath, logLevel);
        //    var logger = loggerFactory.CreateLogger(GetType());
        //    logger.LogInformation($"LogLevel:{logLevel}");
        //    return logger;
        //}

        //private string CreateLoggingFullPath(string targetName)
        //{
        //    return Path.Combine(LogFolderName, $"{BuildId}/{targetName}-{DateTime.UtcNow:yyyy-MM-dd HH.mm.ss.ffff}.txt");
        //}


    }
}
