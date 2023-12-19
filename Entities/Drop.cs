using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoomSurvivors.Entities.Item;

namespace DoomSurvivors.Entities
{
    public class Drop
    {
        private ItemType itemType;
        private float dropChance;

        public ItemType ItemType => itemType;
        public  float DropChance { get { return dropChance;} }
        public Drop(ItemType itemType, float dropChance)
        {
            this.itemType = itemType;
            this.dropChance = dropChance;
        }

        public bool Roll()
        {
            Random rnd = new Random();
            return rnd.Next(0,1) <= this.dropChance;
        }
    }
}
