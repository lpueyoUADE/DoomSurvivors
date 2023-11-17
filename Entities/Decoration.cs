using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Utilities;
using System;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public class Decoration : GameObject
    {
        public enum DecorationType
        {
            FlamingBarrel,
            SmallCandle,
            BigCandle,
            SkullCandle,
            TallColumn,
            GreenTallColumn,
            GreenSmallColumn,
            GreenHeartColumn,
            RedTallColumn,
            RedSmallColumn,
            RedSkullColumn,
            EvilEye,
            GibPuddle1,
            GibPuddle2,
            GibPuddle3,
            GibPuddle4,
            HangingCorpseAnimated,
            HangingCorpse1,
            HangingCorpse2,
            HangingCorpse3,
            HangingCorpse4,
            HangingCorpse5,
            HangingCorpse6,
            HangingCorpse7,
            HangingCorpse8,
            HangingCorpse9,
            HangingCorpse10,
            HellThingy,
            ImpaledZombieStill,
            ImpaledSkulls,
            ImpaledSingleSkull,
            ImpaledZombieAnimated,
            SmallBlueTorch,
            SmallGreenTorch,
            SmallRedTorch,
            BigBlueTorch,
            BigGreenTorch,
            BigRedTorch,
            BigBlueLamp,
            SmallBlueLamp,
            Lamp,
            BigTree,
            SmallTree,
            GrayStump,
            Stump
        }

        private Animation idleAnimation;
        public Decoration(Transform transform, Animation idleAnimation, CollisionType collisionType = CollisionType.Static, bool drawShadow = true, bool drawBoundingBox = false) : base(transform, collisionType, drawShadow, drawBoundingBox)
        {
            Random rnd = new Random();
            this.idleAnimation = idleAnimation;
            this.IsRayCastCollidable = true;
        }
        override public void OnCollision(GameObject other)
        {
            other.Transform.Position = other.PreviousPosition;
            base.OnCollision(other);
        }

        protected override Sprite GetCurrentSprite()
        {
            return this.idleAnimation.CurrentFrame;
        }
        override public void Update()
        {
            base.Update();
            idleAnimation.Update();
            this.transform.Size = new Vector(
               this.idleAnimation.CurrentFrame.Transform.Size.X,
               this.idleAnimation.CurrentFrame.Transform.Size.Y + this.idleAnimation.VerticalOffset);
            DrawingOffset = new Vector(DrawingOffset.X, this.idleAnimation.VerticalOffset);
        }
    }
}
