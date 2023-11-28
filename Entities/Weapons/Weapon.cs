using System;
using System.Windows;

namespace DoomSurvivors.Entities.Weapons
{
    public enum WeaponID
    {
        Chainsaw,
        Pistol,
        Shotgun,
        SuperShotgun,
        Chaingun,
        RocketLauncher,
        PlasmaRifle,
        BFG
    }

    public enum AmmoType
    {
        Bullet,
        Shells,
        Plasma,
        Rocket
    }

    public enum Mechanism
    {
        SemiAutomatic,
        Automatic
    }
    public abstract class Weapon
    {
        private WeaponID weaponID;
        private Mechanism mechanism;
        private AmmoType ammoType;
        private int ammo;
        private int maxAmmo;
        private float cooldown;
        private DateTime lastShotTime;
        private bool hasNeverBeenShot;
        private OffensiveEntity owner;

        private int chamberedBullets;
        private const int MAX_CHAMBERED_BULLETS = 1;

        public Weapon(WeaponID weaponID, Mechanism mechanism, AmmoType ammoType, int ammo, int maxAmmo, float cooldown, OffensiveEntity owner)
        {
            this.weaponID = weaponID;
            this.mechanism = mechanism;
            this.ammoType = ammoType;
            this.ammo = ammo;
            this.maxAmmo = maxAmmo;
            this.cooldown = cooldown;
            this.lastShotTime = DateTime.Now;
            this.hasNeverBeenShot = true;
            this.owner = owner;
            this.chamberedBullets = MAX_CHAMBERED_BULLETS;
        }

        public bool IsSemiAutomatic
        {
            get { return this.mechanism == Mechanism.SemiAutomatic; }
        }

        public bool IsAutomatic
        {
            get { return this.mechanism == Mechanism.Automatic; }
        }

        public bool HasChamberedBullets
        {
            get { return chamberedBullets > 0; }
        }

        public float Cooldown
        {
            get => this.cooldown;
        }

        public DateTime LastShotTime
        {
            get => this.lastShotTime;
        }

        public int Ammo
        {
            get => this.ammo;
        }
        public int MaxAmmo
        {
            get => this.maxAmmo;
        }

        public bool HasAmmo
        {
            get => this.ammo > 0;
        }
        public void ReleaseTrigger()
        {
            this.chamberedBullets = MAX_CHAMBERED_BULLETS;
        }

        public virtual bool IsReadyToShoot
        {
            get {
                float elapsedTime = (float)(DateTime.Now - this.lastShotTime).TotalSeconds;
                bool coolDownRestored = elapsedTime > this.cooldown;
                return HasAmmo && (this.hasNeverBeenShot || ((this.IsAutomatic || (this.IsSemiAutomatic && HasChamberedBullets)) && coolDownRestored));
            }
        }

        public OffensiveEntity Owner
        {
            get { return this.owner; }
        }

        protected abstract void ShootAction(Vector target);
        public void Shoot(Vector target) {
            if(IsReadyToShoot)
            {
                this.hasNeverBeenShot = false;
                this.lastShotTime = DateTime.Now;
                this.chamberedBullets--;
                this.ammo--;
                ShootAction(target);
            }
        }
    }
}
