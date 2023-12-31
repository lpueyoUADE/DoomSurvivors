﻿using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Entities.Weapons;
using System;
using System.Windows;

namespace DoomSurvivors.Entities
{
    abstract public class OffensiveEntity : Entity
    {
        protected WeaponController weaponController;
        private Vector weaponOffset;
        private Vector aimingAt;
        private int maxLife;
        private int life;
        private bool isAttacking;
        private readonly float attackingFriction;

        protected Vector WeaponOffset => weaponOffset;
        public bool IsAttacking => this.isAttacking;

        public Vector WeaponPosition => this.transform.Position + this.weaponOffset;
        public Vector AimingAt => this.aimingAt;
        public int Life
        {
            get => this.life;
            set => this.life = value;
        } 

        public int MaxLife
        {
            get => this.maxLife;
            set => this.maxLife = value;
        }

        public bool IsDying => this.State == State.Dying || this.State == State.Gibbing;
        public bool IsDeath => this.State == State.Death || this.State == State.GibDeath;
        public Weapon CurrentWeapon => this.weaponController.CurrentWeapon;

        public bool HasAmmo(AmmoType ammoType, int ammoPerShot)
        {
            return this.weaponController.HasAmmo(ammoType, ammoPerShot);
        }
        public OffensiveEntity(Transform transform, double speed, int life, Vector weaponOffset, AnimationController animationController, WeaponController weaponController = null) :
            base(transform, speed, animationController)
        {
            this.weaponOffset = weaponOffset;
            this.weaponController = weaponController == null ? new WeaponController() : weaponController;
            this.aimingAt = new Vector(0, 0);
            this.life = life;
            this.maxLife = life;
            this.attackingFriction = 0.3f;

            this.IsRayCastCollidable = true;
        }

        private bool GibCondition()
        {
            return this.life <= -this.maxLife / 2;
        }

        override protected void setState(Vector direction)
        {
            if (this.IsDeath)
                return;

            if (life <= 0)
            {
                if (!this.IsDying)
                {
                    if (AnimationController.CanGib && GibCondition())
                        this.State = State.Gibbing;
                    else
                        this.State = State.Dying;
                }
                else if (this.State == State.Gibbing && !this.AnimationController.GibbingAnimation.IsLooping)
                {
                    this.State = State.GibDeath;
                }

                else if (this.State == State.Dying && !this.AnimationController.DyingAnimation.IsLooping)
                {
                    this.State = State.Death;
                }
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

        protected virtual void Die()
        {
            this.CollisionType = CollisionType.Disabled;
        }

        public virtual void ApplyDamage(int damage)
        {
            this.life -= damage;
            if (this.life <= 0)
                Die();
        }

        public void ConsumeAmmo(AmmoType ammoType, int ammoPerShot) {
            this.weaponController.ConsumeAmmo(ammoType, ammoPerShot);
        }
    }
}
