using System.Windows;

namespace DoomSurvivors.Scenes.Maps.Placers
{
    public class Placer<T>
    {
        private readonly T placerType;
        private Vector position;

        public T PlacerType => placerType;
        public Vector Position => position;

        public Placer(T placerType, int x, int y)
        {
            this.placerType = placerType;
            this.position = new Vector(x, y);
        }
    }
}
