using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public class Crosshair
    {
        private IntPtr sprite;
        private int x, y;

        public Crosshair(bool hideMouse=true)
        {
            this.sprite = Engine.LoadImage("assets/Crosshair/crosshair_3.png");
            if (hideMouse)
                Sdl.SDL_ShowCursor(0);

            this.x = 26;
            this.y = 26;
        }

        public void Update()
        {
            int x, y;
            Sdl.SDL_GetMouseState(out x, out y);
            Engine.Draw(this.sprite, x - this.x / 2, y - this.y / 2, this.x, this.y);
        }
    }
}
