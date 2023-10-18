using DoomSurvivors.Main;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public class Player : OffensiveEntity
    {
        public Player(Transform transform, double speed, Vector WeaponOffset, AnimationController animationController, WeaponController weaponController=null) : 
            base(transform, speed, WeaponOffset, animationController, weaponController)
        {}

        private void LeftMouseButtonReleasedActionHandler()
        {
            this.weaponController.CurrentWeapon.ReleaseTrigger();
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
                    int x, y;
                    Sdl.SDL_GetMouseState(out x, out y);
                    // AddTracerEffect(this.transform.Position, Camera.Instance.CameraToWorldPosition(new Vector(x,y)));
                    AttackAt(Camera.Instance.CameraToWorldPosition(new Vector(x, y)));

                }
            }

            if (Engine.MousePress(Engine.MOUSEBUTTON_RIGHT))
            {
                SceneController.Instance.ChangeScene(2);
            }
        }

        public void Load()
        {
            Program.LeftMouseButtonReleasedAction += LeftMouseButtonReleasedActionHandler;
        }

        public void Unload()
        {
            Program.LeftMouseButtonReleasedAction -= LeftMouseButtonReleasedActionHandler;
        }
    }
}
