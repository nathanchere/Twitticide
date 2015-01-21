using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using NServiceKit.Text;

namespace Twitticide
{
    public class FileSystemDataStore : IDataStore
    {               
        private readonly string DefaultDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Twitticide");        

        private IConfigProvider _config;

        public FileSystemDataStore(IConfigProvider config)
        {
            _config = config;
        }

        private string DataPathAccounts { get { return Path.Combine(_config.ApplicationDataPath, "Accounts"); } }
        private string DataPathImages { get { return Path.Combine(_config.ApplicationDataPath, "Images"); } }

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

            var file = GetAllAccountDataFiles().SingleOrDefault(x => Path.GetFileName(x) == id + ".account.json");
            if(file == null) throw new FileNotFoundException("No data file found for account " + id);
            return File.ReadAllText(file).FromJson<TwitticideAccount>();
        }        

        private IEnumerable<string> GetAllAccountDataFiles()
        {
            return Directory.GetFiles(DataPathAccounts);
        }

        private IEnumerable<string> GetAllTwitterProfileImageCacheFiles()
        {
            return Directory.GetFiles(DataPathImages);
        }

        public void RestoreBackup(string fileName)
        {
            VerifyDataPathExists(DataPathAccounts);            

            using (var zip = ZipFile.OpenRead(fileName))
            {
                foreach (var file in zip.Entries)
                {
                    var outputPath = Path.Combine(DataPathAccounts, file.Name);
                    if(File.Exists(outputPath)) File.Delete(outputPath);

                    file.ExtractToFile(outputPath);
                }
            }
        }

        public IEnumerable<Tuple<long, Bitmap>> GetAllAvatars()
        {
            VerifyDataPathExists(DataPathImages);

            var files = Directory.GetFiles(DataPathImages).Where(x => x.EndsWith(".profile.png"));
            return files
                .Select(f =>
                {
                    var image = new Bitmap(f);
                    var id = long.Parse(Path.GetFileName(f).Split('.')[0]);
                    return new Tuple<long, Bitmap>(id, image);
                });
        }

        public Bitmap GetAvatar(long id)
        {
            var file = Directory.GetFiles(DataPathAccounts).Single(x => Path.GetFileName(x) == id + ".profile.png");
            return new Bitmap(file);
        }

        public void SaveAvatar(long id, Bitmap image)
        {
            var fileName = Path.Combine(DataPathImages, id + ".profile.png");
            if(File.Exists(fileName)) File.Delete(fileName);
            image.Save(fileName, ImageFormat.Png);
        }

        public void BackupData(string fileName)
        {
            VerifyDataPathExists(DataPathAccounts);

            using (var zip = ZipFile.Open(fileName, ZipArchiveMode.Create, Encoding.UTF8))
            {
                foreach (var file in GetAllAccountDataFiles())
                {
                    var text = File.ReadAllText(file);
                    var entry = zip.CreateEntry(Path.GetFileName(file));
                    using (var writer = new StreamWriter(entry.Open()))
                    {
                        writer.Write(text);
                    }
                }
            }
        }
    }
}