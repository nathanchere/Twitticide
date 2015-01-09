using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NServiceKit.Text;

namespace Twitticide
{
    public interface IDataStore
    {
        IEnumerable<TwitticideAccount> LoadAccounts();
        void SaveAccount(TwitticideAccount newAccount);
    }

    public class MockDataStore : IDataStore
    {
        public IEnumerable<TwitticideAccount> LoadAccounts()
        {
            yield return new TwitticideAccount
            {
                Id = 1680121153,
                UserName = "nathanchere",
                DisplayName = "Nathan Chere",
            };
        }

        public void SaveAccount(TwitticideAccount newAccount)
        {
            // do nothing
        }
    }

    public class FileSystemDataStore : IDataStore
    {       
        // TODO: this will not live for long

        private readonly string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Twitticide", "Accounts");

        public IEnumerable<TwitticideAccount> LoadAccounts()
        {
            VerifyDataPathExists();

            var files = Directory.GetFiles(DataPath).Where(x => x.EndsWith(".account.json"));
            return files
                .Select(File.ReadAllText)
                .Select(text => text.FromJson<TwitticideAccount>());
        }

        private void VerifyDataPathExists()
        {
            if (!Directory.Exists(DataPath)) Directory.CreateDirectory(DataPath);
        }        

        public void SaveAccount(TwitticideAccount account)
        {
            VerifyDataPathExists();
            var text = account.ToJson();
                
            // TODO: back up old file before writing over

            var path = Path.Combine(DataPath, string.Format("{0}.account.json", account.Id));
            File.WriteAllText(path, text);            
        }
    }
}