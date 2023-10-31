using System.Windows;

namespace DoomSurvivors.Entities
{
    public class Item
    {
        public enum ItemType
        {
            TestItem
        }
        public struct ItemPlacer
        {
            public ItemType itemType;
            public Vector position;

            public ItemPlacer(ItemType itemType, Vector position) : this()
            {
                this.itemType = itemType;
                this.position = position;
            }
        }
    }
}
