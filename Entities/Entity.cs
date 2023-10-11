using DoomSurvivors.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public enum State
    {
        Idle,
        Moving,
        Attacking,
        Dying,
        Gibbing,
        Death,
        GibDeath
    }

    public abstract class Entity
    {
        protected Sdl.SDL_Rect rect;
        protected Vector velocity;
        protected double speed;
        private double friction;
        private double minVelocity;
        protected Vector direction;

        protected State state;
        protected bool isAttacking;
        private bool showBoundingBox;

        private AnimationController animationController;

        public Sdl.SDL_Rect Rect
        {
            get { return this.rect; }
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

        public State State => this.state;
        public bool IsAttacking => this.isAttacking;

        public Entity(Sdl.SDL_Rect rect, double speed, AnimationController animationController)
        {
            this.rect = rect;
            this.velocity = new Vector(0, 0);
            this.speed = speed;
            this.friction = 0.2f;
            this.minVelocity = 0.1f;
            this.state = State.Idle;
            this.isAttacking = false;
            this.animationController = animationController;
        }

        protected virtual void render()
        {
            if (showBoundingBox)
            {
                Engine.DrawRect(this.rect, 0xff0000);
            }
            Engine.Draw(animationController.getCurrentAnimationFrame(), rect.x, rect.y);
        }

        private void ApplyFriction()
        {
            velocity.X *= (1 - friction);
            velocity.Y *= (1 - friction);

            if (Math.Abs(rect.x) < this.minVelocity)
            {
                velocity.X = 0;
            }
            if (Math.Abs(Velocity.Y) < this.minVelocity)
            {
                velocity.Y = 0;
            }
        }

        private void setState(Vector direction)
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

        protected abstract void UpdateDirection();

        public void Update()
        {
            this.direction = new Vector(0, 0);
            this.isAttacking = false;

            this.UpdateDirection();

            if (direction.Length > 0)
            {
                direction.Normalize();
            }

            this.velocity += direction * speed * 10 *  Program.DeltaTime;

            this.setState(direction);
            this.animationController.Update(this.state);

            ApplyFriction();

            rect.x += (short)velocity.X;
            rect.y += (short)velocity.Y;
            render();
        }
    }
}
