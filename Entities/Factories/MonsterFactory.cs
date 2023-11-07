using DoomSurvivors.Entities.Animations;
using System;
using System.Collections.Generic;
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
            Monster baronOfHell = new Monster(
                new Transform(x, y, 41, 73),
                3.0f,
                10,
                new Vector(3, 20),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,33,41,73)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,139,49,74)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,33,41,73)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,139,49,74)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,246,41,73)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,353,49,74)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,460,65,70)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,572,69,70)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,675,53,64)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,772,50,72)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,772,50,72)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(44,878,48,73)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(136,878,55,64)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(235,878,56,54)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(335,878,59,36)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(438,878,60,30)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(542,878,60,31)),
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(646,878,60,31)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    gibbing: null,
                    death: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/BaronOfHell.png", new Transform(646,878,60,31)),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    gibDeath: null
                ),
                null,
                target, // Chasing Target,
                250.0f  // Vision radius
            );
            baronOfHell.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(baronOfHell)
            );

            return baronOfHell;
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
            Monster chainguner = new Monster(
                new Transform(x, y, 36, 55),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,33,42,59)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,125,45,60)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,33,42,59)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,125,45,60)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,218,40,59)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,310,45,60)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,494,43,58)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,403,43,58)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,585,43,58)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,585,43,58)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,676,43,61)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(131,676,48,64)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(223,676,59,59)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(326,676,65,49)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(435,676,64,38)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(543,676,65,25)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(652,676,65,21)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,585,43,58)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(44,773,53,59)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(141,773,58,60)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(243,773,64,49)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(351,773,70,41)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(465,773,70,32)),
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(579,773,72,20)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    death: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(652,676,65,21)),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    gibDeath: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Chainguner.png", new Transform(579,773,72,20)),
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

            chainguner.AddWeapon(
                WeaponFactory.RayTracedPistolRed(chainguner)
            );

            chainguner.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(chainguner)
            );

            return chainguner;
        }

        private static Monster Shotguner(int x, int y, Entity target)
        {
            Monster shotguner = new Monster(
                new Transform(x, y, 36, 55),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,33,36,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,130,35,55)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,33,36,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,130,35,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,227,32,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,324,34,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,510,27,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,421,26,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,599,31,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,599,31,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,688,33,60)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(121,688,35,50)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(200,688,42,35)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(286,688,48,27)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(378,688,52,17)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,599,31,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,781,36,59)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(124,781,43,62)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(211,781,48,61)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(303,781,53,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(400,781,55,51)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(499,781,57,43)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(600,781,57,36)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(44,876,57,26)),
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(145,876,57,21)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    death: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(378,688,52,17)),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    gibDeath: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/Shotguner.png", new Transform(145,876,57,21)),
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

            shotguner.AddWeapon(
                WeaponFactory.RayTracedPistolRed(shotguner)
            );

            shotguner.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(shotguner)
            );

            return shotguner;
        }

        public static Monster Zombie(int x, int y, Entity target=null)
        {
            Monster zombie = new Monster(
                new Transform(x, y, 41, 55),
                5.0f,
                10,
                new Vector(3, 20),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,33,41,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,130,37,55)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,33,41,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,130,37,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,227,38,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,324,40,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,510,27,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,421,26,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,599,39,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,688,39,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(127,688,35,46)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(206,688,43,34)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(293,688,48,27)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(385,688,47,17)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,776,41,59)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(129,776,43,62)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(216,776,48,61)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(308,776,53,55)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(405,776,55,51)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(504,776,57,43)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(605,776,57,36)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(44,848,57,26)),
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(145,848,57,21)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    death: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(385,688,47,17)),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    gibDeath: new Animation(
                        new List<Sprite>{
                            Engine.LoadImage("assets/Sprites/Monsters/zombie.png", new Transform(145,848,57,21)),
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
