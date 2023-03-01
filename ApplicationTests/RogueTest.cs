using RpgHeroes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class RogueTest
    {
        [Fact]
        public void Rogue_Creation_ShouldHaveCorrectAttributes()
        {
            //arrange
            Rogue Natalya = new("Natalya");
            int[] expected = new int[] { 2, 6, 1 };

            //act
            int[] actual = new int[] { Natalya.TotalAttributes().Strength, Natalya.TotalAttributes().Dexterity, Natalya.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Rogue_LevelUp_ShouldHaveCorrectAttributes()
        {
            //arrange
            Rogue Natalya = new("Natalya");
            int[] expected = new int[] { 3, 10, 2 };
            Natalya.LevelUp();
            //act
            int[] actual = new int[] { Natalya.TotalAttributes().Strength, Natalya.TotalAttributes().Dexterity, Natalya.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
