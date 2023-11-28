using System.Collections.Generic;
using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Entities.Weapons;

namespace DoomSurvivors.Entities.Factories
{
    public static class WeaponFactory
    {
        public static Weapon Pistol(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Pistol,
                Mechanism.Automatic,
                AmmoType.Bullet,
                ammo: 100,
                maxAmmo: 100,
                cooldown: 0.3f,
                bulletsPerShot: 1,
                damage: 5,
                owner,
                TracerFactory.YellowTracer(),
                300f
            );
        }

        public static Weapon Shotgun(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Shotgun,
                Mechanism.SemiAutomatic,
                AmmoType.Shells,
                ammo: 100,
                maxAmmo: 100,
                cooldown: 0.4f,
                bulletsPerShot: 3,
                damage: 5,
                owner,
                TracerFactory.YellowTracer(),
                300f
            );
        }

        public static Weapon SuperShotgun(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.SuperShotgun,
                Mechanism.SemiAutomatic,
                AmmoType.Shells,
                ammo: 100,
                maxAmmo: 100,
                cooldown: 0.5f,
                bulletsPerShot: 6,
                damage: 5,
                owner,
                TracerFactory.YellowTracer(),
                300f
            );
        }

        public static Weapon Chaingun(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Chaingun,
                Mechanism.Automatic,
                AmmoType.Shells,
                ammo: 100,
                maxAmmo: 100,
                cooldown: 0.2f,
                bulletsPerShot: 1,
                damage: 5,
                owner,
                TracerFactory.YellowTracer(),
                300f
            );
        }

        public static Weapon RayTracedPistolRed(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Pistol,
                Mechanism.Automatic,
                AmmoType.Bullet,
                10,
                100,
                0.5f,
                bulletsPerShot: 1,
                damage: 5,
                owner,
                TracerFactory.RedTracer(),
                200f
            );
        }

        public static Weapon RayTracedPistolYellow(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Pistol,
                Mechanism.Automatic,
                AmmoType.Bullet,
                ammo: 100,
                maxAmmo: 100,
                cooldown: 0.3f,
                bulletsPerShot: 1,
                damage: 5,
                owner,
                TracerFactory.YellowTracer(),
                300f
            );
        }

        public static Weapon BulletPistolSemiAutomatic(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.Pistol,
                Mechanism.SemiAutomatic,
                AmmoType.Bullet,
                10,
                100,
                0.1f,
                owner,
                new Bullet(
                    new Transform(0, 0, 7, 7),
                    15f,
                    new AnimationController(
                        new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(114,27,7,7)),
                            },
                            Animation.Speed.fast,
                            true,
                            false
                        )
                    ),
                    5,
                    owner,
                    0.7f
                )
            );
        }

        public static Weapon BulletPistolAutomatic(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.Pistol,
                Mechanism.Automatic,
                AmmoType.Bullet,
                10,
                100,
                0.1f,
                owner,
                new Bullet(
                    new Transform(0, 0, 7, 7),
                    15f,
                    new AnimationController(
                        new Animation(
                            new List<Sprite>{
                                new Sprite("Proyectiles&Effects", new Transform(114,27,7,7)),
                            },
                            Animation.Speed.fast,
                            true,
                            false
                        )
                    ),
                    5,
                    owner,
                    0.7f
                )
            );
        }
    }
}
