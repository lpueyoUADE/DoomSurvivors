using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoomSurvivors.Entities.Monster;

namespace DoomSurvivors.Scenes.Maps.Placers
{
    public class MonsterPlacer : Placer<MonsterType>
    {
        public MonsterPlacer(MonsterType placerType, int x, int y) : base(placerType, x, y)
        {
        }
    }
}
