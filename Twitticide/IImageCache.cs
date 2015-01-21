using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

namespace Twitticide
{
    public interface IImageCache
    {
        void Cache(TwitterContact contact);
        Bitmap GetAvatar(long id);
    }

    // TODO: support saving and loading locally
    public class ImageCache : IImageCache
    {
        public ImageCache()
        {
            _icons = new Dictionary<long, Bitmap>();
        }

        private readonly Dictionary<long, Bitmap> _icons;

        public void Cache(TwitterContact contact)
        {
            if (!_icons.ContainsKey(contact.Id)) RefreshIcon(contact);
        }

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

        public Bitmap GetAvatar(long id)
        {
            try
            {
                if (!_icons.ContainsKey(id)) return Properties.Resources.Avatar_Missing;
                return _icons[id];
            }
            catch(Exception ex)
            {
                return Properties.Resources.Avatar_Missing;
            }
        }
    }
}