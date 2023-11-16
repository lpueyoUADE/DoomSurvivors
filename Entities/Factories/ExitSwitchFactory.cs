using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Scenes.Maps.Placers;
using System;
using System.Windows;
using static DoomSurvivors.Entities.ExitSwitch;

namespace DoomSurvivors.Entities.Factories
{
    public static class ExitSwitchFactory
    {
        public static ExitSwitch CreateExitSwitch(ExitSwitchPlacer placer)
        {
            ExitSwitch exitSwitch;

            switch (placer.PlacerType)
            {
                case ExitSwitchType.Regular:
                    exitSwitch = Regular(placer.Position);
                    break;

                default:
                    throw new ArgumentException("Inexistent Exit Switch Type");
            }

            return exitSwitch;
        }

        private static ExitSwitch Regular(Vector position)
        {
            Transform transform = new Transform(position, new Vector(Scenes.Maps.Map.TileSize, Scenes.Maps.Map.TileSize));
            return new ExitSwitch(
                transform,
                new Sprite("ExitSwitch", new Transform(70, 3, transform.W, transform.H)),
                new Sprite("ExitSwitch", new Transform(3, 3, transform.W, transform.H))
            );
        }
    }
}
