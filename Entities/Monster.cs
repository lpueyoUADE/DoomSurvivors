using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System.Windows;

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
        
        public struct MonsterPlacer
        {
            public MonsterType monsterType;
            public Vector position;

            public MonsterPlacer(MonsterType monsterType, int x, int y) : this()
            {
                this.monsterType = monsterType;
                this.position = new Vector(x, y);
            }
        }

        private Entity target;
        private double visionRadius;
        private bool showVisionRadius;
        private int clock;

        public bool ShowVisionRadius
        {
            get { return this.showVisionRadius; }
            set { this.showVisionRadius = value; }
        }

        public Entity Target
        {
            get => target; 
            set => target = value;
        }

        public bool TargetOnSight => (target.Transform.Position - transform.Position).Length <= this.visionRadius;

        public Monster(Transform transform, double speed, int life, Vector weaponPosition, AnimationController animationController, WeaponController weaponController=null, Entity target = null, double visionRadius = 0) :
            base(transform, speed, life, weaponPosition, animationController, weaponController)
        {
            this.target = target;
            this.visionRadius = visionRadius;
            this.clock = 0;

            this.CollisionType = CollisionType.Kinematic;
        }
   
        protected override void InputEvents()
        {
            this.direction = new Vector(0, 0);
            
            if (this.IsDying || this.IsDeath || target is null || ((OffensiveEntity)target).IsDeath || ((OffensiveEntity)target).IsDying)
                return;

            Vector distance = target.Transform.Position - transform.Position;
            if (distance.Length <= this.visionRadius)
                this.direction = distance;

            // Test
            clock++;
            if(clock == 50)
            {
                this.clock = 0;
                
                if(TargetOnSight)
                    AttackAt(target.Transform.PositionCenter);
            }
        }

        override public void Render()
        {
            if (showVisionRadius)
            {
                Vector newPosition = Camera.Instance.WorldToCameraPosition(this.Transform.Position);
                Engine.DrawCirle((int)newPosition.X + transform.W / 2, (int)newPosition.Y + transform.H / 2, (int)this.visionRadius, new Color(0, 255, 0, 255));
            }

            base.Render();
        }
    }
}
