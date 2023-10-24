using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DoomSurvivors.Entities.Factories
{
    public static class MonsterFactory
    {
        public static Monster ZombieMan(int x, int y, Entity target=null)
        {
            Monster zombieMan = new Monster(
                new Transform(x, y, 57, 59),
                5.0f,
                10,
                new Vector(0, 0),
                new AnimationController(
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/Zombie/Zombie_idle_1.png"),
                            Engine.LoadImage($"assets/Sprites/Zombie/Zombie_idle_2.png"),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_moving_1.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_moving_2.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_moving_3.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_moving_4.png"),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_attacking_1.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_attacking_2.png"),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_pain_1.png"),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_dying_1.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_dying_2.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_dying_3.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_dying_4.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_dying_5.png"),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_1.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_2.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_3.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_4.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_5.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_6.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_7.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_8.png"),
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_9.png")
                        },
                        Animation.Speed.slow,
                        true,
                        false
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_dying_5.png"),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage("assets/Sprites/Zombie/Zombie_gibbing_9.png"),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    )
                ),
                null,
                target, // Chasing Target,
                250.0f  // Vision radius
            );

            zombieMan.AddWeapon(
                WeaponFactory.RayTracedPistolRed(zombieMan)
            );

            zombieMan.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(zombieMan)
            );

            return zombieMan;
        }
    }
}
