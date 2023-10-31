using DoomSurvivors.Utilities;
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
    public enum CollisionType
    {
        Disabled,
        Static,
        Kinematic
    }
    
    public abstract class GameObject : IRenderizable, ICollidable
    {
        protected Transform transform; 
        protected Shadow shadow;
        private CollisionType collisionType;

        private bool drawShadow;
        private bool drawBoundingBox;

        public Transform Transform { get { return transform; } }

        public bool DrawShadow { 
            get { return drawShadow; }
            set { drawShadow = value;  }
        }

        public bool DrawBoundingBox
        {
            get { return drawBoundingBox; }
            set { drawBoundingBox = value; }
        }

        public CollisionType CollisionType { get => collisionType; set => collisionType = value; }

        public GameObject(Transform transform, CollisionType collisionType=CollisionType.Static, bool drawShadow=true, bool drawBoundingBox=false)
        {
            this.transform = transform;
            this.collisionType = collisionType;
            this.drawShadow = drawShadow;
            this.drawBoundingBox = drawBoundingBox;
            this.shadow = new Shadow(new Color(0,0,0,128), this.transform.W / 3, this.transform.H / 10);
        }
        public virtual void OnCollision(GameObject other)
        {}

        protected abstract IntPtr GetCurrentSprite();

        public virtual void Render()
        {
            Vector position = Camera.Instance.WorldToCameraPosition(this.transform.Position);
            if (drawShadow)
                this.shadow.Draw((int)position.X + transform.W / 2, (int)position.Y + transform.H);

            if (drawBoundingBox)
                Engine.DrawRect(position, Transform.Size, 0xff0000);

            Engine.Draw(GetCurrentSprite(), (int)position.X, (int)position.Y, transform.W, transform.H);
        }
        public abstract void Update();
    }
}
