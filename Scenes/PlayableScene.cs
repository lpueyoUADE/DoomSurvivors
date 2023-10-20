using DoomSurvivors.Entities;
using DoomSurvivors.Main;
using DoomSurvivors.Scenes;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DoomSurvivors
{
    internal class PlayableScene : Scene
    {
        private List<Monster> enemyList;
        private Player player;
        private Map map;
        private List<Tracer> tracerList;
        private List<Bullet> bulletList;
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

        public PlayableScene(List<Monster> enemyList, Player player, Map map, bool showBoundingBox = false, bool showVisionRadius = false)
        {
            this.enemyList = enemyList;
            this.player = player;
            this.map = map;
            this.tracerList = new List<Tracer>();
            this.bulletList = new List<Bullet>();
            this.showBoundingBox = showBoundingBox;
            this.showVisionRadius = showVisionRadius;
        }


        public void AddTracerEffect(Vector begin, Vector end)
        {
            tracerList.Add(new Tracer(begin, end, 20, new Color(0xff000000), new Color(0xffff00ff)));
        }

        private void checkCollisions()
        {
            
            
            
            // check-then-update approach
            foreach (Monster enemy in enemyList)
            {
                if(player.IsColliding(enemy))
                {
                    Console.WriteLine("Colliding!");
                    Vector playerVelocity = player.Velocity;
                    enemy.Transform.Position = new Vector(enemy.Transform.Position.X - enemy.Velocity.X, enemy.Transform.Position.Y - enemy.Velocity.Y);
                }
            }
        }

        public override void Load()
        {
            Camera.Instance.Active = true;
            foreach (Monster enemy in enemyList)
            {
                enemy.ShowBoundingBox = showBoundingBox;
                enemy.ShowVisionRadius = showVisionRadius;
            }

            player.ShowBoundingBox = showBoundingBox;

            RayTracedWeapon.RayTracedWeaponShotAction += RayTracedWeaponShotActionHandler;
            BulletWeapon.BulletWeaponShotAction += BulletWeaponShotActionHandler;
            player.Load();

        }
        public override void UnLoad()
        {
            Camera.Instance.Active = false;
            RayTracedWeapon.RayTracedWeaponShotAction -= RayTracedWeaponShotActionHandler;
            BulletWeapon.BulletWeaponShotAction -= BulletWeaponShotActionHandler;
            player.Unload();
        }

        private void RayTracedWeaponShotActionHandler(RayTracedWeapon weapon)
        {
            this.tracerList.Add(weapon.Tracer.Clone());
        }

        private void BulletWeaponShotActionHandler(BulletWeapon weapon)
        {
            this.bulletList.Add(weapon.SpawnBullet());
        }

        public override void Update()
        {
            // Camera Update
            Camera.Instance.Update();

            // Map Update
            map.Update();

            // Collisions
            checkCollisions();

            // Enemies Update
            foreach (Entity enemy in enemyList)
            {
                enemy.Update();
            }

            // Player Update
            player.Update();

            // Tracer Effects Update
            List<Tracer> currentTracerList = new List<Tracer>();
            foreach (Tracer tracer in tracerList)
            {
                if (!tracer.hasFinished)
                    currentTracerList.Add(tracer);
            }

            foreach (Tracer tracer in currentTracerList)
            {
                tracer.Update();
            }

            // Bullets Update
            List<Bullet> currentBulletList = new List<Bullet>();
            foreach (Bullet bullet in bulletList)
            {
                if (!bullet.isDead)
                    currentBulletList.Add(bullet);
            }

            foreach (Bullet bullet in currentBulletList)
            {
                bullet.Update();
            }

        }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
