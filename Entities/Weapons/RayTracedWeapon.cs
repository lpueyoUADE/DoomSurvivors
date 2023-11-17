using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Entities.Weapons
{
    public class RayTracedWeapon : Weapon
    {
        private int damage;
        private Tracer tracer;
        private float reach;
        private int bulletsPerShot;
        private int accuaracy;
        public int Damage => damage;
        public Tracer Tracer { get { return this.tracer; } }

        public float Reach
        {
            get { return this.reach; }
        }

        public static event Action<RayTracedWeapon, Ray> RayTracedWeaponShotAction;
        public RayTracedWeapon(WeaponID weaponID, Mechanism mechanism, int ammo, float cooldown,int bulletsPerShot, int damage, OffensiveEntity owner, Tracer tracer, float reach) :
            base(weaponID, mechanism, ammo, cooldown, owner)
        {
            this.damage = damage;
            this.tracer = tracer;
            this.reach = reach;
            this.bulletsPerShot = bulletsPerShot;
            this.accuaracy = 5;
        }

        protected override void ShootAction(Vector target)
        {
            Random rnd = new Random();
            for (int i = 0; i < bulletsPerShot; i++)
            {
                this.Tracer.Origin = this.Owner.WeaponPosition;
                this.Tracer.End = target;

                Vector direction = (target - this.Owner.WeaponPosition);

                if (direction.Length > 0)
                    direction.Normalize();

                direction = direction + new Vector(rnd.NextDouble() / accuaracy, rnd.NextDouble() / accuaracy);
                direction.Normalize();

                RayTracedWeaponShotAction?.Invoke(this, new Ray(this.Owner, direction, this.tracer, reach));
            }
        }
    }
}
