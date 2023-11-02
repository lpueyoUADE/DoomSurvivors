using DoomSurvivors.Main;
using DoomSurvivors.Viewport;
using System;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public enum State
    {
        Idle,
        Moving,
        Attacking,
        Pain,
        Dying,
        Gibbing,
        Death,
        GibDeath
    }

    public abstract class Entity: GameObject
    {
        protected Vector velocity;
        protected double speed;
        protected const float MovingFriction = 0.2f;
        private float applyingFriction;
        private double minVelocity = 0.1f;
        protected Vector direction;

        private State state;

        private AnimationController animationController;

        public Vector Velocity
        {
            get { return this.velocity; }
            set {
                this.velocity = value;
                this.velocity.Normalize();
                this.velocity *= speed;
            }
        }

        public AnimationController AnimationController
        {
            get { return this.animationController;}
        }

        public State State { 
            get { return this.state; } 
            set { this.state = value; } 
        }
        public float ApplyingFriction
        {
            get { return this.applyingFriction; }
            set { this.applyingFriction = value; }
        }

        public bool IsMoving => this.velocity.Length > 0; 

        public Entity(Transform transform, double speed, AnimationController animationController) : base(transform)
        {
            this.velocity = new Vector(0, 0);
            this.speed = speed;
            this.state = State.Idle;
            this.applyingFriction = MovingFriction;

            this.animationController = animationController;

            this.CollisionType = CollisionType.Kinematic;
        }

        override public void OnCollision(GameObject other)
        {
            if (other is Entity)
            { 
                Vector distance = other.Transform.PositionCenter - this.Transform.PositionCenter;
                if (this.CollisionType == CollisionType.Kinematic)
                    this.Velocity -= distance / 3;

                if(other.CollisionType == CollisionType.Kinematic)
                    ((Entity)other).Velocity += distance / 3;
            }
            
            base.OnCollision(other);
        }

        protected override IntPtr GetCurrentSprite()
        {
            return animationController.getCurrentAnimationFrame();
        }

        protected void ApplyFriction()
        {
            velocity *= 1 - applyingFriction;

            if (Math.Abs(velocity.X) < this.minVelocity)
            {
                velocity.X = 0;
            }
            if (Math.Abs(Velocity.Y) < this.minVelocity)
            {
                velocity.Y = 0;
            }
        }

        protected virtual void setState(Vector direction)
        {           
            if (direction == new Vector(0,0))
            {
                this.state = State.Idle;
            } else
            {
                this.state = State.Moving;
            }
        }

        protected abstract void InputEvents();

        override public void Update()
        {
            base.Update();
            this.InputEvents();

            if (direction.Length > 0)
                direction.Normalize();

            this.velocity += direction * speed * 10  * Program.DeltaTime;

            this.setState(direction);
            this.animationController.Update(this.state);

            ApplyFriction();

            transform.Position += velocity;
        }
    }
}
