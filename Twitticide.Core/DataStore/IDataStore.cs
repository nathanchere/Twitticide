using System.Collections.Generic;

namespace Twitticide
{
    public interface IDataStore
    {
        IEnumerable<TwitticideAccount> LoadAccounts();
        void SaveAccount(TwitticideAccount newAccount);
        void DeleteAccount(TwitticideAccount accounts);
        TwitticideAccount LoadAccount(long id);        
        void BackupData(string fileName);
        void RestoreBackup(string fileName);
    }
}