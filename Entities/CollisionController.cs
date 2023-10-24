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
            if(entity is Bullet)
                ((Bullet)entity).OnCollision(other);

            else if (other is Bullet)
                ((Bullet)other).OnCollision(entity);

            else
                entity.OnCollision(other);

            //if (entity is Bullet)
            //    ((Bullet)entity).HandleCollision(other);

            //else if (entity is OffensiveEntity)
            //    ((OffensiveEntity)entity).HandleCollision(other);

            //else
            //    entity.HandleCollision(other);

            //if (entity is Bullet && other is Bullet)
            //    HandleConcreteCollision((Bullet)entity, (Bullet)other);

            //if (!(entity is Bullet) && !(other is Bullet))
            //    HandleConcreteCollision(entity, other);

            //if (entity is Bullet && other is OffensiveEntity)
            //    HandleConcreteCollision((Bullet)entity, (OffensiveEntity)other);

            //if (entity is OffensiveEntity && other is Bullet)
            //    HandleConcreteCollision((Bullet)other, (OffensiveEntity)entity);

        }
    }
}

