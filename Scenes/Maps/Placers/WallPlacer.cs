using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoomSurvivors.Entities.Wall;

namespace DoomSurvivors.Scenes.Maps.Placers
{
    public class WallPlacer : Placer<WallType>
    {
        public WallPlacer(WallType placerType, int x, int y) : base(placerType, x, y)
        {
        }
    }
}
