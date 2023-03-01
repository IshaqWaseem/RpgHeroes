using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHeroes.Classes
{
    public class HeroAttribute
    {
        public int Strength { get; protected set; }
        public int Dexterity { get; protected set; }
        public int Intelligence { get; protected set; }
        public HeroAttribute()
        {
            Strength = 0;
            Dexterity = 0;
            Intelligence = 0;
        }
        public void AddAttributes(int strength, int dexterity, int intelligence)
        {
            Strength += strength;
            Dexterity += dexterity;
            Intelligence += intelligence;
        }

    }
   
    
}
