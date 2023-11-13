using System;
using System.Windows;
using static System.Math;

namespace DoomSurvivors.Entities.Weapons
{
    public class Ray
    {
        private OffensiveEntity owner;
        private Vector direction;
        private Vector directionInverse;
        private Tracer tracer;
        private float maxDistance;

        public Vector Origin => owner.WeaponPosition;
        public Vector Direction => direction;

        public float MaxDistance => maxDistance;
        public Tracer Tracer => tracer;

        public OffensiveEntity Owner => owner;
        public Ray(OffensiveEntity owner, Vector direction, Tracer tracer, float maxDistance)
        {
            this.owner = owner;
            this.direction = direction;
            this.tracer = tracer;
            this.directionInverse = new Vector(1 / direction.X, 1 / direction.Y);
            this.maxDistance = maxDistance;
        }
        public bool Intersects(Transform transform, out double x, out double y)
        {
            // https://tavianator.com/2022/ray_box_boundary.html#fast-branchless-raybounding-box-intersections-part-3-boundaries

            Vector origin = this.owner.WeaponPosition;

            // Perform ray-box intersection test with limited reach
            double tMin = 0;
            double tMax = maxDistance;

            double tEnterX = (transform.X - origin.X) * directionInverse.X;
            double tExitX = (transform.X + transform.W - origin.X) * directionInverse.X;

            if (tEnterX > tExitX)
                (tEnterX, tExitX) = (tExitX, tEnterX);

            tMin = Max(tEnterX, tMin);
            tMax = Min(tExitX, tMax);

            x = -1;
            y = -1;
            if (tMin > tMax)
            {
                return false; // No intersection within the limited reach
            }

            double tEnterY = (transform.Y - origin.Y) * directionInverse.Y;
            double tExitY = (transform.Y + transform.H - origin.Y) * directionInverse.Y;

            if (tEnterY > tExitY)
                (tEnterY, tExitY) = (tExitY, tEnterY);

            tMin = Max(tEnterY, tMin);
            tMax = Min(tExitY, tMax);

            if(tMin <= tMax)
            {
                double distance = Min(tMin, tMax);

                x = origin.X + direction.X * distance;
                y = origin.Y + direction.Y * distance;

                return true;
            }
            return false;
        }

        public bool IsOwnedBy(OffensiveEntity entity)
        {
            return ReferenceEquals(this.owner, entity);
        }
    }
}
