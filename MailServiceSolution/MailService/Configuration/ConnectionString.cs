using System.Configuration;

namespace MailService
{
    public class ConnectionString
    {
        private readonly string _key;

        public ConnectionString(string key) => _key = key;

        public string Get() 
        { 
            return ConfigurationManager
                .ConnectionStrings[_key]
                .ConnectionString;
        }
    }
}