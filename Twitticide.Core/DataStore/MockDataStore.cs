using System.Collections.Generic;

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
    }
}