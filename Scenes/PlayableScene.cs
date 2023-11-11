using DoomSurvivors.Entities;
using DoomSurvivors.Entities.Factories;
using DoomSurvivors.Entities.Weapons;
using DoomSurvivors.Scenes;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Ray> rayList;
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
            this.rayList = new List<Ray>();
            this.tracerList = new List<Tracer>();
            this.map = map;

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

        private void RayTracedWeaponShotActionHandler(RayTracedWeapon weapon, Ray ray)
        {
            //this.tracerList.Add(weapon.Tracer.Clone());
            this.rayList.Add(ray);
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

            // Dead Entities Update
            for (int i = 0; i < deadEntityList.Count; i++)
            {
                deadEntityList[i].Update();
                deadEntityList[i].Render();
            }

            // GameObject Update
            for (int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].Update();
                gameObjectList[i].Render();
            }

            // Check casted rays
            GameObject target = null;
            double targetDistance = float.MaxValue;
            double distance;
            double x, y;
            Vector hitPoint = new Vector(0,0);
            for (int i = 0; i < rayList.Count; i++)
            {
                Vector end = rayList[i].Origin + rayList[i].Direction * rayList[i].MaxDistance;

                for (int j = 0; j < gameObjectList.Count; j++)
                {
                    if(gameObjectList[j].IsRayCastCollidable)
                    {
                        if ((!(gameObjectList[j] is OffensiveEntity) || !rayList[i].IsOwnedBy((OffensiveEntity)gameObjectList[j])) && rayList[i].Intersects(gameObjectList[j].Transform, out x, out y))
                        {
                            distance = (gameObjectList[j].Transform.PositionCenter - rayList[i].Origin).Length;
                            if (distance < targetDistance)
                            {
                                target = gameObjectList[j];
                                targetDistance = distance;
                                hitPoint.X = x;
                                hitPoint.Y = y;
                            }
                        }
                    }
                }

                if (target != null)
                {
                    end = hitPoint;
                    if (target is OffensiveEntity)
                        ((OffensiveEntity)target).ApplyDamage(((RayTracedWeapon)rayList[i].Owner.CurrentWeapon).Damage);
                }

                Tracer tracer = rayList[i].Tracer.Clone();
                tracer.Origin = rayList[i].Origin;
                tracer.End = end;
                this.tracerList.Add(tracer);
            }

            // Tracer Effects Update
            foreach (Tracer tracer in tracerList)
            {
                tracer.Update();
            }

            tracerList.RemoveAll(tracer => tracer.hasFinished);
            gameObjectList.RemoveAll(gameObject => gameObject is Bullet && ((Bullet)gameObject).isDead);
            gameObjectList.RemoveAll(gameObject => gameObject is Item && ((Item)gameObject).Collected);

            deadEntityList.AddRange(gameObjectList.FindAll(gameObject => (gameObject is Monster && ((Monster)gameObject).IsDeath && ((Monster)gameObject).LeaveCorpse) || gameObject is Player && ((Player)gameObject).IsDeath));
            gameObjectList.RemoveAll(gameObject => gameObject is OffensiveEntity && ((OffensiveEntity)gameObject).IsDeath);

            rayList.Clear();
        }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
