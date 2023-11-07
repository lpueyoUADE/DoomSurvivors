using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoomSurvivors.Entities.Wall;

namespace DoomSurvivors.Entities.Factories
{
    public static class WallFactory
    {
        public static Wall CreateWall(WallPlacer wallPlacer)
        {
            Wall wall;
            switch(wallPlacer.wallType)
            {
                case WallType.TestWall:
                    wall = TestWall((int)wallPlacer.position.X, (int)wallPlacer.position.Y);
                    break;

                default:
                    throw new ArgumentException("Inexistent Wall Type");

            }

            return wall;
        }

        private static Wall TestWall(int x, int y)
        {
            Transform transform = new Transform(x, y, 64, 64);
            return new Wall(transform, Engine.LoadImage("assets/Sprites/Walls/wall_001.png", new Transform(0,0,transform.W, transform.H)));
        }
    }
}
