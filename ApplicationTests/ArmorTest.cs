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
    public class ArmorTest
    {
        [Fact]
        public void Weapon_Create_ShouldBeCorrect()
        {//When Armor is created, it needs to have the correct name, required level, slot, armor type, and armor attributes

            //arrange
            Armor GenericLegs = new("Generic Legs", ArmorType.Cloth, 3, slot.Legs, 1, 4, 2);
            HeroAttribute expectedAttributes = new();
            expectedAttributes.AddAttributes(1, 4, 2);
            var expected = new object[] { "Generic Legs", 3, slot.Legs, ArmorType.Cloth, expectedAttributes.Strength, expectedAttributes.Dexterity, expectedAttributes.Intelligence };
            //act
            HeroAttribute stat = (HeroAttribute)GenericLegs.GetItemStat();
            var actual = new object[] { GenericLegs.Name, GenericLegs.RequiredLevel, GenericLegs.ItemSlot, GenericLegs.ItemType, stat.Strength,stat.Dexterity,stat.Intelligence };
            //assert8
            Assert.Equal(expected, actual);
        }
    }
}
