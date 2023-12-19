using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;

namespace DoomSurvivors.Entities.Weapons
{
    public class WeaponController
    {
        private List<Weapon> weapons;
        private int selectedWeapon;

        private Dictionary<AmmoType, int> ammo;
        private Dictionary<AmmoType, int> ammoMaxCapacity;
        private Dictionary<WeaponID, (AmmoType, int)> ammoPerNewWeapon;
        public Weapon CurrentWeapon => weapons[selectedWeapon];

        public WeaponController()
        {
            this.weapons = new List<Weapon>();
            this.selectedWeapon = 0;

            this.ammo = new Dictionary<AmmoType, int> {
                { AmmoType.Bullet, 50 },
                { AmmoType.Shells, 0 },
                { AmmoType.Rocket, 0 },
                { AmmoType.Plasma, 0 },
                { AmmoType.Infinte, 0 },
            };

            this.ammoMaxCapacity = new Dictionary<AmmoType, int>
            {
                { AmmoType.Bullet, 200 },
                { AmmoType.Shells, 50 },
                { AmmoType.Rocket, 50 },
                { AmmoType.Plasma, 300 },
                { AmmoType.Infinte, 0 },
            };

            this.ammoPerNewWeapon = new Dictionary<WeaponID, (AmmoType, int)> {
                { WeaponID.Chainsaw, (AmmoType.Bullet, 0) },
                { WeaponID.Pistol, (AmmoType.Bullet, 0) },
                { WeaponID.Shotgun , (AmmoType.Shells, 8)},
                { WeaponID.SuperShotgun, (AmmoType.Bullet, 8) },
                { WeaponID.Chaingun, (AmmoType.Bullet, 20) },
                { WeaponID.RocketLauncher , (AmmoType.Rocket, 2)},
                { WeaponID.PlasmaRifle, (AmmoType.Plasma, 40) },
                { WeaponID.BFG, (AmmoType.Plasma, 40) },
                { WeaponID.ImpFireBall, (AmmoType.Infinte, 0)},
                { WeaponID.HellKnightFireBall, (AmmoType.Infinte, 0)},
                { WeaponID.BaronFireBall, (AmmoType.Infinte, 0)},
                { WeaponID.CacoDemonFireBall, (AmmoType.Infinte, 0)},
                { WeaponID.MancubusFireBall, (AmmoType.Infinte, 0)},
                { WeaponID.ReventantRocketLauncher, (AmmoType.Infinte, 0)},
                { WeaponID.ArachnotronPlasmaRifle, (AmmoType.Infinte, 0) },
                { WeaponID.Melee, (AmmoType.Infinte, 0) },
            };
        }

        public void SelectWeapon(WeaponID weaponID) {
            int index = this.weapons.FindIndex(weapon => weaponID == weapon.WeaponID);
            if (index != -1)
            {
                this.selectedWeapon = index;
            }
        }

        internal void AddWeapon(Weapon weapon)
        {
            if (!this.weapons.Contains(weapon))
                this.weapons.Add(weapon);
            
            // this.selectedWeapon = this.weapons.Count - 1;

            AddAmmo(ammoPerNewWeapon[weapon.WeaponID].Item1, ammoPerNewWeapon[weapon.WeaponID].Item2);
        }

        public void AddAmmo(AmmoType ammoType, int amount)
        {
            ammo[ammoType] += (int)Tools.Clamp(amount, 0, ammoMaxCapacity[ammoType]);
        }

        public void ConsumeAmmo(AmmoType ammoType, int amount)
        {
            ammo[ammoType] -= (int)Tools.Clamp(amount, 0, ammoMaxCapacity[ammoType]);
        }

        public bool HasAmmo(AmmoType ammoType, int ammoPerShot)
        {
            return ammoType is AmmoType.Infinte || this.ammo[ammoType] - ammoPerShot >= 0;
        }

        public int GetAmmo(AmmoType ammoType)
        {
            return this.ammo[ammoType];
        }

        public int GetCurrentWeaponAmmo()
        {
            return this.ammo[this.CurrentWeapon.AmmoType];
        }

        public int GetMaxAmmoCapacity(AmmoType ammoType)
        {
            return this.ammoMaxCapacity[ammoType];
        }
    }
}
