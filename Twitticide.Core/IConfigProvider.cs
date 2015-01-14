using System;
using System.Configuration;
using System.IO;
using Microsoft.Win32;

namespace Twitticide
{
    // TODO: bootstrap

    public interface IConfigProvider
    {
        string ApplicationDataPath { get; set; }
        string TwitterAccessToken { get; }
        string TwitterAccessTokenSecret { get; }
        string TwitterApiKey { get; }
        string TwitterApiKeySecret { get; }
    }

    public class ConfigProvider : IConfigProvider
    {
        private const string REG_PATH = @"HKEY_CURRENT_USER\SOFTWARE\NathanChere\Twitticide";
        private const string KEY_DATAPATH = @"DataPath";

        private const string KEY_API = @"ApiKey";
        private const string KEY_APIPRIVATE = @"ApiSecret";
        private const string KEY_TOKEN = @"AccessToken";
        private const string KEY_TOKENPRIVATE = @"AccessTokenSecret";

        private string GetConfigValue(string key)
        {
            var result = (string) Registry.GetValue(REG_PATH, key, null)
                         ?? ConfigurationManager.AppSettings[key];

            if (result != null) return result;

            throw new ConfigurationErrorsException("No defaultValue for " + key + " found in registry or app.config");
        }

        public string ApplicationDataPath
        {
            get
            {
                return (string) Registry.GetValue(REG_PATH, KEY_DATAPATH, null)
                       ?? ConfigurationManager.AppSettings[KEY_DATAPATH]
                       ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Twitticide", "Accounts");
            }

            set { Registry.SetValue(REG_PATH, KEY_DATAPATH, value); }
        }

        public string TwitterAccessToken
        {
            get { return GetConfigValue(KEY_TOKEN); }
        }

        public string TwitterAccessTokenSecret
        {
            get { return GetConfigValue(KEY_TOKENPRIVATE); }
        }

        public string TwitterApiKey
        {
            get { return GetConfigValue(KEY_API); }
        }

        public string TwitterApiKeySecret
        {
            get { return GetConfigValue(KEY_APIPRIVATE); }
        }
    }
}