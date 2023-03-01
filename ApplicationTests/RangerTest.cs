using RpgHeroes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class RangerTest
    {
        [Fact]
        public void Ranger_Creation_ShouldHaveCorrectAttributes()
        {
            //arrange
            Ranger Valla = new("Valla");
            int[] expected = new int[] { 1, 7, 1 };

            //act
            int[] actual = new int[] { Valla.TotalAttributes().Strength, Valla.TotalAttributes().Dexterity, Valla.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Ranger_LevelUp_ShouldHaveCorrectAttributes()
        {
            //arrange
            Ranger Valla = new("Valla");
            int[] expected = new int[] { 2, 12, 2 };
            Valla.LevelUp();
            //act
            int[] actual = new int[] { Valla.TotalAttributes().Strength, Valla.TotalAttributes().Dexterity, Valla.TotalAttributes().Intelligence };
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
