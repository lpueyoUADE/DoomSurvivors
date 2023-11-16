
using DoomSurvivors.Entities.Animations;
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
                case DecorationType.ImpaledZombieAnimated:
                    decoration = ImpaledZombieAnimated(decorationPlacer.Position);
                    break;
                case DecorationType.ImpaledSkulls:
                    decoration = ImpaledSkulls(decorationPlacer.Position);
                    break;
                case DecorationType.ImpaledSingleSkull:
                    decoration = ImpaledSingleSkull(decorationPlacer.Position);
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

        private static Decoration FlamingBarrel(Vector position)
        {
            Transform transform = new Transform(position, new Vector(37, 53));

            return new Decoration(
                transform,
                new Animation(
                    new List<Sprite> {
                        new Sprite("Decoration", new Transform(1, 130, 37, 53)),
                        new Sprite("Decoration", new Transform(39, 130, 34, 53)),
                        new Sprite("Decoration", new Transform(74, 130, 36, 51))
                    },
                    Animation.Speed.fast,
                    true,
                    false
                )
            );
        }

        private static Decoration SmallCandle(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration BigCandle(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration SkullCandle(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration TallColumn(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration GreenTallColumn(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration GreenSmallColumn(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration GreenHeartColumn(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration RedTallColumn(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration RedSmallColumn(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration RedSkullColumn(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration EvilEye(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration GibPuddle1(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration GibPuddle2(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration GibPuddle3(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration GibPuddle4(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpseAnimated(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse1(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse2(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse3(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse4(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse5(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse6(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse7(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse8(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse9(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HangingCorpse10(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration HellThingy(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration ImpaledZombieStill(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration ImpaledZombieAnimated(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration ImpaledSkulls(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration ImpaledSingleSkull(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration SmallBlueTorch(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration SmallGreenTorch(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration SmallRedTorch(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration BigBlueTorch(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration BigGreenTorch(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration BigRedTorch(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration BigBlueLamp(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration SmallBlueLamp(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration Lamp(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration BigTree(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration SmallTree(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration GrayStump(Vector position)
        {
            throw new NotImplementedException();
        }

        private static Decoration Stump(Vector position)
        {
            throw new NotImplementedException();
        }
    }
}
