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
        private List<Entity> deadEntityList;
        private bool drawBoundingBox;
        private bool drawVisionRadius;

        public bool DrawBoundingBox {
            get { return this.drawBoundingBox; }
            set { this.drawBoundingBox = value; }
        }
        public bool DrawVisionRadius
        {
            get { return this.drawVisionRadius; }
            set { this.drawVisionRadius = value; }
        }

        public PlayableScene(Map map, bool drawBoundingBox = false, bool drawVisionRadius = false, params Entity[] entityList)
        {
            this.entityList = entityList.ToList();
            this.deadEntityList = new List<Entity>();
            this.map = map;
            this.tracerList = new List<Tracer>();
            this.drawBoundingBox = drawBoundingBox;
            this.drawVisionRadius = drawVisionRadius;
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

            // TODO: Implement either Quadtrees or Fixed Grid.
            // O(n**2)
            for (int i = 0; i < entityList.Count; i++)
            {
                Entity entity = entityList[i];
                if (entity.CollisionType == CollisionType.Disabled)
                    continue;

                for (int j = i + 1; j < entityList.Count; j++) // j = i + 1 Para no checkear A con B y despues B con A
                {
                    if (i == j)
                        continue;

                    Entity other = entityList[j];
                    if (other.CollisionType == CollisionType.Disabled)
                        continue;

                    if (entity.Transform.isColliding(other.Transform))
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
                entity.DrawBoundingBox = drawBoundingBox;
                
                if (entity is Monster) 
                   ((Monster)entity).ShowVisionRadius = drawVisionRadius;

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

            // Dead Entities Update
            for (int i = 0; i < deadEntityList.Count; i++)
            {
                deadEntityList[i].Update();
            }

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
            
            deadEntityList.AddRange(entityList.FindAll(entity => entity is OffensiveEntity && ((OffensiveEntity)entity).State == State.Death));
            entityList.RemoveAll(entity => entity is OffensiveEntity && ((OffensiveEntity)entity).State == State.Death);
        }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
