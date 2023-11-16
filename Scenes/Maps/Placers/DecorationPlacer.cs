using static DoomSurvivors.Entities.Decoration;

namespace DoomSurvivors.Scenes.Maps.Placers
{
    public class DecorationPlacer : Placer<DecorationType>
    {
        public DecorationPlacer(DecorationType placerType, int x, int y) : base(placerType, x, y)
        {
        }
    }
}
