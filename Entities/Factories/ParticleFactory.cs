
using DoomSurvivors.Entities.Animations;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DoomSurvivors.Entities.Factories
{
    public static class ParticleFactory
    {
        public static Particle CreateParticle(ParticleType particleType, Vector origin) {

            Particle newParticle;

            switch (particleType)
            {
                case ParticleType.Blood:
                    newParticle = BloodParticle(origin);
                    break;

                case ParticleType.WallHit:
                    newParticle = WallHitParticle(origin);
                    break;

                case ParticleType.RocketLauncherHit:
                    newParticle = RocketLauncherHitParticle(origin);
                    break;

                case ParticleType.PlasmaHit:
                    newParticle = PlasmaParticle(origin);
                    break;

                case ParticleType.BFGHit:
                    newParticle = BFGHitParticle(origin);
                    break;

                case ParticleType.ImpFireBallHit:
                    newParticle = ImpFireBallHit(origin);
                    break;

                case ParticleType.HellKnightFireBallHit:
                    newParticle = HellKnightFireBallHit(origin);
                    break;

                case ParticleType.BaronFireBallHit:
                    newParticle = BaronFireBallHit(origin);
                    break;

                case ParticleType.CacoDemonFireBallHit:
                    newParticle = CacoDemonFireBallHit(origin);
                    break;

                case ParticleType.ReventantRocketLauncherHit:
                    newParticle = ReventantRocketLauncherHit(origin);
                    break;

                case ParticleType.ArachnotronPlasmaRifleHit:
                    newParticle = ArachnotronPlasmaRifleHit(origin);
                    break;

                case ParticleType.MancubusFireBallHit:
                    newParticle = MancubusFireBallHit(origin);
                    break;

                default:
                    throw new ArgumentException("Inexistent particle Type");
            }

            return newParticle;
        }
        private static Particle BloodParticle(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                            new Sprite("Proyectiles&Effects", new Transform(3,26,5,6)),
                            new Sprite("Proyectiles&Effects", new Transform(11,24,8,8)),
                            new Sprite("Proyectiles&Effects", new Transform(22,21,12,11)),
                        },
                        0.05f,
                        false,
                        false
                )
            );
        }

        private static Particle WallHitParticle(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                            new Sprite("Proyectiles&Effects", new Transform(3,13,5,5)),
                            new Sprite("Proyectiles&Effects", new Transform(11,10,9,8)),
                            new Sprite("Proyectiles&Effects", new Transform(23,7,12,11)),
                            new Sprite("Proyectiles&Effects", new Transform(38,3,15,15)),
                        },
                        0.05f,
                        false,
                        false
                )
            );
        }

        private static Particle BFGHitParticle(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                        new Sprite("Proyectiles&Effects", new Transform(101,518,63,50)),
                        new Sprite("Proyectiles&Effects", new Transform(167,498,80,70)),
                        new Sprite("Proyectiles&Effects", new Transform(250,454,143,114)),
                        new Sprite("Proyectiles&Effects", new Transform(3,571,134,29)),
                        new Sprite("Proyectiles&Effects", new Transform(140,593,133,7)),
                    },
                    0.05f,
                    false,
                    false
                )
            );
        }

        private static Particle PlasmaParticle(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                        new Sprite("Proyectiles&Effects", new Transform(38,428,23,23)),
                        new Sprite("Proyectiles&Effects", new Transform(64,410,39,41)),
                        new Sprite("Proyectiles&Effects", new Transform(106,416,37,35)),
                        new Sprite("Proyectiles&Effects", new Transform(146,422,29,29))
                    },
                    0.05f,
                    false,
                    false
                )
            );
        }

        private static Particle RocketLauncherHitParticle(Vector origin)
        {
            return new Particle(
               origin,
               new Animation(
                   new List<Sprite>{
                        new Sprite("Proyectiles&Effects", new Transform(3,159,73,60)),
                        new Sprite("Proyectiles&Effects", new Transform(77,147,89,72)),
                        new Sprite("Proyectiles&Effects", new Transform(168,133,106,86))
                   },
                   0.05f,
                   false,
                   false
               )
           );
        }

        private static Particle ImpFireBallHit(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                        new Sprite("Proyectiles&Effects", new Transform(39,44,37,35)),
                        new Sprite("Proyectiles&Effects", new Transform(79,40,43,39)),
                        new Sprite("Proyectiles&Effects", new Transform(125,35,50,44))
                    },
                    0.05f,
                    false,
                    false
                )
            );
        }

        private static Particle HellKnightFireBallHit(Vector origin)
        {
            return new Particle(
               origin,
               new Animation(
                   new List<Sprite>{
                        new Sprite("Proyectiles&Effects", new Transform(291,663,33,33)),
                        new Sprite("Proyectiles&Effects", new Transform(327,660,41,36)),
                        new Sprite("Proyectiles&Effects", new Transform(371,656,45,40))
                   },
                   0.05f,
                   false,
                   false
               )
           );
        }

        private static Particle BaronFireBallHit(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                new List<Sprite>{
                    new Sprite("Proyectiles&Effects", new Transform(291,663,33,33)),
                    new Sprite("Proyectiles&Effects", new Transform(327,660,41,36)),
                    new Sprite("Proyectiles&Effects", new Transform(371,656,45,40))
                },
                0.05f,
                false,
                false
               )
           );
        }

        private static Particle CacoDemonFireBallHit(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                        new Sprite("Proyectiles&Effects", new Transform(40,82,45,48)),
                        new Sprite("Proyectiles&Effects", new Transform(88,88,50,42)),
                        new Sprite("Proyectiles&Effects", new Transform(141,83,53,47))
                    },
                    0.05f,
                    false,
                    false
                )
            );
        }

        private static Particle ReventantRocketLauncherHit(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                        new Sprite("Proyectiles&Effects", new Transform(39,44,37,35)),
                        new Sprite("Proyectiles&Effects", new Transform(79,40,43,39)),
                        new Sprite("Proyectiles&Effects", new Transform(125,35,50,44))
                    },
                    0.05f,
                    false,
                    false
                )
            );
        }

        private static Particle ArachnotronPlasmaRifleHit(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                        new Sprite("Proyectiles&Effects", new Transform(37,331,23,23)),
                        new Sprite("Proyectiles&Effects", new Transform(63,321,37,33)),
                        new Sprite("Proyectiles&Effects", new Transform(103,325,29,29)),
                        new Sprite("Proyectiles&Effects", new Transform(135,334,20,20)),
                        new Sprite("Proyectiles&Effects", new Transform(158,347,7,7)),
                    },
                    0.05f,
                    false,
                    false
                )
            );
        }
        private static Particle MancubusFireBallHit(Vector origin)
        {
            return new Particle(
               origin,
               new Animation(
                   new List<Sprite>{
                        new Sprite("Proyectiles&Effects", new Transform(39,44,37,35)),
                        new Sprite("Proyectiles&Effects", new Transform(79,40,43,39)),
                        new Sprite("Proyectiles&Effects", new Transform(125,35,50,44))
                   },
                   0.05f,
                   false,
                   false
               )
           );
        }
    }
}
