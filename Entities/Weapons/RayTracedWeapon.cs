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

        public int Damage => damage;
        public Tracer Tracer { get { return this.tracer; } }

        public float Reach
        {
            get { return this.reach; }
        }

        public static event Action<RayTracedWeapon, Ray> RayTracedWeaponShotAction;
        public RayTracedWeapon(WeaponID weaponID, Mechanism mechanism, int ammo, float cooldown, int damage, OffensiveEntity owner, Tracer tracer, float reach) :
            base(weaponID, mechanism, ammo, cooldown, owner)
        {
            this.damage = damage;
            this.tracer = tracer;
            this.reach = reach;
        }

        protected override void ShootAction(Vector target)
        {
            this.Tracer.Origin = this.Owner.WeaponPosition;
            this.Tracer.End = target;

            Random rnd = new Random();
            Vector direction = target - this.Owner.WeaponPosition + new Vector(rnd.Next(-10,10), rnd.Next(-10, 10));

            if (direction.Length > 0)
                direction.Normalize();

            RayTracedWeaponShotAction?.Invoke(this, new Ray(this.Owner, direction, this.tracer, reach));
        }
    }
}
