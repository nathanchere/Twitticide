using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Twitticide
{/*
    public class ImageCache : IImageCache  
    {       
        public ImageCache(IDataStore dataStore)
        {
            _dataStore = dataStore;
            _icons = new ConcurrentDictionary<long, Bitmap>();
            _placeholderBitmap = new Bitmap(3,3);
            var graphics = Graphics.FromImage(_placeholderBitmap);
            graphics.Clear(Color.Red);

        }

        private IDataStore _dataStore;
        private Bitmap _placeholderBitmap;
        private readonly ConcurrentDictionary<long, Bitmap> _icons;
        private Guid _guid = Guid.NewGuid();
                
        /// <summary>
        /// Tells the cache to fetch and cache the image for a given profile
        /// </summary>
        public void UpdateCache(TwitterProfile profile)
        {
            if (_icons.ContainsKey(profile.Id)) return;

            try
            {
                var request = WebRequest.Create(profile.ProfileImageUrl);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    _icons[profile.Id] = new Bitmap(Image.FromStream(stream), 64, 64);
                }
            }
            catch (Exception ex)
            {
                Debugger.Break();
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
                return _icons[id];
            }
            catch(Exception ex)
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
  * */
}