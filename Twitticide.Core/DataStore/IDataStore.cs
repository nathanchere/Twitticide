using System;
using System.Collections.Generic;
using System.Drawing;

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

        IEnumerable<Tuple<long, Bitmap>> GetAllAvatars();
        Bitmap GetAvatar(long id);
        void SaveAvatar(long id, Bitmap image);
    }
}