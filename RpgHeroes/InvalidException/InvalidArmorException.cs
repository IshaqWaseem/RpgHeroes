using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHeroes.InvalidException
{
    public class InvalidArmorException: Exception
    {
        public InvalidArmorException() { }
        public InvalidArmorException(string message) : base(message) { }
        public InvalidArmorException(string message, Exception inner)
    : base(message, inner) { }
    }
}