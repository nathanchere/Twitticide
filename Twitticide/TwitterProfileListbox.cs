﻿using System;
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

        private class MinimalRenderer : IRenderer
        {
            public int ItemHeight { get { return 14; } }
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
        }

        private class NormalRenderer : IRenderer
        {
            public int ItemHeight { get { return 34; } }
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
        }

        private class DetailedRenderer : IRenderer
        {
            public int ItemHeight { get { return 66; } }
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
        }
        #endregion

        private DisplayModes _displayMode;
        private IRenderer _renderer;

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
            DrawMode = DrawMode.OwnerDrawFixed;            
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {            
            _renderer.Render(new RenderItemEventArgs(e, Items[e.Index] as TwitterContact, DesignMode));
        }
    }    
}
