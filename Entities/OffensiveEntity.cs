using DoomSurvivors.Utilities;
using System;
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

        private int life;

        public Vector WeaponPosition => this.transform.Position + this.weaponOffset;
        public Vector AimingAt => this.aimingAt;
        public Weapon CurrentWeapon => this.weaponController.CurrentWeapon;
        public OffensiveEntity(Transform transform, double speed, Vector weaponOffset, AnimationController animationController, WeaponController weaponController=null) : 
            base(transform, speed, animationController)
        {
            this.weaponOffset = weaponOffset;
            this.weaponController = weaponController == null? new WeaponController() : weaponController;
            this.aimingAt = new Vector(-2,-2);
            this.life = 10;
        }

        override protected void setState(Vector direction)
        {
            Console.WriteLine(life);
            Console.WriteLine(state);
            if (state != State.Death)
            {
                if (life <= 0)
                {
                    if (!(this.AnimationController.DeathAnimation is null) && this.AnimationController.DeathAnimation.IsLooping)
                        this.state = State.Dying;
                    else
                        this.state = State.Death;
                }
                else
                {
                    base.setState(direction);
                }
            }
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

        public void ApplyDamage(int damage)
        {
            this.life = 0;
        }
    }
}
