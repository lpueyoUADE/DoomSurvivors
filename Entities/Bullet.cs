using DoomSurvivors.Main;
using System;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public class Bullet : Entity
    {
        private int damage;
        private OffensiveEntity owner;
        private float lifespan;
        private float remainingLife;

        public bool isDead => remainingLife <= 0; 

        public Bullet(Transform transform, double speed, AnimationController animationController, int damage, OffensiveEntity owner, Vector direction, float lifespan) :
            base(transform, speed, animationController)
        {
            this.damage = damage;
            this.owner = owner;
            this.direction = direction;
            this.lifespan = lifespan;
            this.remainingLife = lifespan;
        }

        protected override void InputEvents()
        {}

        public override void Update()
        {
            remainingLife -= Program.DeltaTime;
            
            base.Update();
        }

        public Bullet Clone()
        {
            return new Bullet(transform, speed, AnimationController, damage, owner, direction, lifespan);
        }

        public Bullet Clone(Vector position, Vector aimingAt)
        {
            return new Bullet(new Transform(position, transform.Size), speed, AnimationController, damage, owner, aimingAt - position, lifespan);
        }
    }
}
