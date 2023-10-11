using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    abstract public class OffensiveEntity : Entity
    {
        protected WeaponController weaponController;

        public OffensiveEntity(Sdl.SDL_Rect rect, double speed, AnimationController animationController, WeaponController weaponController) : 
            base(rect, speed, animationController)
        {
            this.weaponController = weaponController;
        }

        public void Attack() {
            this.weaponController.CurrentWeapon.Shoot();
        }
    }
}
