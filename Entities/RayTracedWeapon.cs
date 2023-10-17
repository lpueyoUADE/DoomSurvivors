using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public class RayTracedWeapon : Weapon
    {
        private Tracer tracer;
        private float reach;
        public Tracer Tracer { get { return this.tracer; } }

        public float Reach
        {
            get { return this.reach; }
        }

        public static event Action<RayTracedWeapon> RayTracedWeaponShotAction;
        public RayTracedWeapon(WeaponID weaponID, Mechanism mechanism, int ammo, float cooldown, OffensiveEntity owner, Tracer tracer, float reach) :
            base(weaponID, mechanism, ammo, cooldown, owner)
        {
            this.tracer = tracer;
            this.reach = reach;
        }

        protected override void ShootAction(Vector target)
        {
            this.Tracer.Origin = this.Owner.WeaponPosition;
            this.Tracer.End = target;
            RayTracedWeaponShotAction(this);
        }
    }
}
