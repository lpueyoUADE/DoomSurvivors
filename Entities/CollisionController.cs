using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public static class CollisionController
    {
        public static void HandleCollision(Entity entity, Entity other)
        {           
            if(entity.IsColliding(other))
            {
                if (entity is Bullet && other is Bullet)
                    HandleConcreteCollision((Bullet)entity, (Bullet)other);

                if (!(entity is Bullet) && !(other is Bullet))
                    HandleConcreteCollision(entity, other);

                if (entity is Bullet && other is OffensiveEntity)
                    HandleConcreteCollision((Bullet)entity, (OffensiveEntity)other);

                if (entity is OffensiveEntity && other is Bullet)
                    HandleConcreteCollision((Bullet)other, (OffensiveEntity)entity);
            }
        }

        private static void Push(Entity entity, Entity other)
        {
            Vector distance = other.Transform.PositionCenter - entity.Transform.PositionCenter;
            other.Velocity += distance / 3;
            entity.Velocity -= distance / 3;
        }

        private static void HandleConcreteCollision(Entity entity, Entity other)
        {
            Push(entity, other);
        }

        private static void HandleConcreteCollision(Bullet entity, Bullet other)
        {}

        private static void HandleConcreteCollision(Bullet entity, OffensiveEntity other)
        {
            bool ownBullet =
                other is OffensiveEntity && entity.IsownedBy(other);

            if (!ownBullet)
            {
                other.ApplyDamage(entity.Damage);
                Push(entity, other);
                entity.Destroy();
            }
        }
    }
}
