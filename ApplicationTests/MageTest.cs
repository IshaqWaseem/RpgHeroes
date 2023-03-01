using RpgHeroes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class MageTest
    {
        [Fact]
        public void Mage_Creation_ShouldHaveCorrectAttributes()
        {
            //arrange
            Mage LiMing = new("LiMing");
            int[] expected = new int[] { 1, 1, 8 };

            //act
            int[] actual = new int[] { LiMing.TotalAttributes().Strength, LiMing.TotalAttributes().Dexterity, LiMing.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Mage_LevelUp_ShouldHaveCorrectAttributes()
        {
            //arrange
            Mage LiMing = new("LiMing");
            int[] expected = new int[] { 2, 2, 13 };
            LiMing.LevelUp();
            //act
            int[] actual = new int[] { LiMing.TotalAttributes().Strength, LiMing.TotalAttributes().Dexterity, LiMing.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
