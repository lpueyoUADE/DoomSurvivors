using System.Collections.Generic;

namespace DoomSurvivors.Scenes.Maps
{
    public class JSONMapLayer
    {
        public List<int> data { get; set; }

        public int height {  get; set; }
        public int id {get; set; }
        public string name { get; set; }
        public int opacity { get; set; }
        public string type { get; set; }
        public bool visible {  get; set; }
        public int width {  get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}
