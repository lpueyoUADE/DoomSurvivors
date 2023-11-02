using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoomSurvivors.Entities.Item;

namespace DoomSurvivors.Entities.Factories
{
    public static class ItemFactory
    {
        public static Item CreateItem(ItemPlacer itemPlacer)
        {
            Item newItem;

            switch (itemPlacer.itemType) {
                case ItemType.Chainsaw:
                    newItem = Chainsaw((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Shotgun:
                    newItem = Shotgun((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.SuperShotgun:
                    newItem = SuperShotgun((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Chaingun:
                    newItem = Chaingun((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.RocketLauncher:
                    newItem = RocketLauncher((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.PlasmaRifle:
                    newItem = PlasmaRifle((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.BFG9000:
                    newItem = BFG9000((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Clip:
                    newItem = Clip((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.AmmoBox:
                    newItem = AmmoBox((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Shells:
                    newItem = Shells((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.ShellsBox:
                    newItem = ShellsBox((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Rocket:
                    newItem = Rocket((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.RocketBox:
                    newItem = RocketBox((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.PlasmaCell:
                    newItem = PlasmaCell((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.PlasmaBox:
                    newItem = PlasmaBox((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Backpack:
                    newItem = Backpack((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.HealthPotion:
                    newItem = HealthPotion((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Helmet:
                    newItem = Helmet((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.SmallMedKit:
                    newItem = SmallMedKit((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.BigMedkit:
                    newItem = BigMedkit((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.ArmorGreen:
                    newItem = ArmorGreen((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.ArmorBlue:
                    newItem = ArmorBlue((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.SoulSphere:
                    newItem = SoulSphere((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.MegaSphere:
                    newItem = MegaSphere((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.RadiationSuit:
                    newItem = RadiationSuit((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Invicibility:
                    newItem = Invicibility((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Invulnerability:
                    newItem = Invulnerability((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Goggles:
                    newItem = Goggles((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Map:
                    newItem = Map((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.Berserk:
                    newItem = Berserk((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.BlueKey:
                    newItem = BlueKey((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.RedKey:
                    newItem = RedKey((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.YellowKey:
                    newItem = YellowKey((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.BlueSkullKey:
                    newItem = BlueSkullKey((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.RedSkullKey:
                    newItem = RedSkullKey((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;
                case ItemType.YellowSkullKey:
                    newItem = YellowSkullKey((int)itemPlacer.position.X, (int)itemPlacer.position.Y);
                    break;

                default:
                    throw new ArgumentException("Inexistent Item Type");

            }
            return newItem;
        }

        private static Item YellowSkullKey(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item RedSkullKey(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item BlueSkullKey(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item YellowKey(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item RedKey(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item BlueKey(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Berserk(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Map(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Goggles(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Invulnerability(int x, int y)
        {
            Transform transform = new Transform(x, y, 25, 25);

            return new Item(
                transform,
                new Animation(
                    new List<IntPtr> {
                        Engine.LoadImage("assets/Sprites/Items/Invulnerability/Idle_1.png"),
                        Engine.LoadImage("assets/Sprites/Items/Invulnerability/Idle_2.png"),
                        Engine.LoadImage("assets/Sprites/Items/Invulnerability/Idle_3.png"),
                        Engine.LoadImage("assets/Sprites/Items/Invulnerability/Idle_4.png"),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x4a9c3d00), new Color(0x4a9c3d80),5)
            );
        }

        private static Item Invicibility(int x, int y)
        {
            Transform transform = new Transform(x, y, 25, 25);
            return new Item(
                transform,
                new Animation(
                    new List<IntPtr> {
                        Engine.LoadImage("assets/Sprites/Items/Invicibility/Idle_1.png"),
                        Engine.LoadImage("assets/Sprites/Items/Invicibility/Idle_2.png"),
                        Engine.LoadImage("assets/Sprites/Items/Invicibility/Idle_3.png"),
                        Engine.LoadImage("assets/Sprites/Items/Invicibility/Idle_4.png")
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xFF000000), new Color(0xFF000080), 5)
            );
        }

        private static  Item RadiationSuit(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item MegaSphere(int x, int y)
        {
            Transform transform = new Transform(x, y, 25, 25);
            return new Item(
                transform,
                new Animation(
                    new List<IntPtr> {
                        Engine.LoadImage("assets/Sprites/Items/MegaSphere/Idle_1.png"),
                        Engine.LoadImage("assets/Sprites/Items/MegaSphere/Idle_2.png"),
                        Engine.LoadImage("assets/Sprites/Items/MegaSphere/Idle_3.png"),
                        Engine.LoadImage("assets/Sprites/Items/MegaSphere/Idle_4.png")
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xa78f7700), new Color(0xa78f7780), 5)
            );
        }

        private static Item SoulSphere(int x, int y)
        {
            Transform transform = new Transform(x, y, 25, 25);
            return new Item(
                transform,
                new Animation(
                    new List<IntPtr> {
                        Engine.LoadImage("assets/Sprites/Items/SoulSphere/Idle_1.png"),
                        Engine.LoadImage("assets/Sprites/Items/SoulSphere/Idle_2.png"),
                        Engine.LoadImage("assets/Sprites/Items/SoulSphere/Idle_3.png"),
                        Engine.LoadImage("assets/Sprites/Items/SoulSphere/Idle_4.png")
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x00000000), new Color(0x0000FF80), 5)
            );
        }

        private static Item ArmorBlue(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item ArmorGreen(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item BigMedkit(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item SmallMedKit(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Helmet(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item HealthPotion(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Backpack(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item PlasmaBox(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item PlasmaCell(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item RocketBox(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Rocket(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item ShellsBox(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static  Item Shells(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Clip(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item AmmoBox(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item BFG9000(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item PlasmaRifle(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item RocketLauncher(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Chaingun(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item SuperShotgun(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Shotgun(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static Item Chainsaw(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
