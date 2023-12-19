using System;
using System.Collections.Generic;
using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Entities.Weapons;
using DoomSurvivors.Utilities;

namespace DoomSurvivors.Entities.Factories
{
    public static class WeaponFactory
    {
        
        public static Weapon CreateWeapon(WeaponID weaponID, OffensiveEntity owner)
        {
            Weapon returnWeapon = null;

            switch (weaponID)
            {
                case WeaponID.Pistol:
                    returnWeapon = Pistol(owner);
                    break;
                case WeaponID.Shotgun:
                    returnWeapon = Shotgun(owner);
                    break;
                case WeaponID.SuperShotgun:
                    returnWeapon = SuperShotgun(owner);
                    break;
                case WeaponID.Chaingun:
                    returnWeapon = Chaingun(owner);
                    break;
                case WeaponID.RocketLauncher:
                    returnWeapon = RocketLauncher(owner);
                    break;
                case WeaponID.PlasmaRifle:
                    returnWeapon = PlasmaRifle(owner);
                    break;
                case WeaponID.BFG:
                    returnWeapon = BFG9000(owner);
                    break;
                case WeaponID.Chainsaw:
                    returnWeapon = Chainsaw(owner);
                    break;
                case WeaponID.Melee:
                    returnWeapon = Melee(owner);
                    break;
                case WeaponID.ImpFireBall:
                    returnWeapon = ImpFireBall(owner);
                    break;

                case WeaponID.HellKnightFireBall:
                    returnWeapon = HellKnightFireBall(owner);
                    break;

                case WeaponID.BaronFireBall:
                    returnWeapon = BaronFireBall(owner);
                    break;

                case WeaponID.CacoDemonFireBall:
                    returnWeapon = CacoDemonFireBall(owner);
                    break;

                case WeaponID.MancubusFireBall:
                    returnWeapon = MancubusFireBall(owner);
                    break;

                case WeaponID.ReventantRocketLauncher:
                    returnWeapon = ReventantRocketLauncher(owner);
                    break;

                case WeaponID.ArachnotronPlasmaRifle:
                    returnWeapon = ArachnotronPlasmaRifle(owner);
                    break;

                case WeaponID.CyberDemonRocketLauncher:
                    returnWeapon = CyberDemonRocketLauncher(owner);
                    break;

                case WeaponID.AutomaticPistol:
                    returnWeapon = AutomaticPistol(owner);
                    break;
                case WeaponID.AutomaticShotgun:
                    returnWeapon = AutomaticShotgun(owner);
                    break;
                case WeaponID.AutomaticChaingun:
                    returnWeapon = AutomaticChaingun(owner);
                    break;

                default:
                    throw new ArgumentException("Inexistent Weapon ID");
            }

            return returnWeapon;
        }
        private static Weapon Chainsaw(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Chainsaw,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 0.5f,
                raysPerShot: 1,
                damage: 200,
                owner,
                TracerFactory.YellowTracer(),
                75f,
                new Sound("assets/Sounds/Weapons/DSSAWFUL.wav")
            );
        }

        private static Weapon Pistol(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Pistol,
                Mechanism.SemiAutomatic,
                AmmoType.Bullet,
                1,
                cooldown: 0.4f,
                raysPerShot: 1,
                damage: 10,
                owner,
                TracerFactory.YellowTracer(),
                500f,
                new Sound("assets/Sounds/Weapons/DSPISTOL.wav")
            );
        }

        private static Weapon Shotgun(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Shotgun,
                Mechanism.SemiAutomatic,
                AmmoType.Shells,
                1,
                cooldown: 1f,
                raysPerShot: 3,
                damage: 20,
                owner,
                TracerFactory.YellowTracer(),
                400f,
                new Sound("assets/Sounds/Weapons/DSSHOTGN.wav")
            );
        }

        private static Weapon SuperShotgun(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.SuperShotgun,
                Mechanism.SemiAutomatic,
                AmmoType.Shells,
                2,
                cooldown: 1.5f,
                raysPerShot: 6,
                damage: 25,
                owner,
                TracerFactory.YellowTracer(),
                200f,
                new Sound("assets/Sounds/Weapons/DSDSHTGN_ALL_SOUNDS.wav")
            );
        }

        private static Weapon Chaingun(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Chaingun,
                Mechanism.Automatic,
                AmmoType.Bullet,
                1,
                cooldown: 0.1f,
                raysPerShot: 1,
                damage: 20,
                owner,
                TracerFactory.YellowTracer(),
                400f,
                new Sound("assets/Sounds/Weapons/DSPISTOL.wav")
            );
        }

        private static Weapon RocketLauncher(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.RocketLauncher,
                Mechanism.SemiAutomatic,
                AmmoType.Rocket,
                1,
                cooldown: 1.5f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 15, 14),
                    15f,
                    new AnimationController(
                        new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(137,393,15,14))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    250,
                    owner,
                    5f,
                    new Color(0xff000000),
                    new Color(0xff0000ff),
                    wallHitParticle: ParticleType.RocketLauncherHit,
                    entityHitParticle: ParticleType.RocketLauncherHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSBAREXP.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSRLAUNC.wav")
            );
        }

        private static Weapon PlasmaRifle(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.PlasmaRifle,
                Mechanism.Automatic,
                AmmoType.Plasma,
                1,
                cooldown: 0.1f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 13, 13),
                    45f,
                    new AnimationController(
                        idle: new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(3,437,15,14)),
                                new Sprite("Proyectiles&Effects", new Transform(2,438,13,13))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    45,
                    owner,
                    1f,
                    new Color(0x00ffff11),
                    new Color(0x0000ffff),
                    wallHitParticle: ParticleType.PlasmaHit,
                    entityHitParticle: ParticleType.PlasmaHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSFIRXPL.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSPLASMA.wav",32)
            );
        }

        private static Weapon BFG9000(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.BFG,
                Mechanism.SemiAutomatic,
                AmmoType.Plasma,
                50,
                cooldown: 5f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 45, 45),
                    12f,
                    new AnimationController(
                        new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(4,523,45,45)),
                                new Sprite("Proyectiles&Effects", new Transform(52,523,45,45))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    1500,
                    owner,
                    5f,
                    new Color(0x00ffff11),
                    new Color(0x00ff00ff),
                    wallHitParticle: ParticleType.BFGHit,
                    entityHitParticle: ParticleType.BFGHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSFIRXPL.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSBFG.wav", 32)
            );
        }

        /* Enemies Weapons */
        private static Weapon RayTracedPistolRed(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Pistol,
                Mechanism.Automatic,
                AmmoType.Bullet,
                1,
                0.5f,
                raysPerShot: 1,
                damage: 5,
                owner,
                TracerFactory.RedTracer(),
                200f, 
                new Sound("assets/Sounds/Weapons/DSPISTOL.wav")
            );
        }

        private static Weapon BulletPistolAutomatic(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.Pistol,
                Mechanism.Automatic,
                AmmoType.Bullet,
                1,
                0.1f,
                owner,
                new Bullet(
                    new Transform(0, 0, 7, 7),
                    15f,
                    new AnimationController(
                        new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(158,347,7,7)),
                            },
                            Animation.Speed.fast,
                            true,
                            false
                        )
                    ),
                    5,
                    owner,
                    0.7f,
                    new Color(0xff000011),
                    new Color(0xffff00ff),
                    wallHitParticle: ParticleType.WallHit,
                    entityHitParticle: ParticleType.Blood,
                    deathSound: new Sound("assets/Sounds/Weapons/DSFIRXPL.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSPISTOL.wav")
            ); ;
        }

        private static Weapon Melee(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Melee,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 0.5f,
                raysPerShot: 1,
                damage: 40,
                owner,
                TracerFactory.InvicibleTracer(),
                75f,
                new Sound("assets/Sounds/Weapons/DSCLAW.wav")
            );
        }

        private static Weapon ImpFireBall(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.ImpFireBall,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 0.5f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 15, 15),
                    15f,
                    new AnimationController(
                        idle: new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(3,64,15,15)),
                                new Sprite("Proyectiles&Effects", new Transform(21,64,15,15))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    24,
                    owner,
                    5f,
                    new Color(0xff000011),
                    new Color(0xffff00ff),
                    wallHitParticle: ParticleType.ImpFireBallHit,
                    entityHitParticle: ParticleType.ImpFireBallHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSFIRXPL.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSFIRSHT.wav", 32)
            );
        }
        private static Weapon HellKnightFireBall(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.HellKnightFireBall,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 0.5f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 19, 16),
                    20f,
                    new AnimationController(
                        idle: new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(3,681,19,16)),
                                new Sprite("Proyectiles&Effects", new Transform(25,681,20,16))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    50,
                    owner,
                    5f,
                    new Color(0x00ff0011),
                    new Color(0x00ff00ff),
                    wallHitParticle: ParticleType.HellKnightFireBallHit,
                    entityHitParticle: ParticleType.HellKnightFireBallHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSFIRXPL.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSFIRSHT.wav", 32)
            );
        }

        private static Weapon BaronFireBall(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.BaronFireBall,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 0.5f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 19, 16),
                    25f,
                    new AnimationController(
                        idle: new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(3,681,19,16)),
                                new Sprite("Proyectiles&Effects", new Transform(25,681,20,16))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    60,
                    owner,
                    5f,
                    new Color(0x00ff0011),
                    new Color(0x00ff00ff),
                    wallHitParticle: ParticleType.BaronFireBallHit,
                    entityHitParticle: ParticleType.BaronFireBallHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSFIRXPL.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSFIRSHT.wav", 32)
            );
        }

        private static Weapon CacoDemonFireBall(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.CacoDemonFireBall,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 0.5f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 16, 16),
                    20f,
                    new AnimationController(
                        idle: new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(3,114,16,16)),
                                new Sprite("Proyectiles&Effects", new Transform(22,115,15,15))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    50,
                    owner,
                    5f,
                    new Color(0xff000011),
                    new Color(0xff00ffff),
                    wallHitParticle: ParticleType.CacoDemonFireBallHit,
                    entityHitParticle: ParticleType.CacoDemonFireBallHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSFIRXPL.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSFIRSHT.wav", 32)
            );
        }

        private static Weapon ReventantRocketLauncher(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.ReventantRocketLauncher,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 0.5f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 19, 16),
                    20f,
                    new AnimationController(
                        idle: new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(3,701,19,16)),
                                new Sprite("Proyectiles&Effects", new Transform(25,700,20,16))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    5,
                    owner,
                    0.7f,
                    new Color(0xff000011),
                    new Color(0xff0000ff),
                    wallHitParticle: ParticleType.ReventantRocketLauncherHit,
                    entityHitParticle: ParticleType.ReventantRocketLauncherHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSBAREXP.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSSKEATK.wav", 32)
            );
        }

        private static Weapon ArachnotronPlasmaRifle(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.ArachnotronPlasmaRifle,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 0.5f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 15, 15),
                    30f,
                    new AnimationController(
                        idle: new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(3,339,15,15)),
                                new Sprite("Proyectiles&Effects", new Transform(21,341,13,13))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    30,
                    owner,
                    0.7f,
                    new Color(0x00ff0011),
                    new Color(0x00ff00ff),
                    wallHitParticle: ParticleType.ArachnotronPlasmaRifleHit,
                    entityHitParticle: ParticleType.ArachnotronPlasmaRifleHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSFIRXPL.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSPLASMA.wav", 32)
            );
        }
        private static Weapon MancubusFireBall(OffensiveEntity owner)
        {
            return new BulletWeapon(
                 WeaponID.MancubusFireBall,
                 Mechanism.Automatic,
                 AmmoType.Infinte,
                 1,
                 cooldown: 0.5f,
                 owner,
                  new Bullet(
                     new Transform(0, 0, 34, 34),
                     20f,
                     new AnimationController(
                         idle: new Animation(
                             new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(3,356,34,34)),
                                new Sprite("Proyectiles&Effects", new Transform(40,356,34,34))
                             },
                             Animation.Speed.regular,
                             true,
                             false
                         )
                     ),
                     50,
                     owner,
                     3f,
                     new Color(0xff000011),
                     new Color(0xff0000ff),
                     wallHitParticle: ParticleType.MancubusFireBallHit,
                     entityHitParticle: ParticleType.MancubusFireBallHit,
                     deathSound: new Sound("assets/Sounds/Weapons/DSFIRXPL.wav")
                 ),
                 new Sound("assets/Sounds/Weapons/DSFIRSHT.wav", 32)
             );
        }
        private static Weapon CyberDemonRocketLauncher(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.ReventantRocketLauncher,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown:0.9f,
                owner,
                 new Bullet(
                    new Transform(0, 0, 19, 16),
                    20f,
                    new AnimationController(
                        idle: new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(137,393,15,14))
                            },
                            Animation.Speed.regular,
                            true,
                            false
                        )
                    ),
                    80,
                    owner,
                    5f,
                    new Color(0xff000011),
                    new Color(0xff0000ff),
                    wallHitParticle: ParticleType.RocketLauncherHit,
                    entityHitParticle: ParticleType.RocketLauncherHit,
                    deathSound: new Sound("assets/Sounds/Weapons/DSBAREXP.wav")
                ),
                new Sound("assets/Sounds/Weapons/DSSKEATK.wav", 32)
            );
        }
        private static Weapon AutomaticChaingun(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
               WeaponID.Chaingun,
               Mechanism.Automatic,
               AmmoType.Infinte,
               1,
               cooldown: 0.2f,
               raysPerShot: 1,
               damage: 5,
               owner,
               TracerFactory.RedTracer(),
               400f,
               new Sound("assets/Sounds/Weapons/DSPISTOL.wav")
           );
        }

        private static Weapon AutomaticShotgun(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Shotgun,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 1f,
                raysPerShot: 2,
                damage: 5,
                owner,
                TracerFactory.RedTracer(),
                500f,
                new Sound("assets/Sounds/Weapons/DSPISTOL.wav")
            );
        }
        private static Weapon AutomaticPistol(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Pistol,
                Mechanism.Automatic,
                AmmoType.Infinte,
                1,
                cooldown: 0.4f,
                raysPerShot: 1,
                damage: 5,
                owner,
                TracerFactory.RedTracer(),
                500f,
                new Sound("assets/Sounds/Weapons/DSPISTOL.wav")
            );
        }


    }
}
