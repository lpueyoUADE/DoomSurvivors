using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Utilities;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public class Wall : GameObject
    {
        public enum WallType
        {
            TestWall
        }

        private Sprite sprite;
        protected Sprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public Wall(Transform transform, Sprite sprite, CollisionType collisionType = CollisionType.Static, bool drawShadow = true, bool drawBoundingBox = false) :
            base(transform, collisionType, drawShadow, drawBoundingBox)
        {
            this.sprite = sprite;
            this.shadow = new Shadow(new Color(0, 0, 0, 128), this.transform.W / 2, this.transform.H / 10, Shadow.Shape.Rectangle);

            this.IsRayCastCollidable = true;
        }

        override public void OnCollision(GameObject other)
        {
            //if (other is Entity)
            //{
            //    Vector distance = other.Transform.PositionCenter - this.Transform.PositionCenter;
            //    ((Entity)other).Velocity += distance / 5;
            //}

            other.Transform.Position = other.PreviousPosition;                

            base.OnCollision(other);
        }

        protected override Sprite GetCurrentSprite()
        {
            return this.sprite;
        }
        override public void Update(){}
    }
}
