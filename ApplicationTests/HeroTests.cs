using RpgHeroes.Classes;
using RpgHeroes.Enums;
using RpgHeroes.InvalidException;
using RpgHeroes.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ApplicationTests
{
    public class HeroTests
    {
        [Fact]
        public void Hero_Create_ShouldBeCorrect()
        {
            //arrange
            Mage LiMing = new("LiMing");
            var expected = new object[] { "LiMing", 1, 1, 1, 8 };
            //act
            var actual = new object[] { LiMing.Name, LiMing.Level, LiMing.TotalAttributes().Strength, LiMing.TotalAttributes().Dexterity, LiMing.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
        
        
        [Fact]
        public void Hero_EquipValidWeapon_ShouldWork()
        { //A Hero should be able to equip a Weapon

            //arrange
            Ranger Valla = new("Valla");
            Weapon Crossbow = new("Valla's Bequest", WeaponType.Bow, 1, 10);
            Valla.Equip(Crossbow);
            var expected = Crossbow;
            //act
            var actual = Valla.Equipment[slot.Weapon];
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_EquipTooHighLevelWeapon_ShouldThrowInvalidWeaponException()
        { //the appropriate exceptions should be thrown if invalid (level requirement and type)

            //arrange
            Ranger Valla = new("Valla");
            Weapon Crossbow = new("Valla's Bequest", WeaponType.Bow, 5, 10);
            string expected = "Your level is too low to equip this weapon!";
            //act and assert
            Exception exception = Assert.Throws<InvalidWeaponException>(() =>Valla.Equip(Crossbow));
            string actual = exception.Message;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_EquipWrongWeaponType_ShouldThrowInvalidWeaponException()
        { //the appropriate exceptions should be thrown if invalid (level requirement and type)

            //arrange
            Ranger Valla = new("Valla");
            Weapon Staff = new("Gandalf's staff", WeaponType.Staff, 1, 10);
            string expected = "Your class can not equip this weapon type!";
            //act and assert
            Exception exception = Assert.Throws<InvalidWeaponException>(() => Valla.Equip(Staff));
            string actual = exception.Message;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_EquipValidArmor_ShouldWork()
        { //Hero should be able to equip Armor

            //arrange
            Ranger Valla = new("Valla");
            Armor GenericLegs = new("Generic Legs", ArmorType.Leather, 1, slot.Legs, 1, 4, 2);
            Valla.Equip(GenericLegs);
            var expected = GenericLegs;
            //act
            var actual = Valla.Equipment[slot.Legs];
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_EquipWrongArmorType_ShouldThrowInvalidArmorException()
        { //the appropriate exceptions should be thrown if invalid (level requirement and type)

            //arrange
            Ranger Valla = new("Valla");
            Armor GenericLegs = new("Generic Legs", ArmorType.Plate, 1, slot.Legs, 1, 4, 2);
            string expected = "Your class can not equip this armor type!";
            //act and assert 
            Exception exception = Assert.Throws<InvalidArmorException>(() => Valla.Equip(GenericLegs));
            string actual = exception.Message;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_EquipTooHighLevelArmor_ShouldThrowInvalidArmorException()
        { //the appropriate exceptions should be thrown if invalid (level requirement and type)

            //arrange
            Ranger Valla = new("Valla");
            Armor GenericLegs = new("Generic Legs", ArmorType.Leather, 5, slot.Legs, 1, 4, 2);
            string expected = "Your level is too low to equip this armor!";
            //act and assert
            Exception exception = Assert.Throws<InvalidArmorException>(() => Valla.Equip(GenericLegs));
            string actual = exception.Message;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_TotalAttributesWithNoArmor_ShouldBeCalculatedCorrectly()
        { //Total attributes should be calculated correctly With no equipment

            //arrange
            Ranger Valla = new("Valla");
            int[] expected = new int[] { 1, 7, 1 };
            //act 
            int[] actual = new int[] { Valla.TotalAttributes().Strength, Valla.TotalAttributes().Dexterity, Valla.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_TotalAttributesWithOneArmor_ShouldBeCalculatedCorrectly()
        { //Total attributes should be calculated correctly With one piece of armor

            //arrange
            Ranger Valla = new("Valla");
            Armor GenericLegs = new("Generic Legs", ArmorType.Leather, 1, slot.Legs, 10, 10, 10);
            Valla.Equip(GenericLegs);
            int[] expected = new int[] { 11, 17, 11 };
            //act 
            int[] actual = new int[] { Valla.TotalAttributes().Strength, Valla.TotalAttributes().Dexterity, Valla.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_TotalAttributesWithTwoArmor_ShouldBeCalculatedCorrectly()
        { //Total attributes should be calculated correctly With two pieces of armor

            //arrange
            Ranger Valla = new("Valla");
            Armor GenericLegs = new("Generic Legs", ArmorType.Leather, 1, slot.Legs, 10, 10, 10);
            Armor GenericChest = new("Generic Chest", ArmorType.Leather, 1, slot.Body, 10, 10, 10);
            Valla.Equip(GenericLegs);
            Valla.Equip(GenericChest);
            int[] expected = new int[] { 21, 27, 21 };
            //act 
            int[] actual = new int[] { Valla.TotalAttributes().Strength, Valla.TotalAttributes().Dexterity, Valla.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_TotalAttributesWithReplacedArmor_ShouldBeCalculatedCorrectly()
        { //Total attributes should be calculated correctly With a replaced piece of armor (equip armor, then equip new armor in the same slot)

            //arrange
            Ranger Valla = new("Valla");
            Armor LegendaryLegs = new("Generic Legs", ArmorType.Leather, 1, slot.Legs, 99, 99, 99);
            Armor CommonLegs = new("Generic Legs", ArmorType.Leather, 1, slot.Legs, 20, 20, 20);
            Valla.Equip(LegendaryLegs);
            Valla.Equip(CommonLegs);
            int[] expected = new int[] { 21, 27, 21 };
            //act 
            int[] actual = new int[] { Valla.TotalAttributes().Strength, Valla.TotalAttributes().Dexterity, Valla.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_HeroDamageNoWeapon_ShouldBeCalculatedCorrectly()
        { //Hero damage should be calculated properly No weapon equipped

            //arrange
            Warrior Aidan = new("Aidan");

            int expected = (1 * (1 + 5 / 100));
            //act 
            int actual = Aidan.Damage();
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_HeroDamageWithWeapon_ShouldBeCalculatedCorrectly()
        { //Hero damage should be calculated properly Weapon equipped

            //arrange
            Warrior Aidan = new("Aidan");
            Weapon CommonAxe = new("Common Axe", WeaponType.Axe, 1, 10);
            Aidan.Equip(CommonAxe);
            int expected = (10 * (1 + 5 / 100));
            //act 
            int actual = Aidan.Damage();
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_HeroDamageWithReplacedWeapon_ShouldBeCalculatedCorrectly()
        { //Hero damage should be calculated properly Replaced weapon equipped (equip a weapon then equip a new weapon)

            //arrange
            Warrior Aidan = new("Aidan");
            Weapon CommonAxe = new("Common Axe", WeaponType.Axe, 1, 10);
            Weapon TitaniteAxe = new("Common Axe", WeaponType.Axe, 1, 50);
            Aidan.Equip(CommonAxe);
            Aidan.Equip(TitaniteAxe);
            int expected = (50 * (1 + 5 / 100));
            //act 
            int actual = Aidan.Damage();
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_HeroDamageWithWeaponAndArmor_ShouldBeCalculatedCorrectly()
        { //Hero damage should be calculated properly Weapon and armor equipped

            //arrange
            Warrior Aidan = new("Aidan");
            Weapon CommonAxe = new("Common Axe", WeaponType.Axe, 1, 10);
            Armor LegendLegs = new("Legendary Legs", ArmorType.Plate, 1, slot.Body, 99, 99, 99);
            Aidan.Equip(CommonAxe);
            Aidan.Equip(LegendLegs);
            int expected = (10 * (1 + 104 / 100));
            //act 
            int actual = Aidan.Damage();
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Hero_Display_ShouldDisplayCorrectly()
        { //Heroes should display their state correctly

            //arrange
            Warrior Aidan = new("Aidan");
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Name: " + "Aidan");
            expected.AppendLine("Class: " + "Warrior");
            expected.AppendLine("Level: " + 1);
            expected.AppendLine("Total strength: " + 5);
            expected.AppendLine("Total dexterity: " + 2);
            expected.AppendLine("Total intelligence: " + 1);
            expected.Append("Total damage: " + 1);
            //act 
            StringBuilder actual = Aidan.Display();
            //assert
            Assert.Equal(expected.ToString(), actual.ToString());
        }
    }
}
