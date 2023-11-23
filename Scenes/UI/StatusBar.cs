using DoomSurvivors.Entities;
using DoomSurvivors.Utilities;
using System.Windows;

namespace DoomSurvivors.Scenes.UI
{
    internal class StatusBar : UIElement
    {
        private Transform rectBar;
        private Color rectBarColor;
        private Text text;
        private float fullness;
        private string displayValue;

        public string DisplayValue
        {
            get => displayValue;
            set { 
                displayValue = value;
                this.text.Content = value;
            }
        }

        public float Fullness
        {
            get => fullness;
            set
            {
                fullness = Tools.Clamp(value, 0, 1);
            }
        }
        private Transform rectBarPercentaged
        {
            get => new Transform(rectBar.X, rectBar.Y, (int)(rectBar.W * fullness), rectBar.H);
        }
        public StatusBar(Transform fullSizeTransform, float fullness, int padding, int fontSize, string displayValue, Vector textOffset, Color textColor, Color rectBarColor) : base(fullSizeTransform.X, fullSizeTransform.Y, 0, null)
        {
            this.rectBar = fullSizeTransform;
            this.rectBarColor = rectBarColor;
            this.fullness = fullness;
            this.displayValue = displayValue;
            this.text = new Text(this.rectBar.X + (int)textOffset.X, this.rectBar.Y + (int)textOffset.Y, padding, Font.FontType.DoomFont, fontSize, textColor, displayValue);
        }

        public override void Render()
        {
            Engine.DrawFilledRect(rectBarPercentaged, rectBarColor,3);
            text.Render();
        }

        public override void Update()
        {}
    }
}
