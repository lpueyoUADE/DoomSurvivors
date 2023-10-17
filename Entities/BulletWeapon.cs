using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoomSurvivors.Entities
{
    internal class BulletWeapon : Weapon
    {
        public static event Action<BulletWeapon> BulletWeaponShotAction;
        public BulletWeapon(WeaponID weaponID, Mechanism mechanism, int ammo, float cooldown, OffensiveEntity owner) : base(weaponID, mechanism, ammo, cooldown, owner)
        {
        }

        protected override void ShootAction(Vector target)
        {
            BulletWeaponShotAction(this);
        }
    }
}
