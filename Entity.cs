using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors
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

    class Entity
    {
        private Sdl.SDL_Rect rect;
        private Vector velocity;
        private double speed;
        private double friction;
        private double minVelocity;

        private State state;
        private bool isAttacking;
        private bool playerControlled;
        private bool showBoundingBox;
        private bool showVisionRadius;

        private AnimationController animationController;

        private Entity target;
        private double visionRadius;

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

        public bool PlayerControlled
        {
            get { return this.playerControlled; }
            set { this.playerControlled = value; }
        }

        public bool ShowBoundingBox
        {
            get { return this.showBoundingBox; }
            set { this.showBoundingBox = value; }
        }

        public bool ShowVisionRadius
        {
            get { return this.showVisionRadius; }
            set { this.showVisionRadius = value; }
        }

        public State State => this.state;
        public bool IsAttacking => this.isAttacking;

        // TODO Implement Monster and Player child classes
        public Entity(Sdl.SDL_Rect rect, double speed, AnimationController animationController, Entity target=null, double visionRadius=0f)
        {
            this.rect = rect;
            this.velocity = new Vector(0, 0);
            this.speed = speed;
            this.friction = 0.2f;
            this.minVelocity = 0.1f;
            this.state = State.Idle;
            this.isAttacking = false;
            this.playerControlled = false;
            this.animationController = animationController;
            this.target = target;
            this.visionRadius = visionRadius;
        }
        private void render()
        {

            if (showBoundingBox)
            {
                Engine.DrawRect(this.rect, 0xff0000);
            }

            if (showVisionRadius)
            {
                Engine.DrawCirle(this.rect.x + this.rect.w / 2, this.rect.y + this.rect.h / 2, (int)this.visionRadius, 0, 255, 0, 255);
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

        public void Update()
        {
            Vector direction = new Vector(0, 0);
            this.isAttacking = false;

            if (playerControlled)
            {
                if (Engine.KeyPress(Engine.KEY_D))
                {
                    direction.X = 1;
                }
                if (Engine.KeyPress(Engine.KEY_A))
                {
                    direction.X = -1;
                }
                if (Engine.KeyPress(Engine.KEY_W))
                {
                    direction.Y = -1;
                }
                if (Engine.KeyPress(Engine.KEY_S))
                {
                    direction.Y = 1;
                }

                if (Engine.MousePress(Engine.MOUSEBUTTON_LEFT))
                {
                    this.isAttacking = true;
                }

                if (Engine.MousePress(Engine.MOUSEBUTTON_RIGHT))
                {
                }
            }
            else
            {
                Vector distance = Vector.Subtract(new Vector(this.target.Rect.x, this.target.Rect.y), new Vector(this.rect.x, this.rect.y));
                if(distance.Length <= this.visionRadius)
                {
                    direction = distance;
                }
            }
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
