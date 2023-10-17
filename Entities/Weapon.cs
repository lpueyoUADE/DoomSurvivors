using System;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public enum WeaponID
    {
        Chainsaw,
        Pistol,
        Shotgun,
        SuperShotgun,
        Minigun,
        RocketLauncher,
        PlasmaRifle,
        BFG
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
        private int ammo;
        private float cooldown;
        private DateTime lastShotTime;
        private bool hasNeverBeenShot;
        private bool isHoldingTrigger;
        private OffensiveEntity owner;

        public Weapon(WeaponID weaponID, Mechanism mechanism, int ammo, float cooldown, OffensiveEntity owner)
        {
            this.weaponID = weaponID;
            this.mechanism = mechanism;
            this.ammo = ammo;
            this.cooldown = cooldown;
            this.lastShotTime = DateTime.Now;
            this.hasNeverBeenShot = true;
            this.isHoldingTrigger = false;
            this.owner = owner;
        }

        public bool IsSemiAutomatic
        {
            get { return this.mechanism == Mechanism.SemiAutomatic; }
        }

        public bool IsAutomatic
        {
            get { return this.mechanism == Mechanism.Automatic; }
        }

        public bool IsHoldingTrigger
        {
            get { return this.isHoldingTrigger; }
            set { this.isHoldingTrigger = value; }
        }

        public virtual bool IsReadyToShoot
        {
            get {
                float elapsedTime = (float)(DateTime.Now - this.lastShotTime).TotalSeconds;
                return this.hasNeverBeenShot || ((this.IsAutomatic || (this.IsSemiAutomatic && !this.IsHoldingTrigger)) && elapsedTime > this.cooldown);
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
                // Console.WriteLine("PUM");
                this.lastShotTime = DateTime.Now;

                ShootAction(target);
            }
        }
    }
}
