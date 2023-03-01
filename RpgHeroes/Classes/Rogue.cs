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
    public class Rogue:Hero
    {
        public Rogue(string name) : base(name)
        {
            ValidWeaponTypes.Add(WeaponType.Dagger);
            ValidWeaponTypes.Add(WeaponType.Sword);
            ValidArmorTypes.Add(ArmorType.Mail);
            ValidArmorTypes.Add(ArmorType.Leather);
            LevelAttributes.AddAttributes(2,6,1);
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
            return (damage*(1+stats.Dexterity/100));
        }
        

        

        

        public override void LevelUp()
        {
            Level++;
            LevelAttributes.AddAttributes(1,4,1);
        }
        

    }
}
