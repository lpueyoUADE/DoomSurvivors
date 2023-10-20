using DoomSurvivors.Utilities;
using System.Collections.Generic;
using System.Windows;

namespace DoomSurvivors.Entities
{
    abstract public class OffensiveEntity : Entity
    {
        protected WeaponController weaponController;
        private Vector weaponOffset;
        private Vector aimingAt;
        protected Vector WeaponOffset => weaponOffset;

        public Vector WeaponPosition => this.transform.Position + this.weaponOffset;
        public Vector AimingAt => this.aimingAt;

        public OffensiveEntity(Transform transform, double speed, Vector weaponOffset, AnimationController animationController, WeaponController weaponController=null) : 
            base(transform, speed, animationController)
        {
            this.weaponOffset = weaponOffset;
            this.weaponController = weaponController == null? new WeaponController() : weaponController;
            this.aimingAt = new Vector(-2,-2);
        }

        override public void Update()
        {
            this.isAttacking = false;
            base.Update();
        }

        public void AttackAt(Vector position) {
            this.isAttacking = true;
            this.aimingAt = position;
            this.weaponController.CurrentWeapon.Shoot(position);
        }

        public void AddWeapon(Weapon weapon)
        {
            this.weaponController.AddWeapon(weapon);
        }
    }
}
