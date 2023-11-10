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
            Monster wolfenstein = new Monster(
                new Transform(x, y, 29, 56),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            new Sprite("Wolfenstein", new Transform(44,33,29,56)),
                            new Sprite("Wolfenstein", new Transform(44,122,28,55)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("Wolfenstein", new Transform(44,33,29,56)),
                            new Sprite("Wolfenstein", new Transform(44,122,28,55)),
                            new Sprite("Wolfenstein", new Transform(44,212,25,54)),
                            new Sprite("Wolfenstein", new Transform(44,300,28,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("Wolfenstein", new Transform(185,390,25,55)),
                            new Sprite("Wolfenstein", new Transform(116,390,25,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("Wolfenstein", new Transform(44,478,33,53)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("Wolfenstein", new Transform(44,478,33,53)),
                            new Sprite("Wolfenstein", new Transform(121,478,29,54)),
                            new Sprite("Wolfenstein", new Transform(194,478,33,46)),
                            new Sprite("Wolfenstein", new Transform(271,478,40,42)),
                            new Sprite("Wolfenstein", new Transform(355,478,40,27)),
                            new Sprite("Wolfenstein", new Transform(439,478,51,16)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: new Animation(
                        new List<Sprite>{
                            new Sprite("Wolfenstein", new Transform(121,478,29,54)),
                            new Sprite("Wolfenstein", new Transform(44,565,37,59)),
                            new Sprite("Wolfenstein", new Transform(125,565,44,62)),
                            new Sprite("Wolfenstein", new Transform(213,565,48,61)),
                            new Sprite("Wolfenstein", new Transform(305,565,53,55)),
                            new Sprite("Wolfenstein", new Transform(402,565,55,50)),
                            new Sprite("Wolfenstein", new Transform(501,565,57,42)),
                            new Sprite("Wolfenstein", new Transform(44,660,57,35)),
                            new Sprite("Wolfenstein", new Transform(145,660,57,25)),
                            new Sprite("Wolfenstein", new Transform(246,660,57,20)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("Wolfenstein", new Transform(439,478,51,16)),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    gibDeath: new Animation(
                        new List<Sprite>{
                            new Sprite("Wolfenstein", new Transform(246,660,57,20)),
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

            wolfenstein.AddWeapon(
                WeaponFactory.RayTracedPistolRed(wolfenstein)
            );

            wolfenstein.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(wolfenstein)
            );

            return wolfenstein;
        }

        private static Monster CyberDemon(int x, int y, Entity target)
        {
            Monster cyberdemon = new Monster(
                new Transform(x, y, 82, 108),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            new Sprite("CyberDemon", new Transform(44,33,82,108)),
                            new Sprite("CyberDemon", new Transform(44,176,85,109)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("CyberDemon", new Transform(44,33,82,108)),
                            new Sprite("CyberDemon", new Transform(44,176,85,109)),
                            new Sprite("CyberDemon", new Transform(44,319,82,110)),
                            new Sprite("CyberDemon", new Transform(44,464,85,109)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("CyberDemon", new Transform(44,751,99,110)),
                            new Sprite("CyberDemon", new Transform(44,608,86,110)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("CyberDemon", new Transform(44,894,123,110)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("CyberDemon", new Transform(44,1038,122,111)),
                            new Sprite("CyberDemon", new Transform(210,1038,111,113)),
                            new Sprite("CyberDemon", new Transform(365,1038,100,116)),
                            new Sprite("CyberDemon", new Transform(509,1038,113,117)),
                            new Sprite("CyberDemon", new Transform(666,1038,125,124)),
                            new Sprite("CyberDemon", new Transform(835,1038,136,131)),
                            new Sprite("CyberDemon", new Transform(1015,1038,141,134)),
                            new Sprite("CyberDemon", new Transform(1200,1038,139,134)),
                            new Sprite("CyberDemon", new Transform(1383,1038,120,30)),

                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: null,

                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("CyberDemon", new Transform(1383,1038,120,30)),
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

            cyberdemon.AddWeapon(
                WeaponFactory.RayTracedPistolRed(cyberdemon)
            );

            cyberdemon.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(cyberdemon)
            );

            return cyberdemon;
        }

        private static Monster SpiderMasterMind(int x, int y, Entity target)
        {
            Monster spiderMasterMind = new Monster(
                new Transform(x, y, 195, 110),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            new Sprite("SpiderMasterMind", new Transform(44,33,195,110)),
                            new Sprite("SpiderMasterMind", new Transform(44,182,215,109)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("SpiderMasterMind", new Transform(44,33,195,110)),
                            new Sprite("SpiderMasterMind", new Transform(44,182,215,109)),
                            new Sprite("SpiderMasterMind", new Transform(44,326,192,108)),
                            new Sprite("SpiderMasterMind", new Transform(44,458,215,109)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("SpiderMasterMind", new Transform(44,1037,194,106)),
                            new Sprite("SpiderMasterMind", new Transform(44,887,194,106)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("SpiderMasterMind", new Transform(44,1187,197,107)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("SpiderMasterMind", new Transform(44,1187,197,107)),
                            new Sprite("SpiderMasterMind", new Transform(44,1476,179,104)),
                            new Sprite("SpiderMasterMind", new Transform(267,1476,188,97)),
                            new Sprite("SpiderMasterMind", new Transform(499,1476,184,89)),
                            new Sprite("SpiderMasterMind", new Transform(727,1476,182,78)),
                            new Sprite("SpiderMasterMind", new Transform(953,1476,186,74)),
                            new Sprite("SpiderMasterMind", new Transform(44,1590,189,70)),
                            new Sprite("SpiderMasterMind", new Transform(277,1590,192,87)),
                            new Sprite("SpiderMasterMind", new Transform(513,1590,211,92)),
                            new Sprite("SpiderMasterMind", new Transform(768,1590,215,114)),
                            new Sprite("SpiderMasterMind", new Transform(1027,1590,184,38)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: null,

                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("SpiderMasterMind", new Transform(1027,1590,184,38)),
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

            spiderMasterMind.AddWeapon(
                WeaponFactory.RayTracedPistolRed(spiderMasterMind)
            );

            spiderMasterMind.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(spiderMasterMind)
            );

            return spiderMasterMind;
        }

        private static Monster Archvile(int x, int y, Entity target)
        {
            Monster archVile = new Monster(
                new Transform(x, y, 32, 76),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            new Sprite("ArchVile", new Transform(44,33,32,76)),
                            new Sprite("ArchVile", new Transform(44,142,48,75)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("ArchVile", new Transform(44,33,32,76)),
                            new Sprite("ArchVile", new Transform(44,142,48,75)),
                            new Sprite("ArchVile", new Transform(44,250,50,75)),
                            new Sprite("ArchVile", new Transform(167,250,48,75)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("ArchVile", new Transform(44,359,73,93)),
                            new Sprite("ArchVile", new Transform(44,496,79,96)),
                            new Sprite("ArchVile", new Transform(44,633,79,97)),
                            new Sprite("ArchVile", new Transform(44,771,59,80)),
                            new Sprite("ArchVile", new Transform(44,894,55,63)),
                            new Sprite("ArchVile", new Transform(44,993,55,60)),
                            new Sprite("ArchVile", new Transform(44,1089,55,60)),
                            new Sprite("ArchVile", new Transform(44,1185,54,68)),
                            new Sprite("ArchVile", new Transform(44,1288,54,79)),
                            new Sprite("ArchVile", new Transform(44,1400,54,90)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("ArchVile", new Transform(44,1523,38,74)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("ArchVile", new Transform(44,1523,38,74)),
                            new Sprite("ArchVile", new Transform(44,1631,38,80)),
                            new Sprite("ArchVile", new Transform(126,1631,47,76)),
                            new Sprite("ArchVile", new Transform(217,1631,55,70)),
                            new Sprite("ArchVile", new Transform(316,1631,67,58)),
                            new Sprite("ArchVile", new Transform(427,1631,73,47)),
                            new Sprite("ArchVile", new Transform(544,1631,74,37)),
                            new Sprite("ArchVile", new Transform(662,1631,74,25)),
                            new Sprite("ArchVile", new Transform(780,1631,74,22)),
                            new Sprite("ArchVile", new Transform(898,1631,74,22)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: null,

                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("ArchVile", new Transform(898,1631,74,22)),
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

            archVile.AddWeapon(
                WeaponFactory.RayTracedPistolRed(archVile)
            );

            archVile.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(archVile)
            );

            return archVile;
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
            Monster cacoDemon = new Monster(
                new Transform(x, y, 63, 66),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            new Sprite("CacoDemon", new Transform(44,33,63,66)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("CacoDemon", new Transform(44,33,63,66)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("CacoDemon", new Transform(44,443,63,67)),
                            new Sprite("CacoDemon", new Transform(44,133,63,65)),
                            new Sprite("CacoDemon", new Transform(44,233,63,69)),
                            new Sprite("CacoDemon", new Transform(44,335,63,71)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("CacoDemon", new Transform(44,544,63,67)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("CacoDemon", new Transform(44,544,63,67)),
                            new Sprite("CacoDemon", new Transform(44,645,63,67)),
                            new Sprite("CacoDemon", new Transform(151,645,63,67)),
                            new Sprite("CacoDemon", new Transform(258,645,63,67)),
                            new Sprite("CacoDemon", new Transform(365,645,67,77)),
                            new Sprite("CacoDemon", new Transform(476,645,69,66)),
                            new Sprite("CacoDemon", new Transform(589,645,75,49)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    gibbing: null,

                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("CacoDemon", new Transform(589,645,75,49)),
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

            cacoDemon.AddWeapon(
                WeaponFactory.RayTracedPistolRed(cacoDemon)
            );

            cacoDemon.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(cacoDemon)
            );

            return cacoDemon;
        }

        private static Monster HellKnight(int x, int y, Entity target)
        {
            Monster hellKnight = new Monster(
                new Transform(x, y, 41, 73),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            new Sprite("HellKnight", new Transform(44,33,41,73)),
                            new Sprite("HellKnight", new Transform(44,140,49,74)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("HellKnight", new Transform(44,33,41,73)),
                            new Sprite("HellKnight", new Transform(44,140,49,74)),
                            new Sprite("HellKnight", new Transform(129,33,41,73)),
                            new Sprite("HellKnight", new Transform(127,141,49,74)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("HellKnight", new Transform(44,247,65,70)),
                            new Sprite("HellKnight", new Transform(44,359,69,70)),
                            new Sprite("HellKnight", new Transform(44,462,53,64)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("HellKnight", new Transform(44,559,50,72)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("HellKnight", new Transform(44,559,50,72)),
                            new Sprite("HellKnight", new Transform(44,665,48,73)),
                            new Sprite("HellKnight", new Transform(136,665,55,64)),
                            new Sprite("HellKnight", new Transform(235,665,56,54)),
                            new Sprite("HellKnight", new Transform(335,665,59,36)),
                            new Sprite("HellKnight", new Transform(438,665,60,30)),
                            new Sprite("HellKnight", new Transform(542,665,60,31)),
                            new Sprite("HellKnight", new Transform(646,665,60,31)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: null,

                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("HellKnight", new Transform(646,665,60,31)),
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

            hellKnight.AddWeapon(
                WeaponFactory.RayTracedPistolRed(hellKnight)
            );

            hellKnight.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(hellKnight)
            );

            return hellKnight;
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
                            new Sprite("BaronOfHell", new Transform(44,33,41,73)),
                            new Sprite("BaronOfHell", new Transform(44,139,49,74)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("BaronOfHell", new Transform(44,33,41,73)),
                            new Sprite("BaronOfHell", new Transform(44,139,49,74)),
                            new Sprite("BaronOfHell", new Transform(44,246,41,73)),
                            new Sprite("BaronOfHell", new Transform(44,353,49,74)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("BaronOfHell", new Transform(44,460,65,70)),
                            new Sprite("BaronOfHell", new Transform(44,572,69,70)),
                            new Sprite("BaronOfHell", new Transform(44,675,53,64)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("BaronOfHell", new Transform(44,772,50,72)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("BaronOfHell", new Transform(44,772,50,72)),
                            new Sprite("BaronOfHell", new Transform(44,878,48,73)),
                            new Sprite("BaronOfHell", new Transform(136,878,55,64)),
                            new Sprite("BaronOfHell", new Transform(235,878,56,54)),
                            new Sprite("BaronOfHell", new Transform(335,878,59,36)),
                            new Sprite("BaronOfHell", new Transform(438,878,60,30)),
                            new Sprite("BaronOfHell", new Transform(542,878,60,31)),
                            new Sprite("BaronOfHell", new Transform(646,878,60,31)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    gibbing: null,
                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("BaronOfHell", new Transform(646,878,60,31)),
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
            Monster pinky = new Monster(
                new Transform(x, y, 40, 56),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            new Sprite("Pinky", new Transform(44,33,40,56)),
                            new Sprite("Pinky", new Transform(44,122,43,58)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("Pinky", new Transform(44,33,40,56)),
                            new Sprite("Pinky", new Transform(44,122,43,58)),
                            new Sprite("Pinky", new Transform(44,214,40,55)),
                            new Sprite("Pinky", new Transform(44,302,43,58)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("Pinky", new Transform(44,393,44,55)),
                            new Sprite("Pinky", new Transform(44,481,44,55)),
                            new Sprite("Pinky", new Transform(44,569,44,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("Pinky", new Transform(44,660,39,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("Pinky", new Transform(44,660,39,55)),
                            new Sprite("Pinky", new Transform(44,748,54,56)),
                            new Sprite("Pinky", new Transform(142,748,60,56)),
                            new Sprite("Pinky", new Transform(246,748,52,53)),
                            new Sprite("Pinky", new Transform(342,748,62,57)),
                            new Sprite("Pinky", new Transform(448,748,64,46)),
                            new Sprite("Pinky", new Transform(556,748,64,32)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: null,

                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("Pinky", new Transform(556,748,64,32)),
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

            pinky.AddWeapon(
                WeaponFactory.RayTracedPistolRed(pinky)
            );

            pinky.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(pinky)
            );

            return pinky;
        }

        private static Monster Imp(int x, int y, Entity target)
        {
            Monster imp = new Monster(
                new Transform(x, y, 41, 57),
                5.0f,
                10,
                new Vector(4, 21),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            new Sprite("Imp", new Transform(44,33,41,57)),
                            new Sprite("Imp", new Transform(44,123,39,56)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("Imp", new Transform(44,33,41,57)),
                            new Sprite("Imp", new Transform(44,123,39,56)),
                            new Sprite("Imp", new Transform(44,213,39,60)),
                            new Sprite("Imp", new Transform(44,306,37,57)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("Imp", new Transform(44,396,49,60)),
                            new Sprite("Imp", new Transform(44,489,44,55)),
                            new Sprite("Imp", new Transform(44,577,32,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("Imp", new Transform(44,665,41,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("Imp", new Transform(44,665,41,55)),
                            new Sprite("Imp", new Transform(44,755,42,62)),
                            new Sprite("Imp", new Transform(130,755,41,59)),
                            new Sprite("Imp", new Transform(215,755,40,54)),
                            new Sprite("Imp", new Transform(299,755,48,46)),
                            new Sprite("Imp", new Transform(391,755,58,22)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: new Animation(
                        new List<Sprite>{
                            new Sprite("Imp", new Transform(44,665,41,55)),
                            new Sprite("Imp", new Transform(44,850,46,59)),
                            new Sprite("Imp", new Transform(134,850,49,61)),
                            new Sprite("Imp", new Transform(227,850,55,61)),
                            new Sprite("Imp", new Transform(326,850,57,61)),
                            new Sprite("Imp", new Transform(427,850,57,44)),
                            new Sprite("Imp", new Transform(528,850,57,34)),
                            new Sprite("Imp", new Transform(629,850,56,31)),
                            new Sprite("Imp", new Transform(729,850,56,18)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("Imp", new Transform(391,755,58,22)),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    gibDeath: new Animation(
                        new List<Sprite>{
                            new Sprite("Imp", new Transform(729,850,56,18)),
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

            imp.AddWeapon(
                WeaponFactory.RayTracedPistolRed(imp)
            );

            imp.AddWeapon(
                WeaponFactory.BulletPistolAutomatic(imp)
            );

            return imp;
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
                            new Sprite("Chainguner", new Transform(44,33,42,59)),
                            new Sprite("Chainguner", new Transform(44,125,45,60)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("Chainguner", new Transform(44,33,42,59)),
                            new Sprite("Chainguner", new Transform(44,125,45,60)),
                            new Sprite("Chainguner", new Transform(44,218,40,59)),
                            new Sprite("Chainguner", new Transform(44,310,45,60)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("Chainguner", new Transform(44,494,43,58)),
                            new Sprite("Chainguner", new Transform(44,403,43,58)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("Chainguner", new Transform(44,585,43,58)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("Chainguner", new Transform(44,585,43,58)),
                            new Sprite("Chainguner", new Transform(44,676,43,61)),
                            new Sprite("Chainguner", new Transform(131,676,48,64)),
                            new Sprite("Chainguner", new Transform(223,676,59,59)),
                            new Sprite("Chainguner", new Transform(326,676,65,49)),
                            new Sprite("Chainguner", new Transform(435,676,64,38)),
                            new Sprite("Chainguner", new Transform(543,676,65,25)),
                            new Sprite("Chainguner", new Transform(652,676,65,21)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: new Animation(
                        new List<Sprite>{
                            new Sprite("Chainguner", new Transform(44,585,43,58)),
                            new Sprite("Chainguner", new Transform(44,773,53,59)),
                            new Sprite("Chainguner", new Transform(141,773,58,60)),
                            new Sprite("Chainguner", new Transform(243,773,64,49)),
                            new Sprite("Chainguner", new Transform(351,773,70,41)),
                            new Sprite("Chainguner", new Transform(465,773,70,32)),
                            new Sprite("Chainguner", new Transform(579,773,72,20)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("Chainguner", new Transform(652,676,65,21)),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    gibDeath: new Animation(
                        new List<Sprite>{
                            new Sprite("Chainguner", new Transform(579,773,72,20)),
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
                            new Sprite("Shotguner", new Transform(44,33,36,55)),
                            new Sprite("Shotguner", new Transform(44,130,35,55)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("Shotguner", new Transform(44,33,36,55)),
                            new Sprite("Shotguner", new Transform(44,130,35,55)),
                            new Sprite("Shotguner", new Transform(44,227,32,55)),
                            new Sprite("Shotguner", new Transform(44,324,34,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("Shotguner", new Transform(44,510,27,55)),
                            new Sprite("Shotguner", new Transform(44,421,26,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("Shotguner", new Transform(44,599,31,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("Shotguner", new Transform(44,599,31,55)),
                            new Sprite("Shotguner", new Transform(44,688,33,60)),
                            new Sprite("Shotguner", new Transform(121,688,35,50)),
                            new Sprite("Shotguner", new Transform(200,688,42,35)),
                            new Sprite("Shotguner", new Transform(286,688,48,27)),
                            new Sprite("Shotguner", new Transform(378,688,52,17)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: new Animation(
                        new List<Sprite>{
                            new Sprite("Shotguner", new Transform(44,599,31,55)),
                            new Sprite("Shotguner", new Transform(44,781,36,59)),
                            new Sprite("Shotguner", new Transform(124,781,43,62)),
                            new Sprite("Shotguner", new Transform(211,781,48,61)),
                            new Sprite("Shotguner", new Transform(303,781,53,55)),
                            new Sprite("Shotguner", new Transform(400,781,55,51)),
                            new Sprite("Shotguner", new Transform(499,781,57,43)),
                            new Sprite("Shotguner", new Transform(600,781,57,36)),
                            new Sprite("Shotguner", new Transform(44,876,57,26)),
                            new Sprite("Shotguner", new Transform(145,876,57,21)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("Shotguner", new Transform(378,688,52,17)),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    gibDeath: new Animation(
                        new List<Sprite>{
                            new Sprite("Shotguner", new Transform(145,876,57,21)),
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

        public static Monster Zombie(int x, int y, Entity target = null)
        {
            Monster zombie = new Monster(
                new Transform(x, y, 41, 55),
                5.0f,
                10,
                new Vector(3, 20),
                new AnimationController(
                    idle: new Animation(
                        new List<Sprite>{
                            new Sprite("Zombie", new Transform(44,33,41,55)),
                            new Sprite("Zombie", new Transform(44,130,37,55)),
                        },
                        Animation.Speed.slow,
                        true,
                        true
                    ),
                    moving: new Animation(
                        new List<Sprite>{
                            new Sprite("Zombie", new Transform(44,33,41,55)),
                            new Sprite("Zombie", new Transform(44,130,37,55)),
                            new Sprite("Zombie", new Transform(44,227,38,55)),
                            new Sprite("Zombie", new Transform(44,324,40,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        true
                    ),
                    attacking: new Animation(
                        new List<Sprite>{
                            new Sprite("Zombie", new Transform(44,510,27,55)),
                            new Sprite("Zombie", new Transform(44,421,26,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    pain: new Animation(
                        new List<Sprite>{
                            new Sprite("Zombie", new Transform(44,599,39,55)),
                        },
                        Animation.Speed.faster,
                        true,
                        false
                    ),
                    dying: new Animation(
                        new List<Sprite>{
                            new Sprite("Zombie", new Transform(44,599,39,55)),
                            new Sprite("Zombie", new Transform(44,688,39,55)),
                            new Sprite("Zombie", new Transform(127,688,35,46)),
                            new Sprite("Zombie", new Transform(206,688,43,34)),
                            new Sprite("Zombie", new Transform(293,688,48,27)),
                            new Sprite("Zombie", new Transform(385,688,47,17)),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    ),
                    gibbing: new Animation(
                        new List<Sprite>{
                            new Sprite("Zombie", new Transform(44,599,39,55)),
                            new Sprite("Zombie", new Transform(44,776,41,59)),
                            new Sprite("Zombie", new Transform(129,776,43,62)),
                            new Sprite("Zombie", new Transform(216,776,48,61)),
                            new Sprite("Zombie", new Transform(308,776,53,55)),
                            new Sprite("Zombie", new Transform(405,776,55,51)),
                            new Sprite("Zombie", new Transform(504,776,57,43)),
                            new Sprite("Zombie", new Transform(605,776,57,36)),
                            new Sprite("Zombie", new Transform(44,848,57,26)),
                            new Sprite("Zombie", new Transform(145,848,57,21)),
                        },
                        Animation.Speed.fastest,
                        false,
                        false
                    ),
                    death: new Animation(
                        new List<Sprite>{
                            new Sprite("Zombie", new Transform(385,688,47,17)),
                        },
                        Animation.Speed.slow,
                        false,
                        false
                    ),
                    gibDeath: new Animation(
                        new List<Sprite>{
                            new Sprite("Zombie", new Transform(145,848,57,21)),
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