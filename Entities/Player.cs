using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Entities.Weapons;
using DoomSurvivors.Main;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public class Player : OffensiveEntity
    {

        private int interactionRadius;
        private bool drawInteractionRadius;

        public static event Action<Vector, int> InteractAction;
        public Player(Transform transform, double speed, int life, Vector WeaponOffset, AnimationController animationController, WeaponController weaponController=null) : 
            base(transform, speed, life, WeaponOffset, animationController, weaponController)
        {
            this.CollisionType = CollisionType.Static;
            this.Life = 10000;
            this.interactionRadius = 70;
            this.drawInteractionRadius = true;
            // Stats
            /*
                Vida
                Velocidad de movimiento
                Cuanto te frena al disparar
                daño
                cooldown
                punteria
                carring capacity
            */
        }

        public override void Render()
        {
            base.Render();

            if (this.drawInteractionRadius)
            {
                Vector newPosition = Camera.Instance.WorldToCameraPosition(this.Transform.PositionCenter);
                Engine.DrawCirle((int)newPosition.X, (int)newPosition.Y, (int)this.interactionRadius, new Color(255, 0, 255, 255));
            }

        }

        private void LeftMouseButtonReleasedActionHandler()
        {
            this.weaponController.CurrentWeapon.ReleaseTrigger();
        }

        private void InteractButtonPressedActionHandler()
        {
            Interact();
        }

        protected override void InputEvents()
        {
            this.direction = new Vector(0, 0);

            if (this.IsDeath || this.IsDying)
                return;

            if (Engine.KeyPress(Engine.KEY_D))
                direction.X = 1;
            if (Engine.KeyPress(Engine.KEY_A))
                direction.X = -1;
            if (Engine.KeyPress(Engine.KEY_W))
                direction.Y = -1;
            if (Engine.KeyPress(Engine.KEY_S))
                direction.Y = 1;

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
        private void Interact()
        {
            InteractAction?.Invoke(this.Transform.PositionCenter, this.interactionRadius);
        }

        public void Load()
        {
            Program.LeftMouseButtonReleasedAction += LeftMouseButtonReleasedActionHandler;
            Program.InteractButtonPressedAction += InteractButtonPressedActionHandler;
        }

        public void Unload()
        {
            Program.LeftMouseButtonReleasedAction -= LeftMouseButtonReleasedActionHandler;
            Program.InteractButtonPressedAction -= InteractButtonPressedActionHandler;
        }
    }
}
