using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
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

        private abstract class BaseRenderer : IRenderer
        {
            public delegate void ProfileInteractionDelegate(object sender, ProfileInteractionEventArgs args);

            public event ProfileInteractionDelegate Follow;
            public event ProfileInteractionDelegate Unfollow;
            public event ProfileInteractionDelegate Mute;
            public event ProfileInteractionDelegate Block;

            public class ProfileInteractionEventArgs : EventArgs
            {
                public long TwitterAccountId { get; set; }
            }

            public abstract int ItemHeight { get; }
            public abstract void Render(RenderItemEventArgs e);
        }

        private class MinimalRenderer : BaseRenderer 
        {
            public override int ItemHeight { get { return 14; } }
            public override void Render(RenderItemEventArgs e)
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
        }

        private class NormalRenderer : BaseRenderer
        {
            public override int ItemHeight { get { return 34; } }
            public override void Render(RenderItemEventArgs e)
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
        }

        private class DetailedRenderer : BaseRenderer
        {
            public override int ItemHeight { get { return 66; } }
            public override void Render(RenderItemEventArgs e)
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
        }
        #endregion

        private IRenderer _renderer;
        private DisplayModes _displayMode;        

        public DisplayModes DisplayMode
        {
            get { return _displayMode; }
            set {
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
