
using DoomSurvivors.Utilities;
using System;

namespace DoomSurvivors.Scenes.UI
{
    public class Button : Text
    {

        private Action action;
        private Color selectedBackgroundColor;
        private Color unSelectedBackgroundColor;

        public Button(int x, int y, int padding, Font.FontType fontType, int fontSize, Color color, Color backgroundColor, Color selectedBackgroundColor, Action action, string content = "") : 
            base(x, y, padding, fontType, fontSize, color, content, backgroundColor)
        {
            this.action = action;
            this.selectedBackgroundColor = selectedBackgroundColor;
            this.unSelectedBackgroundColor = backgroundColor;
        }

        public void Select()
        {
            BackgroundColor = selectedBackgroundColor;
        }
        public void DeSelect()
        {
            BackgroundColor = unSelectedBackgroundColor;
        }

        public void Action()
        {
            action();
        }

        public override void Render()
        {
            base.Render();
        }

        public override void Update()
        {}
    }
}
