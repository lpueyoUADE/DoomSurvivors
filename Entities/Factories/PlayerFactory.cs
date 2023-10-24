using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DoomSurvivors.Entities.Factories
{
    public static class PlayerFactory
    {
        public static Player Player(int x, int y)
        {
            Player player = new Player(
                new Transform(x, y, 57, 59),
                8.0f,
                10,
                new Vector(19, 25),
                new AnimationController(
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/DoomGuy_idle_1.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/DoomGuy_idle_2.png"),
                        },
                        Animation.Speed.regular,
                        true,
                        true
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_moving_1.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_moving_2.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_moving_3.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_moving_4.png"),
                        },
                        Animation.Speed.fastest,
                        true,
                        true
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_attacking_2.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_attacking_1.png"),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_pain_1.png"),
                        },
                        Animation.Speed.fast,
                        true,
                        false
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_dying_1.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_dying_2.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_dying_3.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_dying_4.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_dying_5.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_dying_6.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_dying_7.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_dying_8.png"),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_1.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_2.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_3.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_4.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_5.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_6.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_7.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_8.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_9.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_10.png"),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_dying_8.png"),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                     new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_gibbing_10.png"),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    )
                )
            );

            player.AddWeapon(WeaponFactory.RayTracedPistolYellow(player));
            player.AddWeapon(WeaponFactory.BulletPistolSemiAutomatic(player));

            return player;
        }
    }
}
