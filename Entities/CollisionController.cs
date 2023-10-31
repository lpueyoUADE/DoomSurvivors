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

            else
                gameObject.OnCollision(other);
        }
    }
}

