using DoomSurvivors.Viewport;
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
        public Monster(Transform transform, double speed, AnimationController animationController, WeaponController weaponController, Entity target = null, double visionRadius = 0) :
            base(transform, speed, animationController, weaponController)
        {
            this.target = target;
            this.visionRadius = visionRadius;
        }

        protected override void InputEvents()
        {
            Vector distance = Vector.Subtract(new Vector(target.Transform.X, target.Transform.Y), new Vector(transform.X, transform.Y));
            if (distance.Length <= this.visionRadius)
            {
                this.direction = distance;
            }
        }

        override protected void render()
        {
            if (showVisionRadius)
            {
                Vector newPosition = Camera.Instance.WorldToCameraPosition(this.Transform.Position);
                Engine.DrawCirle((int)newPosition.X + transform.W / 2, (int)newPosition.Y + transform.H / 2, (int)this.visionRadius, 0, 255, 0, 255);
            }

            base.render();
        }
    }
}
