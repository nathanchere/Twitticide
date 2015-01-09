using System.Collections.Generic;

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
}