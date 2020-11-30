using System;
using System.Collections.Generic;
using System.Text;

namespace Dierentuin_I.Models
{
    sealed class Monkey : Animal
    {
        public override int Eat()
        {
            return Energy + 10;
        }
        public override int EnergyUse()
        {
            return Energy - 2;
        }
    }
}
