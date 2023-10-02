using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DoomSurvivors
{
    public class Character
    {
        private Transform transform;
        public Transform Transform => transform;
        private float speed;
        private IntPtr image;
        private Animation currentAnimation;
        private Animation idleAnimation;

        public Character(Vector2 pos, float speed, string image)
        {
            transform = new Transform(pos, new Vector2(100, 100));

            this.speed = speed;
            this.image = Engine.LoadImage(image);
            CreateAnimations();
            currentAnimation = idleAnimation;
        }

        private void CreateAnimations()
        {
            List<IntPtr> idleTextures = new List<IntPtr>();
            for (int i = 1; i <= 1; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Sprites/DoomGuy/DoomGuy_idle_{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
        }


        public void Update()
        {
            if (Engine.KeyPress(Engine.KEY_LEFT))
            {
                transform.Translate(new Vector2(-1, 0), speed);
            }
            if (Engine.KeyPress(Engine.KEY_RIGHT))
            {
                transform.Translate(new Vector2(1, 0), speed);
            }
            if (Engine.KeyPress(Engine.KEY_UP))
            {
                transform.Translate(new Vector2(0, -1), speed);
            }
            if (Engine.KeyPress(Engine.KEY_DOWN))
            {
                transform.Translate(new Vector2(0, 1), speed);
            }
            if (Engine.KeyPress(Engine.KEY_ESC)) { }
            currentAnimation.Update();

        }



        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
        }

    }
}
