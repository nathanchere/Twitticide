using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NServiceKit.Text;

namespace Twitticide
{
    public interface IDataStore
    {
        IEnumerable<TwitticideAccount> LoadUsers();
        void SaveUsers(TwitticideAccount[] users);
    }

    public class MockDataStore : IDataStore
    {
        public IEnumerable<TwitticideAccount> LoadUsers()
        {
            yield return new TwitticideAccount
            {
                Id = 1680121153,
                UserName = "nathanchere",
                DisplayName = "Nathan Chere",
            };
        }

        public void SaveUsers(TwitticideAccount[] users)
        {
            // do nothing
        }
    }

    public class FileSystemDataStore : IDataStore
    {       
        // TODO: this will not live for long

        private readonly string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Twitticide", "Accounts");

        public IEnumerable<TwitticideAccount> LoadUsers()
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

        public void SaveUsers(TwitticideAccount[] users)
        {
            VerifyDataPathExists();
            foreach (var user in users)
            {
                var text = user.ToJson();
                
                // TODO: back up old file before writing over

                var path = Path.Combine(DataPath, string.Format("{0}.account.json", user.Id));
                File.WriteAllText(path, text);
            }
        }
    }
}