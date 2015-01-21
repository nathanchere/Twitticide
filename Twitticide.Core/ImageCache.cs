using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Twitticide
{
    public class ImageCache : IImageCache
    {
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

        public ImageCache(IDataStore dataStore)
        {
            _dataStore = dataStore;
            _queue = new ConcurrentDictionary<long, TwitterProfile>();
            _icons = new ConcurrentDictionary<long, TimestampedImage>();
            _placeholderBitmap = new Bitmap(3, 3);
            var graphics = Graphics.FromImage(_placeholderBitmap);
            graphics.Clear(Color.Red);

            ReloadCache();
        }

        private void ReloadCache()
        {
            foreach (var result in _dataStore.GetAllAvatars())
            {
                _icons.TryAdd(result.Item1, new TimestampedImage(result.Item2));
            }
        }

        private readonly ConcurrentDictionary<long, TwitterProfile> _queue;
        private readonly ConcurrentDictionary<long, TimestampedImage> _icons;
        private readonly Bitmap _placeholderBitmap;
        private readonly IDataStore _dataStore;

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
                    var request = WebRequest.Create(profile.ProfileImageUrl.Replace("_normal","_bigger"));
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {   
                        var image= new Bitmap(Image.FromStream(stream), 64, 64); 
                        _icons[profile.Id] = new TimestampedImage(image);
                        _dataStore.SaveAvatar(profile.Id, image);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Fetch Twitter profile image failed: " + ex.Message);                  
                }
            }
        }

        /// <summary>
        /// Tells the cache to fetch and cache the image for a given profile
        /// </summary>
        public void UpdateCache(TwitterProfile profile)
        {
            if (!_queue.ContainsKey(profile.Id) && !_icons.ContainsKey(profile.Id)) _queue[profile.Id] = profile;

            // Start the worker thread if not already working
            if (_updateThread == null || _updateThread.IsCanceled || _updateThread.IsCompleted ||
                _updateThread.IsFaulted)
            {
                _updateThread = new Task(RefreshCache);
                _updateThread.Start();
            }
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
            catch (Exception ex)
            {
                return GetDefaultAvatar();
            }
        }

        private Bitmap GetDefaultAvatar()
        {
            return _placeholderBitmap;
            //return Properties.Resources.Avatar_Missing;
        }
    }
}