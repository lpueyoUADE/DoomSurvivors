using DoomSurvivors.Entities;
using DoomSurvivors.Entities.Factories;
using DoomSurvivors.Main;
using DoomSurvivors.Scenes;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using static DoomSurvivors.Entities.Item;
using static DoomSurvivors.Entities.Monster;
using static DoomSurvivors.Entities.Wall;

namespace DoomSurvivors
{
    internal class PlayableScene : Scene
    {
        private Map map;
        private List<Tracer> tracerList;
        private List<GameObject> gameObjectList;
        private List<GameObject> deadEntityList;
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

        public PlayableScene(Map map, bool drawBoundingBox = false, bool drawVisionRadius = false)
        {
            this.gameObjectList = new List<GameObject>();
            this.deadEntityList = new List<GameObject>();
            this.map = map;

            this.tracerList = new List<Tracer>();
            this.drawBoundingBox = drawBoundingBox;
            this.drawVisionRadius = drawVisionRadius;
        }

        public void AddGameObject(GameObject gameObject)
        {
            this.gameObjectList.Add(gameObject);
        }

        private void checkCollisions()
        {
            // check-then-update approach
            // TODO: Implement either Quadtrees or Fixed Grid.
            // O(n**2)
            for (int i = 0; i < gameObjectList.Count; i++)
            {
                GameObject gameObject = gameObjectList[i];
                if (gameObject.CollisionType == CollisionType.Disabled)
                    continue;

                for (int j = i + 1; j < gameObjectList.Count; j++) // j = i + 1 Para no checkear A con B y despues B con A
                {
                    if (i == j)
                        continue;

                    GameObject other = gameObjectList[j];
                    if (other.CollisionType == CollisionType.Disabled)
                        continue;

                    if (gameObject.Transform.isColliding(other.Transform))
                        CollisionController.HandleCollision(gameObject, other);
                }
            }
        }

        public override void Load()
        {
            Camera.Instance.Active = true;

            // Load Player
            Player player = PlayerFactory.Player((int)map.SpawnPoint.X, (int)map.SpawnPoint.Y);
            player.DrawBoundingBox = drawBoundingBox;
            player.Load();
            AddGameObject(player);

            // Load Monsters
            foreach (MonsterPlacer monsterPlacer in map.MonsterList)
            {
                Monster monster = MonsterFactory.CreateMonster(monsterPlacer);
                monster.DrawBoundingBox = drawBoundingBox;
                monster.ShowVisionRadius = drawVisionRadius;
                monster.Target = player;
                AddGameObject(monster);
            }

            // Load Walls
            foreach (WallPlacer wallPlacer in map.WallList)
            {
                Wall wall = WallFactory.CreateWall(wallPlacer);
                wall.DrawBoundingBox = drawBoundingBox;
                AddGameObject(wall);
            }

            // Load Items
            foreach (ItemPlacer itemPlacer in map.ItemList)
            {
                Item item = ItemFactory.CreateItem(itemPlacer);
                item.DrawBoundingBox = drawBoundingBox;
                AddGameObject(item);
            }

            // Load Decor

            // Set Camera
            Camera.Instance.setCamera(player, new Transform(0, 0));

            // Add Event Handlers
            RayTracedWeapon.RayTracedWeaponShotAction += RayTracedWeaponShotActionHandler;
            BulletWeapon.BulletWeaponShotAction += BulletWeaponShotActionHandler;

        }
        public override void UnLoad()
        {
            Camera.Instance.Active = false;

            // Remove Event Handlers
            RayTracedWeapon.RayTracedWeaponShotAction -= RayTracedWeaponShotActionHandler;
            BulletWeapon.BulletWeaponShotAction -= BulletWeaponShotActionHandler;

            Player player = gameObjectList.OfType<Player>().FirstOrDefault();
            player?.Unload();
        }

        private void RayTracedWeaponShotActionHandler(RayTracedWeapon weapon)
        {
            this.tracerList.Add(weapon.Tracer.Clone());
        }

        private void BulletWeaponShotActionHandler(BulletWeapon weapon)
        {
            this.gameObjectList.Add(weapon.SpawnBullet());
        }

        public override void Update()
        {
            // Camera Update
            Camera.Instance.Update();

            // Map Update
            map.Update();

            // Collisions
            checkCollisions();

            // Add newly spawn 
            // Dead Entities Update
            for (int i = 0; i < deadEntityList.Count; i++)
            {
                deadEntityList[i].Update();
            }

            // GameObject Update
            for (int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].Update();
                gameObjectList[i].Render();
            }

            // Tracer Effects Update
            foreach (Tracer tracer in tracerList)
            {
                tracer.Update();
            }

            tracerList.RemoveAll(tracer => tracer.hasFinished);
            gameObjectList.RemoveAll(gameObject => gameObject is Bullet && ((Bullet)gameObject).isDead);
            
            deadEntityList.AddRange(gameObjectList.FindAll(gameObject => gameObject is OffensiveEntity && ((OffensiveEntity)gameObject).State == State.Death));
            gameObjectList.RemoveAll(gameObject => gameObject is OffensiveEntity && ((OffensiveEntity)gameObject).State == State.Death);
        }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
