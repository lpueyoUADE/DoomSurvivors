using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoomSurvivors.Entities.ExitSwitch;

namespace DoomSurvivors.Scenes.Maps.Placers
{
    public class ExitSwitchPlacer : Placer<ExitSwitchType>
    {
        public ExitSwitchPlacer(ExitSwitchType placerType, int x, int y) : base(placerType, x, y)
        {
        }
    }
}
