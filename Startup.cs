using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using andead.netcore.ocelot.Managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace andead.netcore.ocelot
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        private const string AUTHENTICATION_PROVIDER_KEY = "AuthKey";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigurationManager configurationManager = new ConfigurationManager(_configuration);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = configurationManager.GetValue(ConfigurationKey.ISSUER),
                ValidAudience = configurationManager.GetValue(ConfigurationKey.AUDIENCE),
                IssuerSigningKey = configurationManager.GetSymmetricSecurityKey(ConfigurationKey.SIGNING_KEY),
                ClockSkew = TimeSpan.Zero
            };

            services
                .AddSingleton(configurationManager)
                .AddAuthentication()
                .AddJwtBearer(AUTHENTICATION_PROVIDER_KEY, x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = tokenValidationParameters;
                });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status301MovedPermanently;
                options.HttpsPort = int.Parse(configurationManager.GetValue(ConfigurationKey.LISTEN_PORT));
            });

            services.AddOcelot();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection().UseOcelot().Wait();
        }
    }
}
