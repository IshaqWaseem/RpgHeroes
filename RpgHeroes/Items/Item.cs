using RpgHeroes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHeroes.Items
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public int RequiredLevel { get; protected set; }
        public object ItemType { get; protected set; }
        public slot ItemSlot { get; protected set; }

        public Item(string name, int requiredLevel){
            Name = name;        
            RequiredLevel = requiredLevel;
}
        public abstract object GetItemStat();
    }
}
