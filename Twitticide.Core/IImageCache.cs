using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Twitticide
{
    public interface IImageCache
    {
        /// <summary>
        /// Retrieve a Twitter user's avatar if cached, otherwise return a placeholder image
        /// </summary>
        Bitmap GetAvatar(long id);
        
        /// <summary>
        /// Tells the cache to fetch and cache the image for a given profile
        /// </summary>
        void UpdateCache(TwitterProfile profile);

        //TODO: mechanism for updating old/stale ones
    }

    // TODO: support saving and loading locally
}