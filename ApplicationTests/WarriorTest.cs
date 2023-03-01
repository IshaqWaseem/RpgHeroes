using RpgHeroes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class WarriorTest
    {
        [Fact]
        public void Warrior_Creation_ShouldHaveCorrectAttributes()
        {
            //arrange
            Warrior Aidan = new("Aidan");
            int[] expected = new int[] { 5, 2, 1 };

            //act
            int[] actual = new int[] { Aidan.TotalAttributes().Strength, Aidan.TotalAttributes().Dexterity, Aidan.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Warrior_LevelUp_ShouldHaveCorrectAttributes()
        {
            //arrange
            Warrior Aidan = new("Aidan");
            int[] expected = new int[] { 8, 4, 2 };
            Aidan.LevelUp();
            //act
            int[] actual = new int[] { Aidan.TotalAttributes().Strength, Aidan.TotalAttributes().Dexterity, Aidan.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
