using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Entities.Weapons;
using DoomSurvivors.Main;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using System.CodeDom;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public class Player : OffensiveEntity
    {

        private int interactionRadius;
        private bool drawInteractionRadius;

        private int armor;
        private int maxArmor;

        private int xp;
        private int maxLevelXp;
        private int level;

        private bool triggerReleased;

        private Sound deathSound;
        public bool DrawInteractionRadius 
        {
            get => drawInteractionRadius;
            set => drawInteractionRadius = value;
        }

        public int MaxArmor
        {
            get => maxArmor;
        }

        public int Armor
        {
            get => armor;
            set => armor = value;
        }
        public static event Action<Vector, int> InteractAction;
        public Player(Transform transform, double speed, int life, Vector WeaponOffset, AnimationController animationController, WeaponController weaponController=null) : 
            base(transform, speed, life, WeaponOffset, animationController, weaponController)
        {
            this.CollisionType = CollisionType.Static;
            this.Life = 100;
            this.MaxLife = 100;
            this.armor = 0;
            this.maxArmor = 100;
            this.interactionRadius = 70;
            this.drawInteractionRadius = true;
            this.triggerReleased = true;
            this.deathSound = new Sound("assets/Sounds/Player/DSPLDETH.wav");
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

        public void AddLife(int life)
        {
            this.Life = (int)Tools.Clamp(this.Life + life, 0, MaxLife);
        }

        public void AddArmor(int armor)
        {
            this.Armor = (int)Tools.Clamp(this.Armor + armor, 0, maxArmor);
        }

        override public void ApplyDamage(int damage)
        {
            int lifeDamage = (int)Math.Ceiling((double)damage * (1/3.0));
            int armorDamage = (int)Math.Ceiling((double)damage * (2 / 3.0));

            if (armor > 0)
                this.armor = (int)Tools.Clamp(this.armor - armorDamage, 0, this.maxArmor);
            else
                lifeDamage = damage;

            base.ApplyDamage(lifeDamage);
        }

        override protected void Die()
        {
            base.Die();
            this.deathSound.PlayOnce();
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

        public void AddAmmo(AmmoType ammoType, int amount)
        {
            this.weaponController.AddAmmo(ammoType, amount);
        }

        public int GetAmmo(AmmoType ammoType)
        {
            return this.weaponController.GetAmmo(ammoType);
        }

        public int GetMaxAmmoCapacity(AmmoType ammoType)
        {
            return this.weaponController.GetMaxAmmoCapacity(ammoType);
        }

        private void LeftMouseButtonReleasedActionHandler()
        {
            this.weaponController.CurrentWeapon.ReleaseTrigger();
            this.triggerReleased = true;
        }

        private void InteractButtonPressedActionHandler()
        {
            Interact();
            triggerReleased = true;
        }
        private void NumericButtonPressedActionHandler(int number)
        {
            switch (number)
            {
                case 1:
                    weaponController.SelectWeapon(WeaponID.Pistol);
                    break;

                case 2:
                    weaponController.SelectWeapon(WeaponID.Shotgun);
                    break;

                case 3:
                    weaponController.SelectWeapon(WeaponID.SuperShotgun);
                    break;

                case 4:
                    weaponController.SelectWeapon(WeaponID.Chaingun);
                    break;

                case 5:
                    weaponController.SelectWeapon(WeaponID.RocketLauncher);
                    break;

                case 6:
                    weaponController.SelectWeapon(WeaponID.PlasmaRifle);
                    break;

                case 7:
                    weaponController.SelectWeapon(WeaponID.BFG);
                    break;

                case 8:
                    weaponController.SelectWeapon(WeaponID.Chainsaw);
                    break;
            }        
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
                if (weaponController.GetCurrentWeaponAmmo() == 0 && triggerReleased)
                {
                    weaponController.CurrentWeapon.PlayNoAmmoSound();
                    triggerReleased = false;
                }

                if (weaponController.CurrentWeapon.IsReadyToShoot)
                {
                    int x, y;
                    Sdl.SDL_GetMouseState(out x, out y);
                    AttackAt(Camera.Instance.CameraToWorldPosition(new Vector(x, y)));

                }
            }

            if (Engine.MousePress(Engine.MOUSEBUTTON_RIGHT))
            {}
        }
        private void Interact()
        {
            InteractAction?.Invoke(this.Transform.PositionCenter, this.interactionRadius);
        }

        public void Load()
        {
            Program.LeftMouseButtonReleasedAction += LeftMouseButtonReleasedActionHandler;
            Program.InteractButtonPressedAction += InteractButtonPressedActionHandler;
            Program.NumericButtonPressedAction += NumericButtonPressedActionHandler;
        }

        public void Unload()
        {
            Program.LeftMouseButtonReleasedAction -= LeftMouseButtonReleasedActionHandler;
            Program.InteractButtonPressedAction -= InteractButtonPressedActionHandler;
            Program.NumericButtonPressedAction -= NumericButtonPressedActionHandler;
        }
    }
}
