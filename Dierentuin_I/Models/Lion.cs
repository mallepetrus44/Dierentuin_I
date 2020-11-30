using System;
using System.Collections.Generic;
using System.Text;

namespace Dierentuin_I.Models
{
    sealed class Lion : Animal
    {
        public override int Eat()
        {
            return Energy + 25;
        }
        public override int EnergyUse()
        {
            return Energy - 10;
        }
    }
}
