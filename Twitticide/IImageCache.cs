using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;

namespace Twitticide
{
    public interface IImageCache
    {
        Bitmap GetAvatar(long id);

        //TODO: mechanism for updating old ones
    }

    // TODO: support saving and loading locally
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

        public ImageCache()
        {
            _icons = new ConcurrentDictionary<long, TimestampedImage>();
        }

        private readonly ConcurrentHashset<long> _queue; // Icons to download
        private readonly ConcurrentDictionary<long, TimestampedImage> _icons;

        private void RefreshIcon(long id)
        {                        
            //try
            //{
            //    var request = WebRequest.Create(item.Profile.ProfileImageUrl);
            //    using (var response = request.GetResponse())
            //    using (var stream = response.GetResponseStream())
            //    {
            //        _icons.Add(item.Id, new Bitmap(Image.FromStream(stream), 64, 64));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (_icons.ContainsKey(item.Id)) return;
            //    _icons.Add(item.Id, Properties.Resources.Avatar_Missing);
            //}
            
            var nextId = _queue.FirstOrDefault();
            if (nextId != default(long))
            {
                _queue.TryRemove(nextId);
                ThreadPool.QueueUserWorkItem(_ => RefreshIcon(nextId));
            }
        }

        private void UpdateCache(long id)
        {
            ThreadPool.QueueUserWorkItem(_ => RefreshIcon(id));
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
                return _icons[id].Image;
            }
            catch(Exception ex)
            {
                return Properties.Resources.Avatar_Missing;
            }
        }
    }
}