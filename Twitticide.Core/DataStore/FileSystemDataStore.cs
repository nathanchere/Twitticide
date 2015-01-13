using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using NServiceKit.Text;

namespace Twitticide
{
    public class FileSystemDataStore : IDataStore
    {               
        private readonly string DefaultDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Twitticide");
        private const string REG_PATH = @"HKEY_CURRENT_USER\SOFTWARE\NathanChere\Twitticide";

        private string DataPath{
            get
            {
                const string key = "DataPath";
                ApplicationDataPath = ApplicationDataPath ?? (string)Registry.GetValue(REG_PATH, key, null)
                        ?? ConfigurationManager.AppSettings[key]
                        ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Twitticide", "Accounts");

                return ApplicationDataPath;
            }
        }

        private string DataPathAccounts { get { return Path.Combine(DataPath, "Accounts"); } }

        public IEnumerable<TwitticideAccount> LoadAccounts()
        {
            VerifyDataPathExists(DataPathAccounts);

            // TODO: check if any .bak accounts remaining and offer to recover

            var files = Directory.GetFiles(DataPathAccounts).Where(x => x.EndsWith(".account.json"));
            return files
                .Select(File.ReadAllText)
                .Select(text => text.FromJson<TwitticideAccount>());
        }

        private void VerifyDataPathExists(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        public void SaveAccount(TwitticideAccount account)
        {
            VerifyDataPathExists(DataPathAccounts);
            var text = account.ToJson();

            var path = Path.Combine(DataPathAccounts, string.Format("{0}.account.json", account.Id));
            var pathBak = Path.Combine(DataPathAccounts, string.Format("{0}.account.bak.json", account.Id));

            if (File.Exists(path)) File.Move(path, pathBak);

            File.WriteAllText(path, text);

            if (File.Exists(pathBak)) File.Delete(pathBak);
        }

        public void DeleteAccount(TwitticideAccount account)
        {
            VerifyDataPathExists(DataPathAccounts);
            var path = Path.Combine(DataPathAccounts, string.Format("{0}.account.json", account.Id));
            File.Delete(path);
        }

        public TwitticideAccount LoadAccount(long id)
        {
            VerifyDataPathExists(DataPathAccounts);

            // TODO: check if any .bak accounts remaining and offer to recover

            var file = Directory.GetFiles(DataPathAccounts).SingleOrDefault(x => Path.GetFileName(x) == id + ".account.json");
            if(file == null) throw new FileNotFoundException("No data file found for account " + id);
            return File.ReadAllText(file).FromJson<TwitticideAccount>();
        }

        public string ApplicationDataPath { get; set; }
    }
}