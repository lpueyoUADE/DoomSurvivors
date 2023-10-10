using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Sdl;

namespace DoomSurvivors
{
    public class Player : Entity
    {
        public Player(Sdl.SDL_Rect rect, double speed, AnimationController animationController, Entity target = null, double visionRadius = 0) : base(rect, speed, animationController)
        {
        }

        protected override void UpdateDirection()
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
                SceneController.Instance.changeScene(2);
            }
        }
    }
}
