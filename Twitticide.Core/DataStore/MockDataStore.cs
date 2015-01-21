using System;
using System.Collections.Generic;
using System.Drawing;

namespace Twitticide
{
    public class MockDataStore : IDataStore
    {
        private readonly Dictionary<long, TwitticideAccount> _accounts;

        public MockDataStore()
        {
            _accounts = new Dictionary<long, TwitticideAccount>();
        }

        public IEnumerable<TwitticideAccount> LoadAccounts()
        {
            return _accounts.Values;
        }

        public void SaveAccount(TwitticideAccount newAccount)
        {
            _accounts[newAccount.Id] = newAccount;
        }

        public void DeleteAccount(TwitticideAccount accounts)
        {
            _accounts.Remove(accounts.Id);
        }

        public TwitticideAccount LoadAccount(long id)
        {
            if(!_accounts.ContainsKey(id)) throw new Exception("Account not found");
            return _accounts[id];
        }

        public string ApplicationDataPath { get; set; }
        public void BackupData(string fileName)
        {
            return;
        }

        public void RestoreBackup(string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<long, Bitmap>> GetAllAvatars()
        {
            throw new NotImplementedException();
        }

        public Bitmap GetAvatar(long id)
        {
            throw new NotImplementedException();
        }

        public void SaveAvatar(long id, Bitmap image)
        {
            throw new NotImplementedException();
        }
    }
}