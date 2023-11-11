using DoomSurvivors.Utilities;
using System;
using System.Runtime.InteropServices;
using Tao.Sdl;

namespace DoomSurvivors.Entities.Animations
{
    public class SpriteReference
    {
        private IntPtr surface;
        private Color colorKey;
        private IntPtr surfaceFormat;

        public IntPtr Surface => surface;
        public Color ColorKey => colorKey;
        public IntPtr SurfaceFormat => surfaceFormat;
      
        public SpriteReference(string path, Color colorKey) {
            this.surface = Engine.LoadImage(path);
            this.colorKey = colorKey;
            Sdl.SDL_SetAlpha(this.surface, 0, 0);
            this.surfaceFormat = Marshal.PtrToStructure<Sdl.SDL_Surface>(this.surface).format;
            Sdl.SDL_SetColorKey(this.surface, Sdl.SDL_SRCCOLORKEY, Sdl.SDL_MapRGB(surfaceFormat, colorKey.R, colorKey.G, colorKey.B));
        }
    }
}
