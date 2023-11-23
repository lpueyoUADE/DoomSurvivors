using DoomSurvivors.Entities;
using DoomSurvivors.Utilities;
using System.Numerics;

namespace DoomSurvivors.Scenes.UI
{
    public abstract class UIElement : IRenderizable
    {
        private Transform transform;
        private int padding;
        private Color backgroundColor;

        public Transform Transform { 
            get { return transform; } 
            set {  transform = value; }
        }

        public int Padding
        {
            get { return padding; }
            set { padding = value; }
        }

        public Color BackgroundColor
        {
            get { return backgroundColor;}
            set { backgroundColor = value; }
        }

        public UIElement(int x, int y, int padding, Color backgroundColor=null) {
            this.transform = new Transform(x,y,0,0);
            this.padding = padding;
            this.backgroundColor = backgroundColor;
        }

        public abstract void Render();
        public abstract void Update();
    }
}
