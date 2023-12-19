using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoomSurvivors.Entities.Weapons
{
    internal class BulletWeapon : Weapon
    {

        private Bullet bullet;

        public static event Action<BulletWeapon> BulletWeaponShotAction;

        public BulletWeapon(WeaponID weaponID, Mechanism mechanism, AmmoType ammoType, int ammoPerShot, float cooldown, OffensiveEntity owner, Bullet bullet, Sound shootSound) : base(weaponID, mechanism, ammoType, ammoPerShot, cooldown, owner, shootSound)
        {
            this.bullet = bullet;
        }

        protected override void ShootAction(Vector target)
        {
            
            BulletWeaponShotAction?.Invoke(this);
        }

        public Bullet SpawnBullet()
        {
            return this.bullet.Clone(Owner.WeaponPosition, Owner.AimingAt);
        }
    }
}
