using RpgHeroes.Enums;
using RpgHeroes.InvalidException;
using RpgHeroes.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHeroes.Classes
{
    public abstract class Hero
    {
        public string Name { get; protected set; }
        public int Level { get; protected set; }
        protected HeroAttribute LevelAttributes = new();
        protected List<WeaponType> ValidWeaponTypes = new();
        protected List<ArmorType> ValidArmorTypes = new();
        public Dictionary<slot, Item> Equipment = new();
        public Hero(string name){
            this.Name = name;
            Level = 1;
            foreach(slot item in Enum.GetValues(typeof(slot)))
            {
                Equipment.Add(item, null);
            }
        }
        public  HeroAttribute TotalAttributes()
        {
            HeroAttribute total = new();
            total.AddAttributes(LevelAttributes.Strength, LevelAttributes.Dexterity, LevelAttributes.Intelligence);

            foreach (var equipped in Equipment)
            {
                if (equipped.Value != null && equipped.Key != slot.Weapon)
                {
                    HeroAttribute stat = (HeroAttribute)equipped.Value.GetItemStat();
                    total.AddAttributes(stat.Strength, stat.Dexterity, stat.Intelligence);

                };
            }
            return total;

        }
        public abstract void LevelUp();
        public void Equip(Item item)
        {
            switch (item.ItemSlot)
            {
                case slot.Weapon:
                    if (!ValidWeaponTypes.Contains((WeaponType)item.ItemType)) { throw new InvalidWeaponException("Your class can not equip this weapon type!"); }
                    if (item.RequiredLevel > Level) { throw new InvalidWeaponException("Your level is too low to equip this weapon!"); }
                    Equipment[item.ItemSlot] = item;
                    break;
                case slot.Head:
                case slot.Body:
                case slot.Legs:
                    if (!ValidArmorTypes.Contains((ArmorType)item.ItemType)) { throw new InvalidArmorException("Your class can not equip this armor type!"); }
                    if (item.RequiredLevel > Level) { throw new InvalidArmorException("Your level is too low to equip this armor!"); }
                    Equipment[item.ItemSlot] = item;
                    break;
            }
        }
        public abstract int Damage();
        public StringBuilder Display()
        {
            StringBuilder stats = new StringBuilder();
            stats.AppendLine("Name: " + Name);
            stats.AppendLine("Class: " + this.GetType().Name);
            stats.AppendLine("Level: " + Level);
            stats.AppendLine("Total strength: " + TotalAttributes().Strength);
            stats.AppendLine("Total dexterity: " + TotalAttributes().Dexterity);
            stats.AppendLine("Total intelligence: " + TotalAttributes().Intelligence);
            stats.Append("Total damage: "+Damage());
            return stats;
        }
        

    }
}
