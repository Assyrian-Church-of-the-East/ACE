using Ace.Test.Shared;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Net;
using ACD.Shared.Enumeration;
using ACE.Shared.Extensions;
using IntelliTect.AspNetCore.TestHost.WindowsAuth;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using ACE.WebApi;

namespace ACE.Full.integration.Tests
{
    public class IntegrationTestBase : TestBase
    {

        private HttpClient _importWebClient;
        private HttpClient _adminWebClient;
        private TestServer _adminWebApiServer;
        private TestServer _importWebApiServer;

        private static readonly string _AceWebApiUrl = AcdConfigurationTest.GetValue<string>("AceWebApiUrl");

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            _importWebApiServer = CreateHttpServer<Startup>(_AceWebApiUrl, useAuthentication: true);
            _importWebClient = CreateHttpClient(AuthenticationType.CurrentUser, _AceWebApiUrl, _importWebApiServer);
        }

        protected TestServer CreateHttpServer<TStartup>(string baseUrl, bool useAuthentication = false)
            where TStartup : class
        {

            IWebHostBuilder builder = GetWebHostBuilder<TStartup>();

            var server = new TestServer(builder)
            {
                BaseAddress = new Uri(baseUrl)
            };

            return server;
        }

        private static IWebHostBuilder GetWebHostBuilder<TStartup>()
            where TStartup : class
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<TStartup>()
                .ConfigureKestrel((context, options) =>
                {
                    // Set properties and call methods on options
                })
                .UseConfiguration(AcdConfigurationTest)
                .UseEnvironment(AcdConfigurationTest.HostingEnvironment.ToString());
        }

        protected HttpClient CreateHttpClient(AuthenticationType authentication, string baseUrl, TestServer server = null, NetworkCredential credential = null)
        {
            HttpClient client;
            HttpClientHandler handler;

            var hostingEnvironment = AcdConfigurationTest.HostingEnvironment;

            if (hostingEnvironment.In(AcdEnvironment.Development, AcdEnvironment.Build) && server == null)
            {
                throw new ArgumentException($"Cannot create client unless server is already created when running in environment {hostingEnvironment}.", "server");
            }

            switch (authentication)
            {
                case AuthenticationType.Anonymous when hostingEnvironment.In(AcdEnvironment.Development, AcdEnvironment.Build):
                    client = server.ClientForAnonymous();
                    break;
                case AuthenticationType.Anonymous when hostingEnvironment.In(AcdEnvironment.Test, AcdEnvironment.Staging):
                    client = new HttpClient(new HttpClientHandler(), true);
                    break;
                case AuthenticationType.CurrentUser when hostingEnvironment.In(AcdEnvironment.Development, AcdEnvironment.Build):
                    client = server.ClientForCurrentUser();
                    break;
                case AuthenticationType.CurrentUser when hostingEnvironment.In(AcdEnvironment.Test, AcdEnvironment.Staging):
                    handler = new HttpClientHandler()
                    {
                        UseDefaultCredentials = true
                    };
                    client = new HttpClient(handler, true);
                    break;
                case AuthenticationType.OtherUser when hostingEnvironment.In(AcdEnvironment.Development, AcdEnvironment.Build):
                    client = server.ClientForUser(credential);
                    break;
                case AuthenticationType.OtherUser when hostingEnvironment.In(AcdEnvironment.Test, AcdEnvironment.Staging):
                    // TODO Task 7160: Login with supplied credential and set headers accordingly
                    handler = new HttpClientHandler()
                    {
                        UseDefaultCredentials = true
                    };
                    client = new HttpClient(handler, true);
                    break;
                default:
                    throw new NotImplementedException($"IsgConfiguration.HostingEnvironment {hostingEnvironment} with AuthenticationType {authentication} is not supported.");
            }

            client.BaseAddress = new Uri(baseUrl);
            return client;
        }

        protected HttpClient ConfigureHttpClient(HttpClient client, AuthenticationType authentication, TestServer server = null, NetworkCredential credential = null)
        {
            switch (AcdConfigurationTest.HostingEnvironment)
            {
                case AcdEnvironment.Development:
                case AcdEnvironment.Build:
                    var baseAddress = server?.BaseAddress.ToString() ?? client.BaseAddress.ToString();
                    client?.Dispose();
                    client = CreateHttpClient(authentication, baseAddress, server);
                    break;
                case AcdEnvironment.Test:
                case AcdEnvironment.Staging:
                    // TODO: Task 7160: Reconfigure client. Might need to recreate it ...
                    if (client == null)
                    {
                        throw new ArgumentException($"Cannot configure client if it is null.", "client");
                    }
                    client.BaseAddress = server.BaseAddress;
                    //client.Dispose(); // To free unmanaged resources when not running in dev or build
                    //client.Server?.Dispose(); // Should be null, but just in case
                    //client = CreateHttpClient(hostingEnvironment, authentication);
                    break;
                default:
                    throw new NotImplementedException($"IsgConfiguration.HostingEnvironment {AcdConfigurationTest.HostingEnvironment} with AuthenticationType {authentication} is not supported.");
            }

            return client;
        }


        protected HttpResponseMessage PostHttpRequest(string uri, object obj = null)
        {
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri = new Uri(uri, UriKind.RelativeOrAbsolute);
                request.Method = new HttpMethod("POST");
                if (obj != null)
                {
                    var serializeObject = JsonConvert.SerializeObject(obj);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(serializeObject);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    request.Content = byteContent;
                }

                var res = _adminWebClient.SendAsync(request).GetAwaiter().GetResult();
                return res;
            }
        }
        //protected void Upload(SourceType sourceType, string path)
        //{
        //    var fileName = Path.GetFileName(path);
        //    var stream = File.OpenRead(path);
        //    var system = sourceType.GetSourceSystemType();

        //    using (var request = new HttpRequestMessage())
        //    {
        //        request.RequestUri = new Uri($"{_isgImportWebApiBaseUrl}api/{system}/{sourceType}", UriKind.RelativeOrAbsolute);
        //        request.Content = new MultipartFormDataContent
        //            {
        //                { new StreamContent(stream), "file", fileName }
        //            };
        //        request.Method = new HttpMethod("POST");
        //        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        var response = _importWebClient.SendAsync(request).GetAwaiter().GetResult();
        //        response.EnsureSuccessStatusCode();
        //        var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        //        Logger.LogDebug($"ResponseData: {responseData}");
        //    }
        //}

        // TODO: To be used in Task 7160
        //protected WindowsIdentity LogInAs(NetworkCredential credential)
        //{
        //    // Inspired by https://blogs.msdn.microsoft.com/jimmytr/2007/04/14/writing-test-code-with-impersonation/

        //    var currentIdentity = WindowsIdentity.GetCurrent();
        //    string[] nameParts = currentIdentity.Name.Split('\\');

        //    if (string.Equals(nameParts[0], credential.Domain, StringComparison.InvariantCultureIgnoreCase)
        //        && string.Equals(nameParts[1], credential.UserName, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        return currentIdentity;
        //    }

        //    // Current identity isn't the droid that we were looking for. Get rid of it.
        //    currentIdentity.Dispose();

        //    if (NativeMethods.LogonUser(
        //        credential.UserName, credential.Domain, credential.Password,
        //        2 /*LOGON32_LOGON_INTERACTIVE*/, // Required to get a "primary token".
        //        0 /*LOGON32_PROVIDER_DEFAULT*/,
        //        out IntPtr hToken))
        //    {
        //        var identity = new WindowsIdentity(hToken);

        //        // No longer needed - WindowsIdentity duplicates this handle in its ctor.
        //        NativeMethods.CloseHandle(hToken);

        //        // This identity needs to be disposed of when the request is done.
        //        return identity;
        //    }

        //    throw new Win32Exception(Marshal.GetLastWin32Error(), $"Unable to log in as user {credential.UserName}");
        //}
    }
}
