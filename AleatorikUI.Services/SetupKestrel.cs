using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;

namespace AleatorikUI.Services
{
	public class SetupKestrel
	{
        public static void Configure(IWebHostBuilder webBuilder, IConfiguration configuration)
        {
            var restProtocol = configuration["Kestrel:rest:HttpProtocol"];
            var sslProtocol = configuration["Kestrel:SslProtocol"];

            int.TryParse(configuration["Kestrel:rest:ApplicationPort"], out var restPort);
            bool.TryParse(configuration["Kestrel:UseHttps"], out var useHttps);
            long.TryParse(configuration["Kestrel:MaxConcurrentConnections"], out var maxConcurrentConnections);
            long.TryParse(configuration["Kestrel:MaxConcurrentUpgradedConnections"], out var maxConcurrentUpgradedConnections);
            long.TryParse(configuration["Kestrel:KeepAliveTimeout"], out var keepAliveTimeout);
            long.TryParse(configuration["Kestrel:MaxRequestBodySize"], out var maxRequestBodySize);
            bool.TryParse(configuration["Kestrel:AllowSynchronousIO"], out var allowSynchronousIO);

            webBuilder.UseKestrel(options =>
            {
                options.AddServerHeader = false;
                void listen(int applicationPort, string httpProtocol)
                {
                    options.Listen(IPAddress.Any, applicationPort, listenOptions =>
                    {
                        listenOptions.Protocols = GetHttProtocol(httpProtocol);

                        options.Limits.MaxConcurrentConnections = maxConcurrentConnections;
                        options.Limits.MaxConcurrentUpgradedConnections = maxConcurrentUpgradedConnections;
                        options.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(keepAliveTimeout);

                        if (maxRequestBodySize >= 1 && maxRequestBodySize <= 28.6)
                        {
                            options.Limits.MaxRequestBodySize = maxRequestBodySize * 1048576;
                        }

                        options.AllowSynchronousIO = allowSynchronousIO;


                        if (!useHttps) return;

                        var httpsOptions = new HttpsConnectionAdapterOptions();
                        var kestrelCertificate = configuration["mozart:Kestrel:ServerCertificate:Certificate"];
                        bool.TryParse(configuration["mozart:Kestrel:ClientCertificate:RequireClientCertificate"], out var requireClientCertificate);
                        bool.TryParse(configuration["mozart:Kestrel:ClientCertificate:CheckCertificateRevocation"], out var checkCertificateRevocation);

                        httpsOptions.SslProtocols = GetTlsProtocol(sslProtocol);

                        httpsOptions.ClientCertificateMode = requireClientCertificate ? ClientCertificateMode.RequireCertificate : ClientCertificateMode.NoCertificate;
                        httpsOptions.CheckCertificateRevocation = checkCertificateRevocation;

                        if (!string.IsNullOrEmpty(kestrelCertificate))
                        {
                            var kestrelCertificatePassword = configuration["mozart:Kestrel:ServerCertificate:CertificatePassword"];
                            httpsOptions.ServerCertificate = LoadServerCertificate(kestrelCertificate, kestrelCertificatePassword);
                        }

                        listenOptions.UseHttps(httpsOptions);
                    });
                }
                listen(restPort, restProtocol);
            });
        }

        private static string GetFileFullPath(string fileName, string defaultDirectory = "")
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;

            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var workingDirectory = string.IsNullOrEmpty(defaultDirectory) || !Directory.Exists(defaultDirectory) ? Directory.GetCurrentDirectory() : defaultDirectory;

            var theFile = Directory.GetFiles(workingDirectory, fileName, SearchOption.AllDirectories).FirstOrDefault();
            return theFile ?? string.Empty;
        }

        private static X509Certificate2 LoadServerCertificate(string kestrelCertificate, string kestrelCertificatePassword)
        {
            return new X509Certificate2(File.ReadAllBytes(GetFileFullPath(kestrelCertificate)), kestrelCertificatePassword, X509KeyStorageFlags.MachineKeySet);
        }

        private static SslProtocols GetTlsProtocol(string httpProtocol)
        {
            return (httpProtocol.ToLower()) switch
            {
#pragma warning disable CS0618 // Type or member is obsolete
                "tls" => SslProtocols.Tls,
                "tls11" => SslProtocols.Tls11,
                "tls12" => SslProtocols.Tls12,
                "tls13" => SslProtocols.Tls13,
                "ssl2" => SslProtocols.Ssl2,
                "ssl3" => SslProtocols.Ssl3,
                "none" => SslProtocols.None,
                _ => SslProtocols.Tls12,
            };
            throw new NotImplementedException();
#pragma warning restore CS0618 // Type or member is obsolete
        }

        private static HttpProtocols GetHttProtocol(string httpProtocol)
        {
            if (httpProtocol == null) return HttpProtocols.Http1;

            return (httpProtocol.ToLower()) switch
            {
                "http1" => HttpProtocols.Http1,
                "http2" => HttpProtocols.Http2,
                "http1&2" => HttpProtocols.Http1AndHttp2,
                "none" => HttpProtocols.None,
                _ => HttpProtocols.Http1,
            };
        }
    }
}
