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

    public abstract class Entity
    {
        protected Transform transform;
        protected Vector velocity;
        protected double speed;
        private double movingFriction;
        private double attackingFriction;
        private double minVelocity;
        protected Vector direction;

        protected State state;
        protected bool isAttacking;
        private bool showBoundingBox;
        private bool drawShadow;

        private Shadow shadow;

        private AnimationController animationController;

        public Transform Transform
        {
            get { return this.transform; }
        }

        public Vector Velocity
        {
            get { return this.velocity; }
            set {
                this.velocity = value;
                this.velocity.Normalize();
                this.velocity *= speed;
            }
        }
        public double Speed {
            get { return this.speed; }
        }

        public bool ShowBoundingBox
        {
            get { return this.showBoundingBox; }
            set { this.showBoundingBox = value; }
        }

        public bool DrawShadow
        {
            get { return this.drawShadow; }
            set { this.drawShadow = value; }
        }

        public AnimationController AnimationController
        {
            get { return this.animationController;}
        }

        public State State => this.state;
        public bool IsAttacking => this.isAttacking;

        public double Friction
        {
            get { return this.movingFriction; }
            set { this.movingFriction = value; }
        }

        public Entity(Transform transform, double speed, AnimationController animationController)
        {
            this.transform = transform;
            this.velocity = new Vector(0, 0);
            this.speed = speed;
            this.movingFriction = 0.2f;
            this.attackingFriction = 0.9f;
            this.minVelocity = 0.1f;
            this.state = State.Idle;
            this.isAttacking = false;
            this.animationController = animationController;
            this.drawShadow = true;
            this.shadow = new Shadow(new Sdl.SDL_Color(0,0,0,128), this.transform.W / 3, this.transform.H / 10);
        }

        public bool IsColliding(Entity other)
        {
            return this.transform.isColliding(other.transform);
        }

        protected virtual void render()
        {
            Vector newPosition = Camera.Instance.WorldToCameraPosition(this.transform.Position);

            if (drawShadow)
                this.shadow.Draw((int)newPosition.X + transform.W / 2, (int)newPosition.Y + transform.H);

            if (showBoundingBox)
                Engine.DrawRect(newPosition, Transform.Size, 0xff0000);

            Engine.Draw(animationController.getCurrentAnimationFrame(), (int)newPosition.X, (int)newPosition.Y);
        }

        private void ApplyFriction()
        {
            velocity *= 1 - (isAttacking ? attackingFriction : movingFriction);

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
            if (this.isAttacking)
            {
                this.state = State.Attacking;

            } else if (direction == new Vector(0,0))
            {
                this.state = State.Idle;
            } else
            {
                this.state = State.Moving;
            }
        }

        protected abstract void InputEvents();

        public virtual void Update()
        {
            this.InputEvents();

            if (direction.Length > 0)
                direction.Normalize();

            // Movement is reduced when attacking
            this.velocity += direction * speed * 10  *  Program.DeltaTime;

            this.setState(direction);
            this.animationController.Update(this.state);

            ApplyFriction();

            transform.Position += velocity; 

            render();
        }
    }
}
