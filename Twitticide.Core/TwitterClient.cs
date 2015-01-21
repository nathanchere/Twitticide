using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Tweetinvi;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Core.Interfaces.Credentials;

namespace Twitticide
{
    public interface ITwitterClient
    {
        TwitterProfile GetUser(long id);
        IEnumerable<TwitterProfile> GetUsers(IEnumerable<long> id);
        TwitterProfile GetUser(string userName);
        long[] GetFollowers(string username);
        long[] GetFollowing(string username);
        ITokenRateLimits CheckLimits();
    }

    public class TwitterClient : ITwitterClient
    {
        private DateTime _lastExceptionTimestamp;
        private IConfigProvider _config;        

        public TwitterClient(IConfigProvider config) : this(null, null, null, null, config) { }
        public TwitterClient(string apiKey, string apiKeySecret, string accessToken, string accessTokenSecret, IConfigProvider config)
        {
            _config = config;
            TwitterCredentials.SetCredentials(
                apiKey ?? _config.TwitterAccessToken,
                apiKeySecret ?? _config.TwitterAccessTokenSecret,
                accessToken ?? _config.TwitterApiKey,
                accessTokenSecret ?? _config.TwitterApiKeySecret);
        }        

        public TwitterProfile GetUser(long id)
        {
            return GetUsers(new []{ id }).FirstOrDefault() ?? new TwitterProfile();
        }

        public IEnumerable<TwitterProfile> GetUsers(IEnumerable<long> ids)
        {
            var profiles = User.GetUsersFromIds(ids);
            CheckForExceptions();
            return profiles.Select(profile => new TwitterProfile(profile)).ToList(); 
        }

        public TwitterProfile GetUser(string userName)
        {
            var profile = User.GetUserFromScreenName(userName);
            CheckForExceptions();
            if (profile == null) return new TwitterProfile();
            return new TwitterProfile(profile);
        }

        public long[] GetFollowers(string username)
        {
            var user = User.GetUserFromScreenName(username);
            var followers = user.GetFollowerIds();
            CheckForExceptions();
            return followers.ToArray();
        }

        public long[] GetFollowing(string username)
        {
            var user = User.GetUserFromScreenName(username);
            var friends = user.GetFriendIds();
            CheckForExceptions();
            return friends.ToArray();
        }

        public ITokenRateLimits CheckLimits()
        {
            return RateLimit.GetCurrentCredentialsRateLimits();            
        }

        private void CheckForExceptions()
        {
            var x = ExceptionHandler.GetExceptions();
            if (x.Any()) {
                var ex = x.Last();
                if (ex.CreationDate <= _lastExceptionTimestamp) return;

                _lastExceptionTimestamp = ex.CreationDate;

                if (ex.StatusCode == 429) throw new TooManyRequestsException();
                Debugger.Break();
            } 
        }
    }

    public class TooManyRequestsException : Exception { }
}
