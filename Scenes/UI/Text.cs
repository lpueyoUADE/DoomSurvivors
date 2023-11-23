using DoomSurvivors.Entities;
using DoomSurvivors.Utilities;
using System;
using Tao.Sdl;
using static DoomSurvivors.Scenes.UI.Font;

namespace DoomSurvivors.Scenes.UI
{
    public class Text : UIElement
    {
        private IntPtr loadedFont;
        private int fontSize;
        private string content;
        private Color color;

        public IntPtr LoadedFont
        {
            get => loadedFont;
        }

        public int FontSize
        {
            get => fontSize;
        }

        public string Content
        {
            get => content;
            set => content = value;
        }

        public Color Color
        {
            get => color;
        }

        public Text(int x, int y, int padding, FontType fontType, int fontSize, Color color, string content="", Color backgroundColor=null) : base(x,y, padding, backgroundColor)
        {
            this.loadedFont = Font.Get(fontType, fontSize);

            SdlTtf.TTF_SizeUNICODE(this.loadedFont, content, out int w, out int h);
            this.Transform.W = w;
            this.Transform.H = h;
            this.fontSize = fontSize;
            this.color = color;
            this.content = content;
        }

        public override void Render()
        {
            Engine.DrawText(content, Transform.X, Transform.Y, Padding, color, BackgroundColor, this.loadedFont);
        }

        public override void Update()
        {}
    }
}
