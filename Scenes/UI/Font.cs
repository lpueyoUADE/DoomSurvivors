using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Scenes.UI
{
    public static class Font
    {
        public enum FontType
        {
            DoomFont
        }

        private static Dictionary<FontType, string> fontPath = new Dictionary<FontType, string>
        {
            { FontType.DoomFont, "assets/Fonts/DooM.ttf"}
        };

        private static Dictionary<FontType, Dictionary<int, IntPtr>> loadedFonts = new Dictionary<FontType, Dictionary<int, IntPtr>>
        {
            { FontType.DoomFont, new Dictionary<int, IntPtr>{ } }
        };

        public static IntPtr Get(FontType fontType, int fontSize)
        {
            if (!loadedFonts[fontType].ContainsKey(fontSize))
            {
                loadedFonts[fontType].Add(fontSize, Engine.LoadFont(fontPath[fontType], fontSize));
            }
                
            return loadedFonts[fontType][fontSize];
        }
    }
}
