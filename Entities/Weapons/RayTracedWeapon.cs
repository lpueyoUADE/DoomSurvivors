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
        private int raysPerShot;
        private int accuaracy;

        public int Damage => damage;
        public Tracer Tracer { get { return this.tracer; } }

        public float Reach
        {
            get { return this.reach; }
        }

        public static event Action<RayTracedWeapon, Ray> RayTracedWeaponShotAction;
        public RayTracedWeapon(WeaponID weaponID, Mechanism mechanism, AmmoType ammoType, int ammoPerShot, float cooldown,int raysPerShot, int damage, OffensiveEntity owner, Tracer tracer, float reach, Sound shootSound) :
            base(weaponID, mechanism, ammoType, ammoPerShot, cooldown, owner, shootSound)
        {
            this.damage = damage;
            this.tracer = tracer;
            this.reach = reach;
            this.raysPerShot = raysPerShot;
            this.accuaracy = owner is Monster ? 10 : 7;
        }

        protected override void ShootAction(Vector target)
        {
            Random rnd = new Random();

            for (int i = 0; i < raysPerShot; i++)
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
