using DoomSurvivors.Entities;
using DoomSurvivors.Main;
using DoomSurvivors.Scenes;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace DoomSurvivors
{
    internal class PlayableScene : Scene
    {
        private Map map;
        private List<Tracer> tracerList;
        private List<Entity> entityList;
        private bool showBoundingBox;
        private bool showVisionRadius;

        public bool ShowBoundingBox {
            get { return this.showBoundingBox; }
            set { this.showBoundingBox = value; }
        }
        public bool ShowVisionRadius
        {
            get { return this.showVisionRadius; }
            set { this.showVisionRadius = value; }
        }

        public PlayableScene(Map map, bool showBoundingBox = false, bool showVisionRadius = false, params Entity[] entityList)
        {
            this.entityList = entityList.ToList();
            this.map = map;
            this.tracerList = new List<Tracer>();
            this.showBoundingBox = showBoundingBox;
            this.showVisionRadius = showVisionRadius;
        }


        public void AddTracerEffect(Vector begin, Vector end)
        {
            tracerList.Add(new Tracer(begin, end, 20, new Color(0xff000000), new Color(0xffff00ff)));
        }

        public void AddEntity(Entity entity)
        {
            this.entityList.Add(entity);
        }

        private void checkCollisions()
        {
            // check-then-update approach
            //foreach (Monster enemy in enemyList)
            //{
            //    if(player.IsColliding(enemy))
            //    {
            //        Console.WriteLine("Colliding!");
            //        Vector playerVelocity = player.Velocity;
            //        enemy.Transform.Position = new Vector(enemy.Transform.Position.X - enemy.Velocity.X, enemy.Transform.Position.Y - enemy.Velocity.Y);
            //    }
            //}

            // TODO: Implement either Quadtress or Fixed Grid.
            // O(n**2)
            for (int i = 0; i < entityList.Count; i++)
            {
                for (int j = i + 1; j < entityList.Count; j++) // j = i + 1 Para no checkear A con B y despues B con A
                {
                    if (i == j)
                        continue;
                    
                    Entity entity = entityList[i];
                    Entity other = entityList[j];

                    CollisionController.HandleCollision(entity, other);
                    
                    /*
                    bool bulletHitTest = entity is Bullet || other is Bullet;

                    bool ownBullet = 
                        entity is Bullet && other is OffensiveEntity && ((Bullet)entity).IsownedBy((OffensiveEntity)other) ||
                        other is Bullet && entity is OffensiveEntity && ((Bullet)other).IsownedBy((OffensiveEntity) entity);
  
                    if (!bulletHitTest && !ownBullet && entity.IsColliding(other))
                    {
                        Vector distance = other.Transform.PositionCenter - entity.Transform.PositionCenter;
                        other.Velocity += distance / 3;
                        entity.Velocity -= distance / 3;
                    }
                    */
                }
            }
        }

        public override void Load()
        {
            Camera.Instance.Active = true;
            foreach (Entity entity in entityList)
            {
                entity.ShowBoundingBox = showBoundingBox;
                
                if (entity is Monster) 
                   ((Monster)entity).ShowVisionRadius = showVisionRadius;

                if (entity is Player)
                    ((Player)entity).Load();
            }

            RayTracedWeapon.RayTracedWeaponShotAction += RayTracedWeaponShotActionHandler;
            BulletWeapon.BulletWeaponShotAction += BulletWeaponShotActionHandler;

        }
        public override void UnLoad()
        {
            Camera.Instance.Active = false;
            RayTracedWeapon.RayTracedWeaponShotAction -= RayTracedWeaponShotActionHandler;
            BulletWeapon.BulletWeaponShotAction -= BulletWeaponShotActionHandler;

            Player player = entityList.OfType<Player>().FirstOrDefault();
            player?.Unload();
        }

        private void RayTracedWeaponShotActionHandler(RayTracedWeapon weapon)
        {
            this.tracerList.Add(weapon.Tracer.Clone());
        }

        private void BulletWeaponShotActionHandler(BulletWeapon weapon)
        {
            this.entityList.Add(weapon.SpawnBullet());
        }

        public override void Update()
        {
            // Camera Update
            Camera.Instance.Update();

            // Map Update
            map.Update();

            // Add newly spawn entites

            // Collisions
            checkCollisions();

            // Entities Update
            for (int i = 0; i < entityList.Count; i++)
            {
                entityList[i].Update();
            }

            // Tracer Effects Update
            foreach (Tracer tracer in tracerList)
            {
                tracer.Update();
            }

            tracerList.RemoveAll(tracer => tracer.hasFinished);
            entityList.RemoveAll(entity => entity is Bullet && ((Bullet)entity).isDead);

        }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
