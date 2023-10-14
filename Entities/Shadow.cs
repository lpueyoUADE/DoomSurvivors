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
        private Sdl.SDL_Color color;
        private int rx;
        private int ry;

        public Shadow(Sdl.SDL_Color color, int rx, int ry) {
            this.color = color;
            this.rx = rx;
            this.ry = ry;
        }

        public void Draw(int x, int y)
        {
            Engine.DrawFilledEllipse(x,y, rx, ry, color.r, color.g, color.b, 128);
        }
    }
}
