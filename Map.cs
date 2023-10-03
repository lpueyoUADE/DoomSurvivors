using System;
using Tao.Sdl;

namespace DoomSurvivors
{
    public class Map
    {
        private string name;
        private IntPtr mapTexture;

        public Map(string name, IntPtr mapTexture)
        {
            this.name = name;
            this.mapTexture = mapTexture;
        }

        public void Draw()
        {
            Engine.Draw(mapTexture, 0, 0);
        }
    }
}
