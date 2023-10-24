using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities
{
    internal interface ICollidable
    {

        CollisionType CollisionType { get; set; }
        void OnCollision(GameObject other);
    }
}
