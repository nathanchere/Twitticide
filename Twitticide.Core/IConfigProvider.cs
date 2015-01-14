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
    }

    class ConfigProvider : IConfigProvider
    {
        private const string REG_PATH = @"HKEY_CURRENT_USER\SOFTWARE\NathanChere\Twitticide";
        private const string KEY_DATAPATH = @"DataPath";

        public ConfigProvider()
        {
            
        }

        public string ApplicationDataPath
        {
            get
            {
                return (string)Registry.GetValue(REG_PATH, KEY_DATAPATH, null)
                        ?? ConfigurationManager.AppSettings[KEY_DATAPATH]
                        ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Twitticide", "Accounts");                
            }

            set { Registry.SetValue(REG_PATH, KEY_DATAPATH, value); }
        }
    }
}