using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Main;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public class Item : GameObject
    {

        private Animation idleAnimation;

        private float hoveringOffsetSpeed = 0.25f;
        private float hoveringOffsetStepTime;
        private int hoveringOffsetStepIndex;
        private List<Vector> hoveringOffsetSteps = new List<Vector> 
        { 
            new Vector(0,-1),
            new Vector(0,-1),
            new Vector(0,-1),
            new Vector(0,1),
            new Vector(0,1),
            new Vector(0,1),
        };

        private Halo halo;

        private bool collected;

        public enum ItemType
        {
            Chainsaw,
            Shotgun,
            SuperShotgun,
            Chaingun,
            RocketLauncher,
            PlasmaRifle,
            BFG9000,
            Clip,
            AmmoBox,
            Shells,
            ShellsBox,
            Rocket,
            RocketBox,
            PlasmaCell,
            PlasmaBox,
            Backpack,
            HealthPotion,
            Helmet,
            SmallMedKit,
            BigMedkit,
            ArmorGreen,
            ArmorBlue,
            SoulSphere,
            MegaSphere,
            RadiationSuit,
            Invicibility,
            Invulnerability,
            Goggles,
            Map,
            Berserk,
            BlueKey,
            RedKey,
            YellowKey,
            BlueSkullKey,
            RedSkullKey,
            YellowSkullKey
        }

        public bool Collected => this.collected;
        public Item(Transform transform, Animation idleAnimation, Halo halo=null, bool drawShadow = true, bool drawBoundingBox = false) : base(transform, CollisionType.Static, drawShadow, drawBoundingBox)
        {
            Random rnd = new Random();
            this.idleAnimation = idleAnimation;
            this.hoveringOffsetStepIndex = rnd.Next(0,hoveringOffsetSteps.Count);
            this.hoveringOffsetStepTime = 0;
            this.halo = halo;
        }

        override public void OnCollision(GameObject other)
        {
            if (other is Player)
            {
                this.collected = true;
            }
        }
        private void Hovering()
        {
            hoveringOffsetStepTime += Program.DeltaTime;
            if (hoveringOffsetStepTime > hoveringOffsetSpeed)
            { 
                hoveringOffsetStepTime = 0;
                hoveringOffsetStepIndex = (hoveringOffsetStepIndex + 1) % hoveringOffsetSteps.Count;
                this.DrawingOffset += hoveringOffsetSteps[hoveringOffsetStepIndex];
            }
        }

        protected override Sprite GetCurrentSprite()
        {
            return idleAnimation.CurrentFrame;
        }

        public override void Update()
        {
            base.Update();
            idleAnimation.Update();
            if(halo != null)
                halo.Transform.Position = this.Transform.PositionCenter + this.DrawingOffset;
            Hovering();
        }
        public override void Render()
        {
            if(halo != null)
                halo.Render();
            base.Render();
        }
    }
}
