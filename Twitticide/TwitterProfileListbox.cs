using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitticide
{
    public partial class TwitterProfileListbox : ListBox
    {
        #region Item renderers

        private interface IRenderer
        {
            int ItemHeight { get; }
            void Render(RenderItemEventArgs e);

            event ProfileInteractionDelegate Follow;
            event ProfileInteractionDelegate Unfollow;
            event ProfileInteractionDelegate Mute;
            event ProfileInteractionDelegate Block;
        }

        public delegate void ProfileInteractionDelegate(object sender, ProfileInteractionEventArgs args);

        public class ProfileInteractionEventArgs : EventArgs
        {
            public long TwitterAccountId { get; set; }
        }

        private class RenderItemEventArgs : EventArgs
        {
            public DrawItemEventArgs args { get; private set; }
            public TwitterContact item { get; private set; }
            public bool designMode { get; private set; }

            public RenderItemEventArgs(DrawItemEventArgs args, TwitterContact item, bool designMode)
            {
                this.args = args;
                this.item = item;
                this.designMode = designMode;
            }
        }

        private class MinimalRenderer : IRenderer
        {
            public int ItemHeight
            {
                get { return 14; }
            }

            public void Render(RenderItemEventArgs e)
            {
                const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;

                if (e.args.Index >= 0)
                {
                    e.args.DrawBackground();
                    var textRect = e.args.Bounds;
                    textRect.X += 20;
                    textRect.Width -= 4;
                    string itemText = e.designMode ? "AddressListBox" : e.item.ToString();
                    TextRenderer.DrawText(e.args.Graphics, itemText, e.args.Font, textRect, e.args.ForeColor, flags);
                    e.args.DrawFocusRectangle();
                }
            }

            public event ProfileInteractionDelegate Follow;
            public event ProfileInteractionDelegate Unfollow;
            public event ProfileInteractionDelegate Mute;
            public event ProfileInteractionDelegate Block;
        }

        private class NormalRenderer : IRenderer
        {
            public int ItemHeight
            {
                get { return 34; }
            }

            public void Render(RenderItemEventArgs e)
            {
                const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;

                if (e.args.Index >= 0)
                {
                    e.args.DrawBackground();
                    var textRect = e.args.Bounds;
                    textRect.X += 20;
                    textRect.Width -= 4;
                    string itemText = e.designMode ? "AddressListBox" : e.item.ToString();
                    TextRenderer.DrawText(e.args.Graphics, itemText, e.args.Font, textRect, e.args.ForeColor, flags);
                    e.args.DrawFocusRectangle();
                }
            }

            public event ProfileInteractionDelegate Follow;
            public event ProfileInteractionDelegate Unfollow;
            public event ProfileInteractionDelegate Mute;
            public event ProfileInteractionDelegate Block;
        }

        private class DetailedRenderer : IRenderer
        {
            private readonly Dictionary<long, Bitmap> _icons;

            public DetailedRenderer()
            {
                _icons = new Dictionary<long, Bitmap>();
            }

            public int ItemHeight
            {
                get { return 66; }
            }

            public void Render(RenderItemEventArgs e)
            {
                if (e.args.Index >= 0)
                {
                    if (!_icons.ContainsKey(e.item.Id)) RefreshIcon(e.item);                    
                    e.args.DrawBackground();
                    
                    e.args.Graphics.DrawImage(_icons[e.item.Id], e.args.Bounds.X + 2, e.args.Bounds.Y + 2, 64, 64);

                    var textRectUserName = e.args.Bounds;
                    textRectUserName.X += 66;
                    textRectUserName.Y += 6;
                    textRectUserName.Width -= 66;
                    var fontUserName = new Font(e.args.Font.FontFamily, 18, FontStyle.Bold);
                

                    var textRectDisplayName= e.args.Bounds;
                    textRectDisplayName.X += 66;
                    textRectDisplayName.Width -= 66;
                    textRectDisplayName.Height -= 8;
                    var fontDisplayName = new Font(e.args.Font.FontFamily, 11);

                    string userName = e.designMode ? "@UserName" : e.item.Profile != null ? "@" + e.item.Profile.UserName : "#" + e.item.Id;
                    string displayName = e.designMode ? "Twitter User" : e.item.Profile != null ? e.item.Profile.DisplayName : "[no profile]";
                    TextRenderer.DrawText(e.args.Graphics, userName, fontUserName, textRectUserName, e.args.ForeColor, TextFormatFlags.Left | TextFormatFlags.Top);
                    TextRenderer.DrawText(e.args.Graphics, displayName, fontDisplayName, textRectDisplayName, e.args.ForeColor, TextFormatFlags.Left | TextFormatFlags.Bottom);
                    e.args.DrawFocusRectangle();
                }
            }

            private void RefreshIcon(TwitterContact item)
            {
                if (item.Profile == null) {
                    _icons.Add(item.Id, Properties.Resources.Avatar_Missing);
                    return;
                }
                try
                {

                    var request = WebRequest.Create(item.Profile.ProfileImageUrl);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        _icons.Add(item.Id, new Bitmap(Bitmap.FromStream(stream), 64, 64));
                    }
                }
                catch(Exception ex)
                {
                    _icons.Add(item.Id, Properties.Resources.Avatar_Missing);
                }
            }

            public event ProfileInteractionDelegate Follow;
            public event ProfileInteractionDelegate Unfollow;
            public event ProfileInteractionDelegate Mute;
            public event ProfileInteractionDelegate Block;
        }

        #endregion

        private IRenderer _renderer;
        private DisplayModes _displayMode;

        public DisplayModes DisplayMode
        {
            get { return _displayMode; }
            set
            {
                _displayMode = value;
                switch (value)
                {
                    case DisplayModes.Minimal:
                        _renderer = new MinimalRenderer();
                        break;

                    case DisplayModes.Normal:
                        _renderer = new NormalRenderer();
                        break;

                    case DisplayModes.Detailed:
                        _renderer = new DetailedRenderer();
                        break;
                }
                ItemHeight = _renderer.ItemHeight;
            }
        }

        public enum DisplayModes
        {
            Minimal,
            Normal,
            Detailed,
        }

        public TwitterProfileListbox()
        {
            InitializeComponent();
            DisplayMode = DisplayModes.Minimal;
            DrawMode = DrawMode.OwnerDrawFixed;
        }        

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (DesignMode)
            {
                _renderer.Render(new RenderItemEventArgs(e, new TwitterContact(), true));
                return;
            }

            _renderer.Render(new RenderItemEventArgs(e, e.Index >= 0 ? Items[e.Index] as TwitterContact : null, false));
        }
    }
}
