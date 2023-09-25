using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors
{
    public class Enemy
    {
        private Vector2 position;
        private Character player = Program.player;

        float speed;
        IntPtr image;
        Animation currentAnimation;
        Animation idleAnimation;
        private Vector2 scale;
        public Vector2 Position => position;
        public Vector2 Scale => scale;

        public Enemy(float x, float y, float speed)
        {
            position = new Vector2(x, y);

            this.speed = speed;
            CreateAnimations();
            currentAnimation = idleAnimation;
            this.scale.x = 67;
            this.scale.y = 100;
        }

        private void CreateAnimations()
        {
            List<IntPtr> idleTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Enemy/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation("Idle", idleTextures, 0.1f, true);
        }

        public void Update()
        {
            float distanceX = Math.Abs((player.Transform.Position.x + (player.Transform.Scale.x / 2)) - (position.x + (scale.x / 2)));
            float distanceY = Math.Abs((player.Transform.Position.y + (player.Transform.Scale.y / 2)) - (position.y + (scale.y / 2)));

            float sumHalfWidth = player.Transform.Scale.x / 2 + scale.x / 2;
            float sumHalfH = player.Transform.Scale.y / 2 + scale.y / 2;

            if (distanceX < sumHalfWidth && distanceY < sumHalfH)
            {
                GameManager.Instance.ChangeGameStatus(3);
            }

        }


        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, position.x, position.y);
        }

    }
}