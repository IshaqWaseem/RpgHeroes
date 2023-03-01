using RpgHeroes.Classes;
using RpgHeroes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHeroes.Items
{
    public class Armor:Item
    {
        protected HeroAttribute ArmorAttributes = new();
        
        public Armor(string name, ArmorType ArmorType, int requiredLevel, slot itemSlot, int strength, int dexterity, int intelligence) : base(name, requiredLevel) {
            this.ItemSlot = itemSlot;
            ItemType = ArmorType;
            ArmorAttributes.AddAttributes(strength, dexterity, intelligence);
        }
        public override object GetItemStat()
        {
            return ArmorAttributes;
        }
        }
}
