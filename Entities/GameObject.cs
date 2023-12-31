﻿using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System.Windows;

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
        protected Vector previousPosition;
        protected Shadow shadow;
        private CollisionType collisionType;
        private bool rayCastCollidable;

        private Vector drawingOffset;
        private bool drawShadow;
        private bool drawBoundingBox;

        public Transform Transform => transform;
        public Vector PreviousPosition => previousPosition;

        public bool IsRayCastCollidable
        {
            get => rayCastCollidable;
            set => rayCastCollidable = value;
        }

        public Vector DrawingOffset
        {
            get => drawingOffset;
            set => drawingOffset = value;
        }
        public bool DrawShadow 
        { 
            get => drawShadow;
            set => drawShadow = value;
        }

        public bool DrawBoundingBox
        {
            get => drawBoundingBox;
            set => drawBoundingBox = value;
        }

        public CollisionType CollisionType { get => collisionType; set => collisionType = value; }

        public GameObject(Transform transform, CollisionType collisionType=CollisionType.Static, bool drawShadow=true, bool drawBoundingBox=false)
        {
            this.transform = transform;
            this.previousPosition = this.transform.Position;
            this.collisionType = collisionType;
            this.drawShadow = drawShadow;
            this.drawBoundingBox = drawBoundingBox;
            this.shadow = new Shadow(new Color(0,0,0,128), this.transform.W / 3, this.transform.H / 10);

            this.rayCastCollidable = false;
        }
        public virtual void OnCollision(GameObject other)
        {}

        protected abstract Sprite GetCurrentSprite();

        public virtual void Render()
        {
            Vector position = Camera.Instance.WorldToCameraPosition(this.transform.Position);
            if (drawShadow)
                this.shadow.Draw((int)position.X + transform.W / 2, (int)position.Y + transform.H);

            if (drawBoundingBox)
                Engine.DrawRect(position, Transform.Size, 0xff0000);

            Engine.Draw(
                GetCurrentSprite(), 
                (int)position.X + DrawingOffset.X, 
                (int)position.Y + DrawingOffset.Y, 
                transform.W,
                transform.H
            );
        }
        public virtual void Update()
        {
            this.previousPosition = transform.Position;
        }
    }
}
