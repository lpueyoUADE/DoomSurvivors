using DoomSurvivors.Entities.Animations;
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
                    idle: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,51,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(59,51,57,59)),
                        },
                        Animation.Speed.regular,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,51,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(59,51,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(117,51,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(175,51,57,59)),
                        },
                        Animation.Speed.fastest,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(59,366,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,366,57,59)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,681,57,59)),
                        },
                        Animation.Speed.fast,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,681,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,741,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(59,741,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(117,741,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(175,741,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(233,741,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,801,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(59,801,57,59)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    gibbing: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,681,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,876,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(59,876,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(117,876,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(175,876,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(233,876,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(1,936,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(59,936,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(117,936,57,59)),
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(175,936,57,59)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    death: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(59,801,57,59)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    gibDeath: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Player/DoomGuy.png", new Transform(175,936,57,59)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    )
                )
            );

            player.AddWeapon(WeaponFactory.RayTracedPistolYellow(player));
            //player.AddWeapon(WeaponFactory.BulletPistolSemiAutomatic(player));
            //player.AddWeapon(WeaponFactory.BulletPistolAutomatic(player));

            return player;
        }
    }
}
