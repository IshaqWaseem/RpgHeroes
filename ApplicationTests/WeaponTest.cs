using RpgHeroes.Classes;
using RpgHeroes.Enums;
using RpgHeroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class WeaponTest
    {
        [Fact]
        public void Weapon_Create_ShouldBeCorrect()
        {//When Weapon is created, it needs to have the correct name, required level, slot, weapon type, and damage

            //arrange
            Weapon GoldStaff = new("Gold staff", WeaponType.Staff, 5, 10);
            var expected = new object[] {"Gold Staff",5,slot.Weapon, WeaponType.Staff, 10};
            //act
            var actual = new object[] { "Gold Staff", GoldStaff.RequiredLevel, GoldStaff.ItemSlot, GoldStaff.ItemType, GoldStaff.WeaponDamage };
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
