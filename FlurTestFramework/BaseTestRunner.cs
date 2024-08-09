using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;

namespace FlurTestFramework
{
    public class BaseTestRunner
    {
        public string Baseurl => _configuration["Configurations:BaseUrl"];

        private readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        public BaseTestRunner()
        {

        }
        [OneTimeSetUp]
        public void Initialize()
        {

            FlurlHttp.ConfigureClientForUrl(Baseurl)
                .AllowHttpStatus(404,400,500)
                .WithSettings(settings =>
                {
                    settings.JsonSerializer = new DefaultJsonSerializer(JsonSerializerOptions.Default);
                })
                .ConfigureInnerHandler(configure =>
                {
                    configure.ServerCertificateCustomValidationCallback += OnConfigureServerCertificateCustomValidationCallback;
                });
        }

        public void Setup()
        {
            
        }

        private bool OnConfigureServerCertificateCustomValidationCallback(HttpRequestMessage sender, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            /*if (sslPolicyErrors == SslPolicyErrors.None) return true;

            if (certificate is { Thumbprint: "YOUR_CERT_THUMBPRINT" }) return true;

            return false;*/
            return true;
        }


    }
}