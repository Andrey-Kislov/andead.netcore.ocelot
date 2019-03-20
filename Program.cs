using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace andead.netcore.ocelot
{
    public class Program
    {
        private const string LISTEN_PORT_KEY_NAME = "listen-port";
        private const string CERT_PASSWORD = "cert-password";

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel((hostingContext, options) =>
                {
                    int listenPort = hostingContext.Configuration.GetValue<int>(LISTEN_PORT_KEY_NAME, 8081);
                    string certPassword = hostingContext.Configuration.GetValue<string>(CERT_PASSWORD, "");

                    options.Listen(IPAddress.Any, 8080);

                    // Use HTTPS
                    options.Listen(IPAddress.Any, listenPort, listenOptions => {
                        listenOptions.UseHttps(@"certs/cert.pfx", certPassword);
                    });
                })
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("configuration.json", true, true);
                    config.AddCommandLine(args);
                })
                .UseStartup<Startup>();
    }
}
