using DoomSurvivors.Utilities;
using System.Collections.Generic;
using System.Numerics;
using System;
using System.Windows;

namespace DoomSurvivors.Entities.Factories
{
    public static class WeaponFactory
    {
        public static Weapon RayTracedPistolRed(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Pistol,
                Mechanism.Automatic,
                10,
                0.1f,
                owner,
                TracerFactory.RedTracer(),
                100f
            );
        }

        public static Weapon RayTracedPistolYellow(OffensiveEntity owner)
        {
            return new RayTracedWeapon(
                WeaponID.Pistol,
                Mechanism.Automatic,
                10,
                0.1f,
                owner,
                TracerFactory.YellowTracer(),
                100f
            );
        }

        public static Weapon BulletPistolSemiAutomatic(OffensiveEntity owner)
        {
            return new BulletWeapon(
                WeaponID.Pistol,
                Mechanism.SemiAutomatic,
                10,
                0.1f,
                owner,
                new Bullet(
                    new Transform(0, 0, 7, 7),
                    15f,
                    new AnimationController(
                        new Animation(
                            new List<IntPtr>{
                                Engine.LoadImage($"assets/Sprites/Bullets/Pistol/Pistol_1.png"),
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
                10,
                0.1f,
                owner,
                new Bullet(
                    new Transform(0, 0, 7, 7),
                    15f,
                    new AnimationController(
                        new Animation(
                            new List<IntPtr>{
                                Engine.LoadImage($"assets/Sprites/Bullets/Pistol/Pistol_1.png"),
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
