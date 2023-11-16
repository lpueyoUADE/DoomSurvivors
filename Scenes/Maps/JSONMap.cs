using System.Collections.Generic;

namespace DoomSurvivors.Scenes.Maps
{
    public class JSONMap
    {

        public int compressionlevel { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public bool infinite { get; set; }
        public List<JSONMapLayer> layers { get; set; }

        public int nextlayerid { get; set; }
        public int nextobjectid { get; set; }
        public string orientation { get; set; }
        public string renderorder { get; set; }
        public string tiledversion { get; set; }
        public int tileheight { get; set; }
        public int tilewidth { get; set; }
        public List<JSONTileset> tilesets { get; set; }
        public string type { get; set; }
        public string version { get; set; }
    }
}
