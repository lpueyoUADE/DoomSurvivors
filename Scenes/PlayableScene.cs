using DoomSurvivors.Entities;
using DoomSurvivors.Entities.Factories;
using DoomSurvivors.Entities.Weapons;
using DoomSurvivors.Scenes;
using DoomSurvivors.Scenes.Maps;
using DoomSurvivors.Scenes.Maps.Placers;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using static DoomSurvivors.Entities.Item;
using static DoomSurvivors.Entities.Monster;
using static DoomSurvivors.Entities.Particle;
using static DoomSurvivors.Entities.Wall;

namespace DoomSurvivors
{
    internal class PlayableScene : Scene
    {
        private Map map;
        private List<Tracer> tracerList;
        private List<Ray> rayList;
        private List<Particle> particleList;
        private List<GameObject> interactableList;
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

        private void ClearLists()
        {
            gameObjectList.Clear();
            deadEntityList.Clear();
            particleList.Clear();
            interactableList.Clear();
            rayList.Clear();
            tracerList.Clear();
        }

        public PlayableScene(Map map, bool drawBoundingBox = false, bool drawVisionRadius = false)
        {
            this.gameObjectList = new List<GameObject>();
            this.deadEntityList = new List<GameObject>();
            this.particleList = new List<Particle>();
            this.interactableList = new List<GameObject>();
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

        public void AddInteractable(GameObject gameObject)
        {
            this.interactableList.Add(gameObject);
        }
        private void checkCollisions()
        {
            // check-then-update approach
            // TODO: Implement either Quadtrees or Fixed Grid.
            // O(n**2)

            for (int i = 0; i < gameObjectList.Count; i++)
            {
                for (int j = i + 1; j < gameObjectList.Count; j++) // j = i + 1 Para no checkear A con B y despues B con A
                {
                    GameObject gameObject = gameObjectList[i];
                    GameObject other = gameObjectList[j];

                    if (!(gameObject is Entity) && !(other is Entity)) // Do not check Game Objects that dont move.
                        continue;

                    if (gameObject.Transform.isColliding(other.Transform))
                        CollisionController.HandleCollision(gameObject, other);
                }
            }
        }
        public void CheckRayCollisions()
        {
            GameObject target = null;
            double targetDistance = float.MaxValue;
            double distance;
            double x, y;
            Vector hitPoint = new Vector(0, 0);
            for (int i = 0; i < rayList.Count; i++)
            {
                Vector end = rayList[i].Origin + rayList[i].Direction * rayList[i].MaxDistance;

                for (int j = 0; j < gameObjectList.Count; j++)
                {
                    if (gameObjectList[j].IsRayCastCollidable)
                    {
                        if (
                            (!(gameObjectList[j] is OffensiveEntity) || !rayList[i].IsOwnedBy((OffensiveEntity)gameObjectList[j])) && 
                            (!(gameObjectList[j] is OffensiveEntity) || !((OffensiveEntity)gameObjectList[j]).IsDying) && 
                            rayList[i].Intersects(gameObjectList[j].Transform, out x, out y))
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
                    {
                        ((OffensiveEntity)target).ApplyDamage(((RayTracedWeapon)rayList[i].Owner.CurrentWeapon).Damage);
                        particleList.Add(ParticleFactory.CreateParticle(ParticleType.Blood, hitPoint));
                    }
                    else if (target is Wall || target is Decoration)
                        particleList.Add(ParticleFactory.CreateParticle(ParticleType.WallHit, hitPoint));
                }

                Tracer tracer = rayList[i].Tracer.Clone();
                tracer.Origin = rayList[i].Origin;
                tracer.End = end;
                this.tracerList.Add(tracer);
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

            // Load Exit Point
            ExitSwitch exitSwitch = ExitSwitchFactory.CreateExitSwitch(map.ExitPoint);
            exitSwitch.DrawBoundingBox = drawBoundingBox;
            AddGameObject(exitSwitch);
            AddInteractable(exitSwitch);

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
            foreach (DecorationPlacer decorationPlacer in map.DecorationList)
            {
                Decoration decoration = DecorationFactory.CreateDecoration(decorationPlacer);
                decoration.DrawBoundingBox = drawBoundingBox;
                AddGameObject(decoration);
            }

            // Set Camera
            Camera.Instance.setCamera(player, new Transform(0, 0));

            // Add Event Handlers
            RayTracedWeapon.RayTracedWeaponShotAction += RayTracedWeaponShotActionHandler;
            BulletWeapon.BulletWeaponShotAction += BulletWeaponShotActionHandler;
            Bullet.BulletHitAction += BulletHitActionHandler;
            Player.InteractAction += InteractActionHandler;
        }
        public override void UnLoad()
        {
            Camera.Instance.Active = false;

            // Remove Event Handlers
            RayTracedWeapon.RayTracedWeaponShotAction -= RayTracedWeaponShotActionHandler;
            BulletWeapon.BulletWeaponShotAction -= BulletWeaponShotActionHandler;
            Bullet.BulletHitAction -= BulletHitActionHandler;
            Player.InteractAction -= InteractActionHandler;

            Player player = gameObjectList.OfType<Player>().FirstOrDefault();
            player?.Unload();

            ClearLists();
        }

        private void RayTracedWeaponShotActionHandler(RayTracedWeapon weapon, Ray ray)
        {
            this.rayList.Add(ray);
        }

        private void BulletWeaponShotActionHandler(BulletWeapon weapon)
        {
            this.gameObjectList.Add(weapon.SpawnBullet());
        }

        private void BulletHitActionHandler(Particle particle)
        {
            this.particleList.Add(particle);
        }
        private void InteractActionHandler(Vector position, int radius)
        {
            foreach (ExitSwitch interactable in interactableList)
            {
                if (Math.Abs((interactable.Transform.PositionCenter - position).Length) <= radius)
                    interactable.OnInteract();
            }
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
            CheckRayCollisions();

            // Tracer Effects Update
            foreach (Tracer tracer in tracerList)
                tracer.Update();

            foreach (Particle particle in particleList)
            {
                particle.Update();
                particle.Render();
            }

            tracerList.RemoveAll(tracer => tracer.hasFinished);
            gameObjectList.RemoveAll(gameObject => gameObject is Bullet && ((Bullet)gameObject).isDead);
            gameObjectList.RemoveAll(gameObject => gameObject is Item && ((Item)gameObject).Collected);

            deadEntityList.AddRange(gameObjectList.FindAll(gameObject => (gameObject is Monster && ((Monster)gameObject).IsDeath && ((Monster)gameObject).LeaveCorpse) || gameObject is Player && ((Player)gameObject).IsDeath));
            gameObjectList.RemoveAll(gameObject => gameObject is OffensiveEntity && ((OffensiveEntity)gameObject).IsDeath);

            particleList.RemoveAll(particle => particle.HasEnded);

            rayList.Clear();
        }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
