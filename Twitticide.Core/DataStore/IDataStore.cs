using System.Collections.Generic;

namespace Twitticide
{
    public interface IDataStore
    {
        IEnumerable<TwitticideAccount> LoadAccounts();
        void SaveAccount(TwitticideAccount newAccount);
        void DeleteAccount(TwitticideAccount accounts);
        TwitticideAccount LoadAccount(long id);
        string ApplicationDataPath { get; set; }
        void BackupData(string fileName);
    }
}