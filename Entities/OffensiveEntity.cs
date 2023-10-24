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
        private int life;
        private bool isAttacking;
        private readonly float attackingFriction;

        protected Vector WeaponOffset => weaponOffset;
        public bool IsAttacking => this.isAttacking;

        public Vector WeaponPosition => this.transform.Position + this.weaponOffset;
        public Vector AimingAt => this.aimingAt;
        public int Life => this.life;

        public bool IsDying => this.State == State.Dying || this.State == State.Gibbing;
        public bool IsDeath => this.State == State.Death || this.State == State.GibDeath;

        public Weapon CurrentWeapon => this.weaponController.CurrentWeapon;
        public OffensiveEntity(Transform transform, double speed, int life, Vector weaponOffset, AnimationController animationController, WeaponController weaponController = null) :
            base(transform, speed, animationController)
        {
            this.weaponOffset = weaponOffset;
            this.weaponController = weaponController == null ? new WeaponController() : weaponController;
            this.aimingAt = new Vector(0, 0);
            this.life = life;

            this.attackingFriction = 0.5f;
        }

        override protected void setState(Vector direction)
        {
            if (this.IsDeath)
                return;

            if (life <= 0)
            {
                if (this.State != State.Dying || !(this.AnimationController.DyingAnimation is null) && this.AnimationController.DyingAnimation.IsLooping)
                    this.State = State.Dying;
                else
                    this.State = State.Death;
            }
            else
            {
                if (isAttacking)
                {
                    this.State = State.Attacking;
                } else
                {
                    base.setState(direction);
                }
            }
        }

        override public void Update()
        {
            if (this.IsDeath)
            {
                Render();
                return;
            }

            this.isAttacking = false;
            
            if (!(this.AnimationController.AttackingAnimation is null) && this.AnimationController.AttackingAnimation.IsLooping)
            {
                this.ApplyingFriction = attackingFriction;
            } else
            {
                this.ApplyingFriction = MovingFriction;
            }
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

        protected void Die()
        {
            this.CollisionType = CollisionType.Disabled;
        }

        public void ApplyDamage(int damage)
        {
            this.life -= damage;
            if (this.life < 0)
                Die();
        }
    }
}
