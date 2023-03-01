using RpgHeroes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHeroes.Items
{
    public class Weapon:Item
    {
        public int WeaponDamage { get; protected set; }
        public Weapon(string name,WeaponType weaponType, int requiredLevel, int weaponDamage) : base(name, requiredLevel) {
            ItemSlot = slot.Weapon;
            ItemType = weaponType;
            WeaponDamage = weaponDamage;
        }
        public override object GetItemStat()
        {
            return WeaponDamage;
        }
    }
}
