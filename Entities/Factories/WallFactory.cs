using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Scenes.Maps;
using DoomSurvivors.Scenes.Maps.Placers;
using System;
using static DoomSurvivors.Entities.Wall;

namespace DoomSurvivors.Entities.Factories
{
    public static class WallFactory
    {
        public static Wall CreateWall(WallPlacer wallPlacer)
        {
            Wall wall;
            switch(wallPlacer.PlacerType)
            {
                case WallType.TestWall:
                    wall = TestWall((int)wallPlacer.Position.X, (int)wallPlacer.Position.Y);
                    break;

                default:
                    throw new ArgumentException("Inexistent Wall Type");

            }

            return wall;
        }

        private static Wall TestWall(int x, int y)
        {
            Transform transform = new Transform(x, y, 64, 64);
            return new Wall(transform, new Sprite("Walls", new Transform(0,0,transform.W, transform.H)));
        }
    }
}
