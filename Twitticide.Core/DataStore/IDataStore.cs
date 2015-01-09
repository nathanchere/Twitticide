using System.Collections.Generic;

namespace Twitticide
{
    public interface IDataStore
    {
        IEnumerable<TwitticideAccount> LoadAccounts();
        void SaveAccount(TwitticideAccount newAccount);
    }
}