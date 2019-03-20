using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace andead.netcore.ocelot.Managers
{
    public static class ConfigurationKey
    {
        public const string ISSUER = "issuer";
        public const string AUDIENCE = "audience";
        public const string SIGNING_KEY = "signing-key";
        public const string LISTEN_PORT = "listen-port";
    }

    public class ConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetValue(string key, string defaultValue = "")
        {
            return _configuration.GetValue<string>(key, defaultValue);
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey(string signingKey)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GetValue(signingKey)));
        }
    }
}