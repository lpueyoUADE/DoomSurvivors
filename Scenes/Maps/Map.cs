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
using DoomSurvivors.Scenes.Maps.Placers;
using static DoomSurvivors.Entities.ExitSwitch;

namespace DoomSurvivors.Scenes.Maps
{
    public class Map : IRenderizable
    {        
        private string name;
        private Transform transform;

        private IntPtr floorTexture;
        private Vector spawnPoint;
        private ExitSwitchPlacer exitPoint;
        private List<MonsterPlacer> monsterList;
        private List<WallPlacer> wallList;
        private List<DecorationPlacer> decorList;
        private List<ItemPlacer> itemList;

        public Transform Transform => transform;
        public Vector SpawnPoint => spawnPoint;
        public ExitSwitchPlacer ExitPoint => exitPoint;
        public List<MonsterPlacer> MonsterList => monsterList;
        public List<WallPlacer> WallList => wallList;
        public List<DecorationPlacer> DecorList => decorList;
        public List<ItemPlacer> ItemList => itemList;

        private static int tileSize = 64;
        public static int TileSize => tileSize;

        public Map(
                string name, 
                string floorTexture,
                int width,
                int height, 
                Vector spawnPoint, 
                ExitSwitchPlacer exitPoint, 
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
            string fileName = "assets/Maps/Test Map/Test_map_001.json";
            string jsonString = File.ReadAllText(fileName);
            
            JSONMap jsonMap = JsonSerializer.Deserialize<JSONMap>(jsonString);
            
            JSONMapLayer floorLayer = jsonMap.layers.Find(layer => layer.name == "Floor");
            JSONMapLayer monstersLayer = jsonMap.layers.Find(layer => layer.name == "Monsters");
            JSONMapLayer wallsLayer = jsonMap.layers.Find(layer => layer.name == "Walls");
            JSONMapLayer decorationsLayer = jsonMap.layers.Find(layer => layer.name == "Decorations");
            JSONMapLayer itemsLayer = jsonMap.layers.Find(layer => layer.name == "Items");
            JSONMapLayer spawnPointLayer = jsonMap.layers.Find(layer => layer.name == "SpawnPoint");
            JSONMapLayer exitPointLayer = jsonMap.layers.Find(layer => layer.name == "ExitPoint");

            JSONTileset monsterTileset = jsonMap.tilesets.Find(tilset => tilset.name == "Monster Tiles");
            JSONTileset wallTileset = jsonMap.tilesets.Find(tilset => tilset.name == "Wall Tiles");
            JSONTileset decorationTileset = jsonMap.tilesets.Find(tilset => tilset.name == "Decoration Tiles");
            JSONTileset itemTileset = jsonMap.tilesets.Find(tilset => tilset.name == "Item Tiles");
            JSONTileset spawnPointTileset = jsonMap.tilesets.Find(tilset => tilset.name == "Spawn Point Tiles");
            JSONTileset exitPointTileset = jsonMap.tilesets.Find(tilset => tilset.name == "Exit Point Tiles");

            List<MonsterPlacer> monsterPlacers = new List<MonsterPlacer>();
            List <WallPlacer> wallPlacers = new List<WallPlacer>();
            List<DecorationPlacer> decorationPlacers = new List<DecorationPlacer>();
            List<ItemPlacer> itemPlacers = new List<ItemPlacer>();

            Vector spawnPoint = new Vector(0,0);
            ExitSwitchPlacer exitPoint = null;

            int index;
            int tileID;
            
            // Monsters
            for (int i = 0; i < monstersLayer.height; i++)
            {
                for (int j = 0; j < monstersLayer.width; j++)
                {
                    index = j + (monstersLayer.width * i); // Matrix to Array index
                    tileID = monstersLayer.data[index];
                    if (tileID > 0)
                        monsterPlacers.Add(new MonsterPlacer((MonsterType)tileID - monsterTileset.firstgid, j * tileSize, i * tileSize));
                }
            }

            // Walls
            for (int i = 0; i < wallsLayer.height; i++)
            {
                for (int j = 0; j < wallsLayer.width; j++)
                {
                    index = j + (wallsLayer.width * i); // Matrix to Array index
                    tileID = wallsLayer.data[index];
                    if (tileID > 0)
                        wallPlacers.Add(new WallPlacer((WallType)tileID - wallTileset.firstgid, j * tileSize, i * tileSize));
                }
            }

            // Items
            for (int i = 0; i < itemsLayer.height; i++)
            {
                for (int j = 0; j < itemsLayer.width; j++)
                {
                    index = j + (itemsLayer.width * i); // Matrix to Array index
                    tileID = itemsLayer.data[index];
                    if (tileID > 0)
                        itemPlacers.Add(new ItemPlacer((ItemType)tileID - itemTileset.firstgid, j * tileSize, i * tileSize));
                }
            }

            // Spawn Point
            for (int i = 0; i < spawnPointLayer.height; i++)
            {
                for (int j = 0; j < spawnPointLayer.width; j++)
                {
                    index = j + (spawnPointLayer.width * i); // Matrix to Array index
                    tileID = spawnPointLayer.data[index];
                    if (tileID > 0)
                        spawnPoint = new Vector (j * tileSize, i * tileSize);
                }
            }

            // Exit Point
            for (int i = 0; i < exitPointLayer.height; i++)
            {
                for (int j = 0; j < exitPointLayer.width; j++)
                {
                    index = j + (exitPointLayer.width * i); // Matrix to Array index
                    tileID = exitPointLayer.data[index];
                    if (tileID > 0)
                        exitPoint = new ExitSwitchPlacer((ExitSwitchType)tileID - exitPointTileset.firstgid, j * tileSize, i * tileSize);
                }
            }
            return new Map
            (
                name,
                "assets/Maps/Test Map/Test_map_Floor.png", // Hardcoded
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
