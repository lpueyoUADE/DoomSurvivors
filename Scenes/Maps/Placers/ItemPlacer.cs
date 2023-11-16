using static DoomSurvivors.Entities.Item;

namespace DoomSurvivors.Scenes.Maps.Placers
{
    public class ItemPlacer : Placer<ItemType>
    {
        public ItemPlacer(ItemType placerType, int x, int y) : base(placerType, x, y)
        {
        }
    }
}
