using DoomSurvivors.Utilities;

using System.Collections.Generic;

using Tao.Sdl;

namespace DoomSurvivors.Entities.Animations
{
    public class Sprite
    {
        /*
            A dictionary for referencing the Sprites
            Key: Identifier
            Value: Surface Loaded from the assets folder and the ColorKey (Cyan or magenta).
        */
        private static Color cyanColorKey = new Color(0, 255, 255, 255);
        private static Color magentaColorKey = new Color(255, 0, 110, 255);
        public static Dictionary<string, SpriteReference > References = new Dictionary<string, SpriteReference>{
            { "Crosshair", new SpriteReference("assets/Crosshair/crosshair_3.png", cyanColorKey)},
            /*-------------------------------------------------------------------------------------*/
            { "TestMap", new SpriteReference("assets/Maps/Test Map/Test_map_Floor.png", cyanColorKey)},
            /*-------------------------------------------------------------------------------------*/
            { "Items", new SpriteReference("assets/Sprites/Items/Items.png", cyanColorKey)},
            /*-------------------------------------------------------------------------------------*/
            { "Zombie", new SpriteReference("assets/Sprites/Monsters/Zombie.png", cyanColorKey)},
            { "Shotguner", new SpriteReference("assets/Sprites/Monsters/Shotguner.png", cyanColorKey)},
            { "Chainguner", new SpriteReference("assets/Sprites/Monsters/Chainguner.png", cyanColorKey)},
            { "Wolfenstein", new SpriteReference("assets/Sprites/Monsters/Wolfenstein.png", cyanColorKey)},
            { "Imp", new SpriteReference("assets/Sprites/Monsters/Imp.png", cyanColorKey)},
            { "Pinky", new SpriteReference("assets/Sprites/Monsters/Pinky.png", cyanColorKey)},
            { "BaronOfHell", new SpriteReference("assets/Sprites/Monsters/BaronOfHell.png", cyanColorKey)},
            { "HellKnight", new SpriteReference("assets/Sprites/Monsters/HellKnight.png", cyanColorKey)},
            { "CacoDemon", new SpriteReference("assets/Sprites/Monsters/CacoDemon.png", cyanColorKey)},
            { "LostSoul", new SpriteReference("assets/Sprites/Monsters/LostSoul.png", cyanColorKey)},
            { "PainElemental", new SpriteReference("assets/Sprites/Monsters/PainElemental.png", cyanColorKey)},
            { "Mancubus", new SpriteReference("assets/Sprites/Monsters/Mancubus.png", cyanColorKey)},
            { "Arachnotron", new SpriteReference("assets/Sprites/Monsters/Arachnotron.png", cyanColorKey)},
            { "Revenant", new SpriteReference("assets/Sprites/Monsters/Revenant.png", cyanColorKey)},
            { "ArchVile", new SpriteReference("assets/Sprites/Monsters/ArchVile.png", cyanColorKey)},
            { "SpiderMasterMind", new SpriteReference("assets/Sprites/Monsters/SpiderMasterMind.png", cyanColorKey)},
            { "CyberDemon", new SpriteReference("assets/Sprites/Monsters/CyberDemon.png", cyanColorKey)},
            /*-------------------------------------------------------------------------------------*/
            { "Player", new SpriteReference("assets/Sprites/Player/DoomGuy.png", cyanColorKey)},
            /*-------------------------------------------------------------------------------------*/
            { "Proyectiles&Effects", new SpriteReference("assets/Sprites/Proyectiles&Effects/Proyectiles&Effects.png", magentaColorKey)},
            /*-------------------------------------------------------------------------------------*/
            { "Walls", new SpriteReference("assets/Sprites/Walls/wall_001.png", cyanColorKey)},
            { "ExitSwitch", new SpriteReference("assets/Sprites/ExitSwitch/Exit_Switch.png", cyanColorKey)},
        };

        private readonly string imageName;
        private readonly Transform transform;
        public Sdl.SDL_Rect rect;

        public string ImageName => imageName;
        public Transform Transform => transform;
        public Sprite(string imageName, Transform transform)
        {
            this.imageName = imageName;
            this.transform = transform;
            this.rect = new Sdl.SDL_Rect((short)transform.X, (short)transform.Y, (short)transform.W, (short)transform.H);
        }
    }
}
