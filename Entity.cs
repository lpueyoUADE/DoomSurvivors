using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors
{
    class Entity
    {
        private Sdl.SDL_Rect rect;
        private Vector velocity;
        private double speed;
        private double friction;

        private bool playerControlled;
        private bool showBoundingBox;

        private IntPtr frame;

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

        public Entity(Sdl.SDL_Rect rect, double speed)
        {
            this.rect = rect;
            this.velocity = new Vector(0, 0);
            this.speed = speed;
            this.friction = 0.2f;

            frame = Engine.LoadImage($"assets/Sprites/Zombie/Zombie_idle_1.png");
        }
        private void render()
        {

            if (showBoundingBox)
            {
                Engine.DrawRect(this.rect, 0xff0000);
            }
            Engine.Draw(frame, rect.x, rect.y);
        }

        private void ApplyFriction()
        {
            velocity.X *= (1 - friction);
            velocity.Y *= (1 - friction);

            float minVelocity = 0.1f;
            if (Math.Abs(rect.x) < minVelocity)
            {
                velocity.X = 0;
            }
            if (Math.Abs(Velocity.Y) < minVelocity)
            {
                velocity.Y = 0;
            }
        }
        public void Update()
        {
            Vector direction = new Vector(0, 0);

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
            }

            if (direction.Length > 0)
            {
                direction.Normalize();
            }

            this.velocity += direction * speed * 10 *  Program.DeltaTime;

            ApplyFriction();

            rect.x += (short)velocity.X;
            rect.y += (short)velocity.Y;
            render();
        }
    }
}
