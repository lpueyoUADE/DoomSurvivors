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
        public Player(Transform transform, double speed, AnimationController animationController, WeaponController weaponController) : 
            base(transform, speed, animationController, weaponController)
        {
        }

        protected override void InputEvents()
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
                if (weaponController.CurrentWeapon.IsReadyToShoot)
                {
                    this.isAttacking = true;
                    Attack();
                    weaponController.CurrentWeapon.IsHoldingTrigger = true;
                }
                else
                {
                    this.isAttacking = false;
                }
            } else
            {
                this.isAttacking = false;
                weaponController.CurrentWeapon.IsHoldingTrigger = false;
            }

            if (Engine.MousePress(Engine.MOUSEBUTTON_RIGHT))
            {
                SceneController.Instance.changeScene(2);
            }
        }
    }
}
