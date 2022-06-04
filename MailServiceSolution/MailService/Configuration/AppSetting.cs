using System.Configuration;

namespace MailService
{
    public class AppSetting
    {
        private readonly string _key;

        public AppSetting(string key) => _key = key;

        public string Get() => ConfigurationManager.AppSettings[_key];

        public void Set(string value) => ConfigurationManager.AppSettings.Set(_key, value);
    }
}
