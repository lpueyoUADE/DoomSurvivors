using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public class Monster : OffensiveEntity
    {
        private Entity target;
        private double visionRadius;
        private bool showVisionRadius;

        public bool ShowVisionRadius
        {
            get { return this.showVisionRadius; }
            set { this.showVisionRadius = value; }
        }
        public Monster(Sdl.SDL_Rect rect, double speed, AnimationController animationController, WeaponController weaponController, Entity target = null, double visionRadius = 0) :
            base(rect, speed, animationController, weaponController)
        {
            this.target = target;
            this.visionRadius = visionRadius;
        }

        protected override void UpdateDirection()
        {
            Vector distance = Vector.Subtract(new Vector(this.target.Rect.x, this.target.Rect.y), new Vector(this.rect.x, this.rect.y));
            if (distance.Length <= this.visionRadius)
            {
                this.direction = distance;
            }
        }

        override protected void render()
        {
            if (showVisionRadius)
            {
                Engine.DrawCirle(this.rect.x + this.rect.w / 2, this.rect.y + this.rect.h / 2, (int)this.visionRadius, 0, 255, 0, 255);
            }

            base.render();
        }
    }
}
