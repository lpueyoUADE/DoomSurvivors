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

        public BulletWeapon(WeaponID weaponID, Mechanism mechanism, int ammo, int maxAmmo, float cooldown, OffensiveEntity owner, Bullet bullet) : base(weaponID, mechanism, ammo, maxAmmo, cooldown, owner)
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
