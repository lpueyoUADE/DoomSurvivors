﻿using DoomSurvivors.Entities.Animations;
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
    public class Wall : GameObject
    {
        public enum WallType
        {
            TestWall
        }
        public struct WallPlacer
        {
            public WallType wallType;
            public Vector position;

            public WallPlacer(WallType wallType, int x, int y) : this()
            {
                this.wallType = wallType;
                this.position = new Vector(x, y);
            }
        }

        private Sprite sprite;

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
