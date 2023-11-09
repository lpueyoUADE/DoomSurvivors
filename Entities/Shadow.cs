using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Sdl;
namespace DoomSurvivors.Entities
{
    public class Shadow
    {
        public enum Shape
        {
            Ellipse,
            Rectangle
        }
        
        private Color color;
        private int rx;
        private int ry;

        private Action<int, int> drawFunction;

        private void DrawEllipse(int x, int y)
        {
            Engine.DrawGradientEllipse(x, y, rx, ry, rx/2, ry/2, new Color(color.R, color.G,color.B,20), color, 3);
        }

        private void DrawRectangle(int x, int y)
        {
            Engine.DrawRect(x-rx,y-ry,rx*2,ry*2, color);
        }
        public Shadow(Color color, int rx, int ry, Shape shape=Shape.Ellipse) {
            this.color = color;
            this.rx = rx;
            this.ry = ry;

            switch (shape)
            {
                case Shape.Ellipse:
                    this.drawFunction = DrawEllipse; 
                    break;

                case Shape.Rectangle:
                    this.drawFunction = DrawRectangle;
                    break;
            }
        }

        public void Draw(int x, int y)
        {
            this.drawFunction(x, y);
        }
    }
}
