using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Tweetinvi;
using Tweetinvi.Core.Extensions;

namespace Twitticide
{
    public interface ITwitterClient
    {
        TwitterProfile GetUser(long id);
        TwitterProfile GetUser(string userName);
        long[] GetFollowers(string username);
        long[] GetFollowing(string username);
    }

    public class TwitterClient : ITwitterClient
    {
        private const string REG_PATH = @"HKEY_CURRENT_USER\SOFTWARE\NathanChere\Twitticide";
        private const int FETCH_LIMIT = Int32.MaxValue;

        #region .ctor
        public TwitterClient() : this(null, null, null, null) { }

        public TwitterClient(string apiKey, string apiKeySecret, string accessToken, string accessTokenSecret)
        {
            const string KEY_API = @"ApiKey";
            const string KEY_APIPRIVATE = @"ApiSecret";
            const string KEY_TOKEN = @"AccessToken";
            const string KEY_TOKENPRIVATE = @"AccessTokenSecret";

            TwitterCredentials.SetCredentials(
                GetConfigValue(accessToken, KEY_TOKEN),
                GetConfigValue(accessTokenSecret, KEY_TOKENPRIVATE),
                GetConfigValue(apiKey, KEY_API),
                GetConfigValue(apiKeySecret, KEY_APIPRIVATE));
        }

        private string GetConfigValue(string defaultValue, string index)
        {
            var result = defaultValue
                         ?? (string)Registry.GetValue(REG_PATH, index, null)
                         ?? ConfigurationManager.AppSettings[index];
            if (result == null) throw new ConfigurationErrorsException("No defaultValue for " + index + " found in registry or app.config");
            return result;
        }
        #endregion

        public TwitterProfile GetUser(long id)
        {
            return GetUsers(new []{ id }).FirstOrDefault() ?? new TwitterProfile();
        }

        public IEnumerable<TwitterProfile> GetUsers(long[] ids)
        {
            var profiles = User.GetUsersFromIds(ids);
            return profiles.Select(profile => new TwitterProfile(profile));
        }

        public TwitterProfile GetUser(string userName)
        {
            var profile = User.GetUserFromScreenName(userName);
            if (profile == null) return new TwitterProfile();
            return new TwitterProfile(profile);
        }

        public long[] GetFollowers(string username)
        {
            var user = User.GetUserFromScreenName(username);
            var followers = user.GetFollowerIds(FETCH_LIMIT);
            return followers.ToArray();
        }

        public long[] GetFollowing(string username)
        {
            var user = User.GetUserFromScreenName(username);
            var friends = user.GetFriendIds(FETCH_LIMIT);
            return friends.ToArray();
        }        
    }
}
