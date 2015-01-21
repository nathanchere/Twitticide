using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

namespace Twitticide
{
    public interface IImageCache
    {
        Bitmap GetAvatar(long id);
    }

    // TODO: support saving and loading locally
    public class ImageCache : IImageCache
    {
        public ImageCache()
        {
            _icons = new ConcurrentDictionary<long, Bitmap>();
        }

        private readonly IDictionary<long, Bitmap> _icons;
        private readonly HashSet<long> _queue; // Icons to download 

        private void RefreshIcon(TwitterContact item)
        {
            if (item.Profile == null) return;
            
            try
            {
                var request = WebRequest.Create(item.Profile.ProfileImageUrl);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    _icons.Add(item.Id, new Bitmap(Image.FromStream(stream), 64, 64));
                }
            }
            catch (Exception ex)
            {
                if (_icons.ContainsKey(item.Id)) return;
                _icons.Add(item.Id, Properties.Resources.Avatar_Missing);
            }
        }

        private void UpdateCache(long id)
        {
        }

        public Bitmap GetAvatar(long id)
        {
            try
            {
                if (!_icons.ContainsKey(id))
                {
                    UpdateCache(id);
                    return Properties.Resources.Avatar_Missing;
                }
                return _icons[id];
            }
            catch(Exception ex)
            {
                return Properties.Resources.Avatar_Missing;
            }
        }
    }
}