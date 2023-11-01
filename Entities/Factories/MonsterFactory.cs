using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows;
using static DoomSurvivors.Entities.Monster;

namespace DoomSurvivors.Entities.Factories
{
    public static class MonsterFactory
    {
        public static Monster CreateMonster(MonsterPlacer monsterPlacer, Entity target = null)
        {
            Monster newMonster;
            switch (monsterPlacer.monsterType)
            {
                case MonsterType.Zombie:
                    newMonster = Zombie((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target); 
                    break;

                case MonsterType.Shotguner:
                    newMonster = Shotguner((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.Chainguner:
                    newMonster = Chainguner((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.Wolfenstein:
                    newMonster = Wolfenstein((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.Imp:
                    newMonster = Imp((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.Pinky:
                    newMonster = Pinky((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.BaronOfHell:
                    newMonster = BaronOfHell((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.HellKnight:
                    newMonster = HellKnight((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.CacoDemon:
                    newMonster = CacoDemon((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.LostSoul:
                    newMonster = LostSoul((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.PainElemental:
                    newMonster = PainElemental((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.Mancubus:
                    newMonster = Mancubus((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.Arachnotron:
                    newMonster = Arachnotron((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.Revenant:
                    newMonster = Revenant((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.ArchVile:
                    newMonster = Archvile((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.SpiderMasterMind:
                    newMonster = SpiderMasterMind((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;
                case MonsterType.CyberDemon:
                    newMonster = CyberDemon((int)monsterPlacer.position.X, (int)monsterPlacer.position.Y, target);
                    break;

                default: throw new ArgumentException("Inexistent Monster Type");
            }

            return newMonster;
        }

        private static Monster Wolfenstein(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster CyberDemon(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster SpiderMasterMind(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster Archvile(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster Revenant(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster Arachnotron(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster Mancubus(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster PainElemental(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster LostSoul(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster CacoDemon(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster HellKnight(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster BaronOfHell(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster Pinky(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster Imp(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster Chainguner(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        private static Monster Shotguner(int x, int y, Entity target)
        {
            throw new NotImplementedException();
        }

        public static Monster Zombie(int x, int y, Entity target=null)
        {
            Monster zombie = new Monster(
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

            zombie.AddWeapon(
                WeaponFactory.RayTracedPistolRed(zombie)
            );

            zombie.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(zombie)
            );

            return zombie;
        }
    }
}
