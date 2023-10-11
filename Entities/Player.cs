using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public class Player : OffensiveEntity
    {
        public Player(Sdl.SDL_Rect rect, double speed, AnimationController animationController, WeaponController weaponController) : 
            base(rect, speed, animationController, weaponController)
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
                Attack();
            }

            if (Engine.MousePress(Engine.MOUSEBUTTON_RIGHT))
            {
                SceneController.Instance.changeScene(2);
            }
        }
    }
}
