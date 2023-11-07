using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
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

        private static Transform tileCenteredTransform(int x, int y, int width, int height, int tileSize)
        {
            return new Transform(x + (tileSize - width)/2, y + (tileSize - height) / 2, width, height);
        }
        private static Item YellowSkullKey(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 13, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(147,212,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(161,212,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xFF7F1B00), new Color(0xFF7F1B80), 5)
            );
        }

        private static Item RedSkullKey(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 13, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(119,212,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(133,212,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xFF000000), new Color(0xFF000080), 5)
            );
        }

        private static Item BlueSkullKey(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 13, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(91,212, transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(105,212, transform.W, transform.H)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x0000CB00), new Color(0x0000CB80), 5)
            );
        }

        private static Item YellowKey(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 14, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(61,212, transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(76,212, transform.W, transform.H)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xD7BB4300), new Color(0xD7BB4380), 5)
            );
        }

        private static Item RedKey(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 14, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(31,212, transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(46,212, transform.W, transform.H)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xE3000000), new Color(0xE3000080), 5)
            );
        }

        private static Item BlueKey(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 14, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(1,212, transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(16,212, transform.W, transform.H)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x0000E300), new Color(0x0000E380), 5)
            );
        }

        private static Item Berserk(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 28, 19, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(408,150, transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x73000000), new Color(0x73000080), 5)
            );
        }

        private static Item Map(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 28, 27, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(292,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(321,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(350,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(379,150,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x53AF4700), new Color(0x53AF4780), 5)
            );
        }

        private static Item Goggles(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 28, 13, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(234,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(263,150,transform.W, transform.H)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xFF1F1F00), new Color(0xFF1F1F60), 5)
            );
        }

        private static Item Invulnerability(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 25, 25, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(130,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(156,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(182,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(208,150,transform.W, transform.H))
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
            Transform transform = tileCenteredTransform(x, y, 25, 25, Scenes.Map.TileSize);
            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(26,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(52,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(78,150,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(104,150,transform.W, transform.H))
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
            Transform transform = tileCenteredTransform(x, y, 24, 47, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(1,150,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x00FF0000), new Color(0x00FF0050), 5)
            );
        }

        private static Item MegaSphere(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 25, 25, Scenes.Map.TileSize);
            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(493,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(519,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(545,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(571,110,transform.W, transform.H))
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
            Transform transform = tileCenteredTransform(x, y, 25, 25, Scenes.Map.TileSize);
            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(389,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(415,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(441,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(467,110,transform.W, transform.H))
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
            Transform transform = tileCenteredTransform(x, y, 31, 17, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(325,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(357,110,transform.W, transform.H))
                    },
                    Animation.Speed.slow,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x0000E300), new Color(0x0000E350), 5)
            );
        }

        private static Item ArmorGreen(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 31, 17, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(261,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(293,110,transform.W, transform.H))
                    },
                    Animation.Speed.slow,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x67DF5F00), new Color(0x67DF5F80), 5)
            );
        }

        private static Item BigMedkit(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 28, 19, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(174,110,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item SmallMedKit(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 14, 15, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(129,110,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item Helmet(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 16, 15, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(61,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(78,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(95,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(112,110,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x4a9c3d00), new Color(0x4a9c3d80), 5)
            );
        }

        private static Item HealthPotion(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 14, 18, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(1,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(16,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(31,110,transform.W, transform.H)),
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(46,110,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x3737FF00), new Color(0x0000FF60), 5)
            );
        }

        private static Item Backpack(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 22, 29, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(208,66,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x775F4B00), new Color(0x775F4B80), 5)
            );
        }

        private static Item PlasmaBox(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 32, 21, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(175,66,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item PlasmaCell(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 17, 12, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(157,66,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item RocketBox(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 54, 21, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(102,66,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item Rocket(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 12, 27, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(89,66,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item ShellsBox(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 32, 12, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(56,66,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static  Item Shells(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 15, 7, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(40,66,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item Clip(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 9, 11, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(1,66,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item AmmoBox(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 28, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(11,66,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item BFG9000(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 61, 36, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(356,15,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xAAFF0000), new Color(0xAAFF0080), 5)
            );
        }

        private static Item PlasmaRifle(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 54, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(301,15,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0x00FFAA00), new Color(0x00FFAA80), 5)
            );
        }

        private static Item RocketLauncher(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 62, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(238,15,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item Chaingun(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 54, 16, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(183,15,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item SuperShotgun(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 54, 14, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(128,15,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item Shotgun(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 63, 12, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(64,15,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }

        private static Item Chainsaw(int x, int y)
        {
            Transform transform = tileCenteredTransform(x, y, 62, 24, Scenes.Map.TileSize);

            return new Item(
                transform,
                new Animation(
                    new List<Sprite> {
                        Engine.LoadImage("assets/Sprites/Items/Items.png", new Transform(1,15,transform.W, transform.H))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                ),
                new Halo(transform.Clone(), new Color(0xA7A7A700), new Color(0xA7A7A780), 5)
            );
        }
    }
}
