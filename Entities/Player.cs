using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Main;
using DoomSurvivors.Viewport;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public class Player : OffensiveEntity
    {
        public Player(Transform transform, double speed, int life, Vector WeaponOffset, AnimationController animationController, WeaponController weaponController=null) : 
            base(transform, speed, life, WeaponOffset, animationController, weaponController)
        {
            this.CollisionType = CollisionType.Static;
            this.Life = 1000;
        }

        private void LeftMouseButtonReleasedActionHandler()
        {
            this.weaponController.CurrentWeapon.ReleaseTrigger();
        }

        protected override void InputEvents()
        {
            this.direction = new Vector(0, 0);

            if (this.IsDeath || this.IsDying)
                return;

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
