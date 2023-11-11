
using DoomSurvivors.Entities.Animations;
using System;
using System.Collections.Generic;
using System.Windows;
using static DoomSurvivors.Entities.Particle;

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

                default:
                    throw new ArgumentException("Inexistent particle Type");
            }

            return newParticle;
        }


        public static Particle BloodParticle(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                            new Sprite("Proyectiles&Effects", new Transform(1,511,5,6)),
                            new Sprite("Proyectiles&Effects", new Transform(7,509,8,8)),
                            new Sprite("Proyectiles&Effects", new Transform(16,506,12,11)),
                        },
                        0.05f,
                        false,
                        false
                )
            );
        }

        public static Particle WallHitParticle(Vector origin)
        {
            return new Particle(
                origin,
                new Animation(
                    new List<Sprite>{
                            new Sprite("Proyectiles&Effects", new Transform(1,971,5,5)),
                            new Sprite("Proyectiles&Effects", new Transform(7,968,9,8)),
                            new Sprite("Proyectiles&Effects", new Transform(17,965,12,11)),
                            new Sprite("Proyectiles&Effects", new Transform(30,961,15,15)),
                        },
                        0.05f,
                        false,
                        false
                )
            );
        }
    }
}
