using DoomSurvivors.Main;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
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
        public Vector origin;
        public Vector offset;
        public float maxHaloLength = 200f;

        public bool isDead => remainingLife <= 0;

        public int Damage => damage;

        public Bullet(Transform transform, double speed, AnimationController animationController, int damage, OffensiveEntity owner, float lifespan) : 
            this (transform, speed, animationController, damage, owner, new Vector(0,0), lifespan)
        {}
        public Bullet(Transform transform, double speed, AnimationController animationController, int damage, OffensiveEntity owner, Vector direction, float lifespan) :
            base(transform, speed, animationController)
        {
            this.damage = damage;
            this.owner = owner;
            this.direction = direction;
            this.lifespan = lifespan;
            this.remainingLife = lifespan;

            this.origin = Transform.Position;
            this.offset = new Vector(0, 0);
        }

        protected override void InputEvents()
        {}

        public override void Update()
        {
            remainingLife -= Program.DeltaTime;

            Vector dir = direction;
            dir.Normalize();

            dir *= maxHaloLength;
            Vector distance = Transform.PositionCenter - origin;
            
            Vector begin = origin;

            // Keep the line to a max length
            //if (distance.Length > maxHaloLength)
            //{
            //    Console.WriteLine(distance.Length);
            //    double t = distance.Length / (distance.Length  - (double)maxHaloLength);
            //    begin = new Vector(
            //        (1 - maxHaloLength) * origin.X + t * Transform.PositionCenter.X, 
            //        (1 - maxHaloLength) * origin.Y + t * Transform.PositionCenter.Y);
            //}

            Engine.DrawGradientLine(Camera.Instance.WorldToCameraPosition(begin), Camera.Instance.WorldToCameraPosition(Transform.PositionCenter), new Color(0xff000011), new Color(0xffff00ff), 15);
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

        public bool IsownedBy(Entity entity)
        {
            return ReferenceEquals(this.owner, entity);
        }

        public void Destroy()
        {
            this.remainingLife = 0;
            this.state = State.Dying;
        }
    }
}
