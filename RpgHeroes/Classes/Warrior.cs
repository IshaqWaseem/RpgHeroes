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
    public class Warrior:Hero
    {
        public Warrior(string name) : base(name)
        {
            ValidWeaponTypes.Add(WeaponType.Axe);
            ValidWeaponTypes.Add(WeaponType.Hammer);
            ValidWeaponTypes.Add(WeaponType.Sword);
            ValidArmorTypes.Add(ArmorType.Mail);
            ValidArmorTypes.Add(ArmorType.Plate);
            LevelAttributes.AddAttributes(5,2,1);
        }

        public override int Damage()
        {
            HeroAttribute stats = TotalAttributes();
            int damage = 1;
            foreach (var equipped in Equipment)
            {
                if (equipped.Value != null && equipped.Key == slot.Weapon)
                {
                    damage = (int)equipped.Value.GetItemStat();
                }
             
            }
            return (damage*(1+stats.Strength/100));
        }
        

        

        

        public override void LevelUp()
        {
            Level++;
            LevelAttributes.AddAttributes(3,2,1);
        }
        

    }
}
