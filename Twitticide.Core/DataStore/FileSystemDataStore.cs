using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NServiceKit.Text;

namespace Twitticide
{
    public class FileSystemDataStore : IDataStore
    {
        // TODO: this will not live for long

        private readonly string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Twitticide", "Accounts");

        public IEnumerable<TwitticideAccount> LoadAccounts()
        {
            VerifyDataPathExists();

            // TODO: check if any .bak accounts remaining and offer to recover

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

            var path = Path.Combine(DataPath, string.Format("{0}.account.json", account.Id));
            var pathBak = Path.Combine(DataPath, string.Format("{0}.account.bak.json", account.Id));

            if (File.Exists(path)) File.Move(path, pathBak);

            File.WriteAllText(path, text);

            if (File.Exists(pathBak)) File.Delete(pathBak);
        }

        public void DeleteAccount(TwitticideAccount account)
        {
            VerifyDataPathExists();
            var path = Path.Combine(DataPath, string.Format("{0}.account.json", account.Id));
            File.Delete(path);
        }

        public TwitticideAccount LoadAccount(long id)
        {
            VerifyDataPathExists();

            // TODO: check if any .bak accounts remaining and offer to recover

            var file = Directory.GetFiles(DataPath).SingleOrDefault(x => x == id + ".account.json");
            if(file == null) throw new FileNotFoundException("No data file found for account " + id);
            return File.ReadAllText(file).FromJson<TwitticideAccount>();
        }
    }
}