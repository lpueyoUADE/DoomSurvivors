﻿using DoomSurvivors.Entities.Weapons;

namespace DoomSurvivors.Entities
{
    public static class CollisionController
    {
        public static void HandleCollision(GameObject gameObject, GameObject other)
        {
            if(gameObject is Bullet)
                ((Bullet)gameObject).OnCollision(other);

            else if (other is Bullet)
                ((Bullet)other).OnCollision(gameObject);

            else if(gameObject is Wall)
                ((Wall)gameObject).OnCollision(other);

            else if (other is Wall)
                ((Wall)other).OnCollision(gameObject);

            else if(gameObject is Item && other is Player)
                ((Item)gameObject).OnCollision((Player)other);

            else if (other is Item && gameObject is Player)
                ((Item)other).OnCollision((Player)gameObject);

            else
                gameObject.OnCollision(other);
        }
    }
}

