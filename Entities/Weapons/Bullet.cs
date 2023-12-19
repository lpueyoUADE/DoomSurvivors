using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Entities.Factories;
using DoomSurvivors.Main;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DoomSurvivors.Entities.Weapons
{
    public class Bullet : Entity
    {
        private int damage;
        private OffensiveEntity owner;
        private float lifespan;
        private float remainingLife;

        private Color beginColorTracer;
        private Color endColorTracer;

        private ParticleType wallHitParticle;
        private ParticleType entityHitParticle;

        private Sound deathSound;

        public Vector origin;
        public Vector offset;
        public float maxHaloLength = 100f;

        public bool isDead => remainingLife <= 0;

        public int Damage => damage;

        public static event Action<Particle> BulletHitAction;

        public Bullet(Transform transform, double speed, AnimationController animationController, int damage, OffensiveEntity owner, float lifespan, Color beginColorTracer, Color endColorTracer, ParticleType wallHitParticle, ParticleType entityHitParticle, Sound deathSound) :
            this(transform, speed, animationController, damage, owner, new Vector(0, 0), lifespan, beginColorTracer, endColorTracer, wallHitParticle, entityHitParticle, deathSound)
        { }
        public Bullet(Transform transform, double speed, AnimationController animationController, int damage, OffensiveEntity owner, Vector direction, float lifespan, Color beginColorTracer, Color endColorTracer, ParticleType wallHitParticle, ParticleType entityHitParticle, Sound deathSound) :
            base(transform, speed, animationController)
        {
            this.damage = damage;
            this.owner = owner;
            this.direction = direction;
            this.lifespan = lifespan;
            this.remainingLife = lifespan;

            this.origin = Transform.Position;
            this.offset = new Vector(0, 0);

            this.beginColorTracer = beginColorTracer;
            this.endColorTracer = endColorTracer;

            this.wallHitParticle = wallHitParticle;
            this.entityHitParticle = entityHitParticle;

            this.deathSound = deathSound;

            this.CollisionType = CollisionType.Static;
        }

        override public void OnCollision(GameObject other)
        {
            if (other is Bullet)
                return;

            if (other is OffensiveEntity)
            {
                bool ownBullet = other is OffensiveEntity && IsOwnedBy((OffensiveEntity)other);
                if (ownBullet)
                    return;

                if (other is OffensiveEntity && ((OffensiveEntity)other).IsDying)
                    return;

                ((OffensiveEntity)other).ApplyDamage(this.damage);
                BulletHitAction?.Invoke(ParticleFactory.CreateParticle(entityHitParticle, transform.PositionCenter));
                this.Destroy();
            }
            else if (other is Wall || other is Decoration)
            {
                BulletHitAction?.Invoke(ParticleFactory.CreateParticle(wallHitParticle, transform.PositionCenter));
                this.Destroy();
            }
            else if (other is Entity)
            {
                this.Destroy();
            }

            this.deathSound.PlayOnce();

            base.OnCollision(other);
        }

        protected override void InputEvents()
        { }

        public override void Update()
        {
            remainingLife -= Program.DeltaTime;

            Vector distance = Transform.PositionCenter - origin;
            Vector dir = direction;
            Vector begin = origin;

            // TODO: Implement it properly!
            // Keep the line to a max length
            if (distance.Length > maxHaloLength)
            {
                dir.Normalize();
                begin = origin + dir * maxHaloLength;
            }

            Engine.DrawGradientLine(
                Camera.Instance.WorldToCameraPosition(begin),
                Camera.Instance.WorldToCameraPosition(Transform.PositionCenter),
                beginColorTracer,
                endColorTracer,
                15);
            base.Update();
        }

        public Bullet Clone()
        {
            return new Bullet(transform, speed, AnimationController, damage, owner, direction, lifespan, beginColorTracer, endColorTracer, wallHitParticle, entityHitParticle, deathSound);
        }

        public Bullet Clone(Vector position, Vector aimingAt)
        {
            return new Bullet(new Transform(position, transform.Size), speed, AnimationController, damage, owner, aimingAt - position, lifespan, beginColorTracer, endColorTracer, wallHitParticle, entityHitParticle, deathSound);
        }

        public bool IsOwnedBy(OffensiveEntity entity)
        {
            return ReferenceEquals(this.owner, entity);
        }

        public void Destroy()
        {
            this.remainingLife = 0;
            this.State = State.Dying;
        }
    }
}
