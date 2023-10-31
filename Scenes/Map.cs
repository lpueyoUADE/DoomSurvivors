using DoomSurvivors.Entities;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Text.Json;
using static DoomSurvivors.Entities.Monster;
using static DoomSurvivors.Entities.Wall;
using static DoomSurvivors.Entities.Decoration;
using static DoomSurvivors.Entities.Item;

namespace DoomSurvivors.Scenes
{
    public class Map : IRenderizable
    {        
        private string name;
        private Transform transform;

        private IntPtr floorTexture;
        private Vector spawnPoint;
        private Vector exitPoint;
        private List<MonsterPlacer> monsterList;
        private List<WallPlacer> wallList;
        private List<DecorationPlacer> decorList;
        private List<ItemPlacer> itemList;

        public Transform Transform { get { return this.transform; } }

        public Vector SpawnPoint
        {
            get { return spawnPoint; }
        }

        public List<MonsterPlacer> MonsterList
        {
            get { return this.monsterList; }
        }

        public List<WallPlacer> WallList
        {
            get { return this.wallList; }
        }

        public List<DecorationPlacer> DecorList
        {
            get { return this.decorList; }
        }
        public Map(
                string name, 
                string floorTexture,
                int width,
                int height, 
                Vector spawnPoint, 
                Vector exitPoint, 
                List<MonsterPlacer> monsters, 
                List<WallPlacer> walls, 
                List<DecorationPlacer> decorations,
                List<ItemPlacer> items
            )
        {
            this.name = name;
            this.floorTexture = Engine.LoadImage(floorTexture);
            this.transform = new Transform(0, 0, width, height);

            this.spawnPoint = spawnPoint;
            this.exitPoint = exitPoint;
            this.monsterList = monsters;
            this.wallList = walls;
            this.decorList = decorations;
            this.itemList = items;
        }

        public static Map CreateMap(string name)
        {
            string fileName = "assets/Maps/Test_map_001.json";
            string jsonString = File.ReadAllText(fileName);
            JSONMap jsonMap = JsonSerializer.Deserialize<JSONMap>(jsonString);
            JSONMapLayer floorLayer = jsonMap.layers.Find(layer => layer.name == "Floor");
            JSONMapLayer monstersLayer = jsonMap.layers.Find(layer => layer.name == "Monsters");
            JSONMapLayer wallsLayer = jsonMap.layers.Find(layer => layer.name == "Walls");
            JSONMapLayer decorationsLayer = jsonMap.layers.Find(layer => layer.name == "Decorations");
            JSONMapLayer itemsLayer = jsonMap.layers.Find(layer => layer.name == "Items");
            JSONMapLayer spawnPointLayer = jsonMap.layers.Find(layer => layer.name == "SpawnPoint");
            JSONMapLayer exitPointLayer = jsonMap.layers.Find(layer => layer.name == "ExitPoint");
            
            List<MonsterPlacer> monsterPlacers = new List<MonsterPlacer>
            {
                new MonsterPlacer(MonsterType.Zombie, 200, 200),  // Hardcoded
                new MonsterPlacer(MonsterType.Zombie, 400, 300),  // Hardcoded
            };
            List <WallPlacer> wallPlacers = new List<WallPlacer>();
            List<DecorationPlacer> decorationPlacers = new List<DecorationPlacer>();
            List<ItemPlacer> itemPlacers = new List<ItemPlacer>();

            Vector spawnPoint = new Vector(800, 800); // Hardcoded
            Vector exitPoint = new Vector(1500, 1500); // Hardcoded

            int index;
            int tileID;
            int tileSize = 64; // Hardcoded

            for (int i = 0; i < wallsLayer.height; i++)
            {
                for (int j = 0; j < wallsLayer.width; j++)
                {
                    index = j + (wallsLayer.width * i); // Matrix to Array index
                    tileID = wallsLayer.data[index];
                    if (tileID > 0)
                        wallPlacers.Add(new WallPlacer(WallType.TestWall/*Type Hardcoded*/, j * tileSize, i*tileSize));
                }
            }

            return new Map
            (
                name,
                "assets/Maps/Test_map_001.png", // Hardcoded
                floorLayer.width * jsonMap.tilewidth,
                floorLayer.height * jsonMap.tileheight,
                spawnPoint,
                exitPoint,
                monsterPlacers,
                wallPlacers,
                decorationPlacers,
                itemPlacers
            );
        }
        public void Render()
        {
            Vector newPosition = Camera.Instance.WorldToCameraPosition(this.transform.Position);
            Engine.Draw(floorTexture, newPosition.X, newPosition.Y, transform.W, transform.H);
        }

        public void Update()
        {
            this.Render();
        }

    }
}
