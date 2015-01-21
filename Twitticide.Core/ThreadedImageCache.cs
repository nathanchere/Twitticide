using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Twitticide
{

    /// <summary>
    /// TODO: worry about performance later
    /// </summary>
    public class ThreadedImageCache : IImageCache
    {
        // TODO: Save and load from disk        

        private class TimestampedImage
        {
            public DateTime WhenUpdated { get; set; }
            public Bitmap Image { get; set; }

            public TimestampedImage(Bitmap image)
            {
                Image = image;
                WhenUpdated = DateTime.Now;
            }
        }        

        public ThreadedImageCache()
        {
            _queue = new ConcurrentDictionary<long, TwitterProfile>();
            _icons = new ConcurrentDictionary<long, TimestampedImage>();
        }

        private readonly ConcurrentDictionary<long, TwitterProfile> _queue;
        private readonly ConcurrentDictionary<long, TimestampedImage> _icons;
        private Guid _guid = Guid.NewGuid();
        
        private Task _updateThread = null;

        private void RefreshCache()
        {
            while (_queue.Any())
            {
                var id = _queue.First().Key;
                TwitterProfile profile;
                _queue.TryRemove(id, out profile);

                Debug.WriteLine("ImageCache fetching profile image " + id);

                try
                {
                    var request = WebRequest.Create(profile.ProfileImageUrl);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        _icons[profile.Id] = new TimestampedImage(new Bitmap(Image.FromStream(stream), 64, 64));
                    }
                }
                catch (Exception ex)
                {
                    Debugger.Break();
                    //_icons[profile.Id, Properties.Resources.Avatar_Missing);
                }
            }
        }

        /// <summary>
        /// Tells the cache to fetch and cache the image for a given profile
        /// </summary>
        public void UpdateCache(TwitterProfile profile)
        {
            if(!_queue.ContainsKey(profile.Id) && !_icons.ContainsKey(profile.Id)) _queue[profile.Id] = profile;

            RefreshCache();

            //// Start the worker thread if not already working
            //if (_updateThread == null || _updateThread.IsCanceled || _updateThread.IsCompleted || _updateThread.IsFaulted)
            //{
            //    _updateThread = new Task(RefreshCache);
            //    _updateThread.Start();
            //}
        }

        public Bitmap GetAvatar(long id)
        {
            try
            {
                if (!_icons.ContainsKey(id))
                {
                    return GetDefaultAvatar();
                }
                return _icons[id].Image;
            }
            catch(Exception ex)
            {
                return GetDefaultAvatar();
            }
        }

        private Bitmap GetDefaultAvatar()
        {
            return new Bitmap(3,3);
            //return Properties.Resources.Avatar_Missing;
        }
    }
}