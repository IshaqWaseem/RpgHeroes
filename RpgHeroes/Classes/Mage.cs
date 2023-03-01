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
    public class Mage:Hero
    {
        public Mage(string name) : base(name)
        {
            ValidWeaponTypes.Add(WeaponType.Staff);
            ValidWeaponTypes.Add(WeaponType.Wand);
            ValidArmorTypes.Add(ArmorType.Cloth);
            LevelAttributes.AddAttributes(1,1,8);
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
            return (damage*(1+stats.Intelligence/100));
        }
        

        

        

        public override void LevelUp()
        {
            Level++;
            LevelAttributes.AddAttributes(1,1,5);
        }
        

    }
}
