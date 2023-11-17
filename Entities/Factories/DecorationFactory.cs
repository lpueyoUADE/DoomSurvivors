
using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Scenes.Maps;
using DoomSurvivors.Scenes.Maps.Placers;
using System;
using System.Collections.Generic;
using System.Windows;
using static DoomSurvivors.Entities.Decoration;

namespace DoomSurvivors.Entities.Factories
{
    public static class DecorationFactory
    {
        public static Decoration CreateDecoration(DecorationPlacer decorationPlacer)
        {
            Decoration decoration;

            switch (decorationPlacer.PlacerType)
            {
                case DecorationType.FlamingBarrel:
                    decoration = FlamingBarrel(decorationPlacer.Position);
                    break;
                case DecorationType.SmallCandle:
                    decoration = SmallCandle(decorationPlacer.Position);
                    break;
                case DecorationType.BigCandle:
                    decoration = BigCandle(decorationPlacer.Position);
                    break;
                case DecorationType.SkullCandle:
                    decoration = SkullCandle(decorationPlacer.Position);
                    break;
                case DecorationType.TallColumn:
                    decoration = TallColumn(decorationPlacer.Position);
                    break;
                case DecorationType.GreenTallColumn:
                    decoration = GreenTallColumn(decorationPlacer.Position);
                    break;
                case DecorationType.GreenSmallColumn:
                    decoration = GreenSmallColumn(decorationPlacer.Position);
                    break;
                case DecorationType.GreenHeartColumn:
                    decoration = GreenHeartColumn(decorationPlacer.Position);
                    break;
                case DecorationType.RedTallColumn:
                    decoration = RedTallColumn(decorationPlacer.Position);
                    break;
                case DecorationType.RedSmallColumn:
                    decoration = RedSmallColumn(decorationPlacer.Position);
                    break;
                case DecorationType.RedSkullColumn:
                    decoration = RedSkullColumn(decorationPlacer.Position);
                    break;
                case DecorationType.EvilEye:
                    decoration = EvilEye(decorationPlacer.Position);
                    break;
                case DecorationType.GibPuddle1:
                    decoration = GibPuddle1(decorationPlacer.Position);
                    break;
                case DecorationType.GibPuddle2:
                    decoration = GibPuddle2(decorationPlacer.Position);
                    break;
                case DecorationType.GibPuddle3:
                    decoration = GibPuddle3(decorationPlacer.Position);
                    break;
                case DecorationType.GibPuddle4:
                    decoration = GibPuddle4(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpseAnimated:
                    decoration = HangingCorpseAnimated(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse1:
                    decoration = HangingCorpse1(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse2:
                    decoration = HangingCorpse2(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse3:
                    decoration = HangingCorpse3(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse4:
                    decoration = HangingCorpse4(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse5:
                    decoration = HangingCorpse5(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse6:
                    decoration = HangingCorpse6(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse7:
                    decoration = HangingCorpse7(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse8:
                    decoration = HangingCorpse8(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse9:
                    decoration = HangingCorpse9(decorationPlacer.Position);
                    break;
                case DecorationType.HangingCorpse10:
                    decoration = HangingCorpse10(decorationPlacer.Position);
                    break;
                case DecorationType.HellThingy:
                    decoration = HellThingy(decorationPlacer.Position);
                    break;
                case DecorationType.ImpaledZombieStill:
                    decoration = ImpaledZombieStill(decorationPlacer.Position);
                    break;
                case DecorationType.ImpaledSkulls:
                    decoration = ImpaledSkulls(decorationPlacer.Position);
                    break;
                case DecorationType.ImpaledSingleSkull:
                    decoration = ImpaledSingleSkull(decorationPlacer.Position);
                    break;
                case DecorationType.ImpaledZombieAnimated:
                    decoration = ImpaledZombieAnimated(decorationPlacer.Position);
                    break;
                case DecorationType.SmallBlueTorch:
                    decoration = SmallBlueTorch(decorationPlacer.Position);
                    break;
                case DecorationType.SmallGreenTorch:
                    decoration = SmallGreenTorch(decorationPlacer.Position);
                    break;
                case DecorationType.SmallRedTorch:
                    decoration = SmallRedTorch(decorationPlacer.Position);
                    break;
                case DecorationType.BigBlueTorch:
                    decoration = BigBlueTorch(decorationPlacer.Position);
                    break;
                case DecorationType.BigGreenTorch:
                    decoration = BigGreenTorch(decorationPlacer.Position);
                    break;
                case DecorationType.BigRedTorch:
                    decoration = BigRedTorch(decorationPlacer.Position);
                    break;
                case DecorationType.BigBlueLamp:
                    decoration = BigBlueLamp(decorationPlacer.Position);
                    break;
                case DecorationType.SmallBlueLamp:
                    decoration = SmallBlueLamp(decorationPlacer.Position);
                    break;
                case DecorationType.Lamp:
                    decoration = Lamp(decorationPlacer.Position);
                    break;
                case DecorationType.BigTree:
                    decoration = BigTree(decorationPlacer.Position);
                    break;
                case DecorationType.SmallTree:
                    decoration = SmallTree(decorationPlacer.Position);
                    break;
                case DecorationType.GrayStump:
                    decoration = GrayStump(decorationPlacer.Position);
                    break;
                case DecorationType.Stump:
                    decoration = Stump(decorationPlacer.Position);
                    break;

                default:
                    throw new ArgumentException("Inexistent Decoration Type");
            }


            return decoration;
        }

        private static Transform FromBottomUpTransform(Vector position, Vector size, int tilesetSize)
        {
            return new Transform((int)position.X, (int)(position.Y + tilesetSize - size.Y), (int)size.X, (int)size.Y);
        }
        private static Decoration FlamingBarrel(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(37, 53), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(1, 130, 37, 53)),
                        new Sprite("Decoration", new Transform(39, 130, 34, 53)),
                        new Sprite("Decoration", new Transform(74, 130, 36, 51))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration SmallCandle(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(16, 15), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(1, 198, 16, 15))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration BigCandle(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(29, 61), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(18, 198, 29, 61))
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration SkullCandle(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(41, 43), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(48, 198, 41, 43)),
                        new Sprite("Decoration", new Transform(90, 198, 41, 43)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration TallColumn(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(38, 128), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(1, 274, 38, 128)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration GreenTallColumn(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(35, 53), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(40, 274, 35, 53)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration GreenSmallColumn(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(35, 40), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(76, 274, 35, 40)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration GreenHeartColumn(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(35, 45), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(112, 274, 35, 45)),
                        new Sprite("Decoration", new Transform(148, 274, 35, 46)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration RedTallColumn(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(35, 53), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(184, 274, 35, 53)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration RedSmallColumn(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(35, 40), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(220, 274, 35, 40)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration RedSkullColumn(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(35, 49), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(256, 274, 35, 49)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration EvilEye(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(48, 60), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(1, 417, 48, 60)),
                        new Sprite("Decoration", new Transform(50, 417, 47, 59)),
                        new Sprite("Decoration", new Transform(98, 417, 46, 60)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration GibPuddle1(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(29, 8), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(1, 492, 29, 8)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration GibPuddle2(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(41, 7), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(31, 492, 41, 7)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration GibPuddle3(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(32, 3), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(73, 492, 32, 3)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration GibPuddle4(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(55, 10), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(106, 492, 55, 10)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpseAnimated(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(30, 68), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(1, 517, 30, 68)),
                      new Sprite("Decoration", new Transform(32, 517, 30, 68)),
                      new Sprite("Decoration", new Transform(63, 517, 30, 68)),
                    },
                    Animation.Speed.regular,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse1(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(41, 84), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(1, 586, 41, 84)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse2(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(39, 79), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(43, 586, 39, 79)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse3(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(18, 67), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(83, 586, 18, 67)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse4(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(14, 53), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(102, 586, 14, 53)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse5(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(22, 88), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(1, 671, 22, 88)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse6(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(22, 88), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(24, 671, 22, 85)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse7(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(22, 64), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(47, 671, 22, 64)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse8(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(22, 64), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(70, 671, 22, 64)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse9(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(22, 57), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(93, 671, 22, 57)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HangingCorpse10(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(22, 61), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(116, 671, 22, 61)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration HellThingy(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(32, 35), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(1, 774, 32, 35)),
                      new Sprite("Decoration", new Transform(34, 774, 32, 35)),
                      new Sprite("Decoration", new Transform(67, 774, 32, 35)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration ImpaledZombieStill(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(40, 66), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(1, 824, 40, 66)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }
        private static Decoration ImpaledSkulls(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(41, 67), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(42, 824, 41, 67)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration ImpaledSingleSkull(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(41, 56), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(84, 824, 41, 56)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration ImpaledZombieAnimated(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(35, 66), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(126, 824, 35, 66)),
                      new Sprite("Decoration", new Transform(162, 824, 38, 66)),
                    },
                    Animation.Speed.regular,
                    true,
                    false
                )
            );
        }


        private static Decoration SmallBlueTorch(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(17, 73), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(1, 906, 17, 73)),
                      new Sprite("Decoration", new Transform(19, 906, 17, 68)),
                      new Sprite("Decoration", new Transform(37, 906, 16, 68)),
                      new Sprite("Decoration", new Transform(54, 906, 17, 74)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration SmallGreenTorch(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(17, 73), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(72, 906, 17, 73)),
                      new Sprite("Decoration", new Transform(90, 906, 17, 68)),
                      new Sprite("Decoration", new Transform(108, 906, 16, 68)),
                      new Sprite("Decoration", new Transform(125, 906, 17, 74)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration SmallRedTorch(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(17, 73), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(143, 906, 17, 73)),
                      new Sprite("Decoration", new Transform(161, 906, 17, 68)),
                      new Sprite("Decoration", new Transform(179, 906, 16, 68)),
                      new Sprite("Decoration", new Transform(196, 906, 17, 74)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration BigBlueTorch(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(26, 96), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(1, 995, 26, 96)),
                      new Sprite("Decoration", new Transform(28, 995, 26, 96)),
                      new Sprite("Decoration", new Transform(55, 995, 26, 96)),
                      new Sprite("Decoration", new Transform(82, 995, 26, 97)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration BigGreenTorch(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(26, 96), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(109, 995, 26, 96)),
                      new Sprite("Decoration", new Transform(136, 995, 26, 91)),
                      new Sprite("Decoration", new Transform(163, 995, 26, 91)),
                      new Sprite("Decoration", new Transform(190, 995, 26, 97)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration BigRedTorch(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(26, 96), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(217, 995, 26, 96)),
                      new Sprite("Decoration", new Transform(244, 995, 26, 91)),
                      new Sprite("Decoration", new Transform(271, 995, 26, 91)),
                      new Sprite("Decoration", new Transform(298, 995, 26, 97)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration BigBlueLamp(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(23, 80), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(1, 1093, 23, 80)),
                      new Sprite("Decoration", new Transform(25, 1093, 23, 80)),
                      new Sprite("Decoration", new Transform(49, 1093, 23, 80)),
                      new Sprite("Decoration", new Transform(73, 1093, 23, 80)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration SmallBlueLamp(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(21, 60), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(97, 1093, 21, 60)),
                      new Sprite("Decoration", new Transform(119, 1093, 21, 60)),
                      new Sprite("Decoration", new Transform(141, 1093, 21, 60)),
                      new Sprite("Decoration", new Transform(163, 1093, 21, 60)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration Lamp(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(23, 48), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(185, 1093, 23, 48)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration BigTree(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(124, 124), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(1, 1188, 124, 124)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration SmallTree(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(51, 70), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(126, 1188, 51, 70)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration GrayStump(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(29, 47), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(178, 1188, 29, 47)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }

        private static Decoration Stump(Vector position)
        {
            Transform transform = FromBottomUpTransform(position, new Vector(47, 47), Map.TileSize);

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                      new Sprite("Decoration", new Transform(208, 1188, 47, 47)),
                    },
                    Animation.Speed.faster,
                    true,
                    false
                )
            );
        }
    }
}
