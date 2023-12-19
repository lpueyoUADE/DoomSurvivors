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
        BFG,
        Melee,
        /* Enemies */
        ImpFireBall,
        HellKnightFireBall,
        BaronFireBall,
        CacoDemonFireBall,
        MancubusFireBall,
        ReventantRocketLauncher,
        ArachnotronPlasmaRifle,
        CyberDemonRocketLauncher,
        AutomaticPistol,
        AutomaticShotgun,
        AutomaticChaingun,
    }

    public enum AmmoType
    {
        Bullet,
        Shells,
        Plasma,
        Rocket,
        Infinte
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
        private int ammoPerShot;
        private float cooldown;
        private DateTime lastShotTime;
        private bool hasNeverBeenShot;
        private OffensiveEntity owner;

        private Sound shootSound;
        private Sound noAmmoSound;

        private int chamberedBullets;
        private const int MAX_CHAMBERED_BULLETS = 1;

        public WeaponID WeaponID
        {
            get => this.weaponID;
        }

        public AmmoType AmmoType
        { 
            get => this.ammoType; 
        }

        public override bool Equals(Object obj)
        {
            return ((Weapon)obj).WeaponID == WeaponID;
        }
        public Weapon(WeaponID weaponID, Mechanism mechanism, AmmoType ammoType, int ammoPerShot, float cooldown, OffensiveEntity owner, Sound shootSound)
        {
            this.weaponID = weaponID;
            this.mechanism = mechanism;
            this.ammoType = ammoType;
            this.ammoPerShot = ammoPerShot;
            this.cooldown = cooldown;
            this.lastShotTime = DateTime.Now;
            this.hasNeverBeenShot = true;
            this.owner = owner;
            this.chamberedBullets = MAX_CHAMBERED_BULLETS;
            this.shootSound = shootSound;
            this.noAmmoSound = new Sound("assets/Sounds/Weapons/DSDBOPN.wav");
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
        public bool HasAmmo
        {
            get => this.owner.HasAmmo(this.ammoType, this.ammoPerShot);
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
                this.owner.ConsumeAmmo(this.ammoType, this.ammoPerShot);
                ShootAction(target);
                this.shootSound.PlayOnce();
            }
        }

        public void PlayNoAmmoSound()
        {
            this.noAmmoSound.PlayOnce();
        }
    }
}
