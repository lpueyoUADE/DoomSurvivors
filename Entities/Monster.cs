using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Entities.Factories;
using DoomSurvivors.Entities.Weapons;
using DoomSurvivors.Scenes.Maps.Placers;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using System.Windows;
using static DoomSurvivors.Entities.Item;

namespace DoomSurvivors.Entities
{
    public class Monster : OffensiveEntity
    {
        public enum MonsterType
        {
            Zombie,
            Shotguner,
            Chainguner,
            Wolfenstein,
            Imp,
            Pinky,
            BaronOfHell,
            HellKnight,
            CacoDemon,
            LostSoul,
            PainElemental,
            Mancubus,
            Arachnotron,
            Revenant,
            ArchVile,
            SpiderMasterMind,
            CyberDemon
        }

        public static class Aggressiveness
        {
            public const float Easy = 50;
            public const float Medium = 30;
            public const float Hard = 20;
            public const float Boss = 10;
        }

        private Entity target;
        private double visionRadius;
        private bool showVisionRadius;
        private bool leaveCorpse;
        private int clock;

        private bool alerted;

        private float aggressiveness;

        private List<Drop> drops;

        private Sound alertSound;
        private Sound painSound;
        private Sound deathSound;

        public static event Action<ItemType, Vector> AddDropItemAction;

        public bool ShowVisionRadius
        {
            get { return this.showVisionRadius; }
            set { this.showVisionRadius = value; }
        }

        public bool LeaveCorpse
        {
            get => this.leaveCorpse;
            set => this.leaveCorpse = value;
        }
        public Entity Target
        {
            get => target; 
            set => target = value;
        }

        public bool TargetOnSight => (target.Transform.Position - transform.Position).Length <= this.visionRadius;

        public Monster(Transform transform, double speed, int life, Vector weaponPosition, float aggressiveness, Sound alertSound, Sound painSound, Sound deathSound, AnimationController animationController, List<Drop> drops, WeaponController weaponController=null, Entity target = null, double visionRadius = 0, bool leaveCorpse=true) :
            base(transform, speed, life, weaponPosition, animationController, weaponController)
        {
            this.target = target;
            this.visionRadius = visionRadius;
            this.leaveCorpse = leaveCorpse;

            this.clock = 0;
            this.CollisionType = CollisionType.Kinematic;

            this.alerted = false;

            this.aggressiveness = aggressiveness;

            this.drops = drops;

            this.alertSound = alertSound;
            this.painSound = painSound;
            this.deathSound = deathSound;
        }
   
        protected override void InputEvents()
        {
            this.direction = new Vector(0, 0);
            
            if (this.IsDying || this.IsDeath || target is null || ((OffensiveEntity)target).IsDeath || ((OffensiveEntity)target).IsDying)
                return;

            // TODO: Improve AI
            Vector distance = target.Transform.Position - transform.Position;
            if (distance.Length <= this.visionRadius)
            {
                this.direction = distance;

                if (!alerted)
                {
                    this.alertSound.PlayOnce();
                    alerted = true;
                }
            }

            clock++;
            if(clock == aggressiveness)
            {
                this.clock = 0;
                
                if(TargetOnSight && CurrentWeapon.IsReadyToShoot)
                    AttackAt(target.Transform.PositionCenter);
            }
        }

        override protected void Die()
        {
            base.Die();
            this.deathSound.PlayOnce();

            foreach (Drop drop in drops)
            {
                if (drop.Roll())
                    AddDropItemAction?.Invoke(drop.ItemType, this.Transform.PositionCenter);
            }
        }

        override public void Render()
        {
            if (showVisionRadius)
            {
                Vector newPosition = Camera.Instance.WorldToCameraPosition(this.Transform.PositionCenter);
                Engine.DrawCirle((int)newPosition.X, (int)newPosition.Y, (int)this.visionRadius, new Color(0, 255, 0, 255));
            }

            base.Render();
        }
    }
}
