using System;
using System.Collections.Generic;
using System.Text;

namespace Dierentuin_I.Models
{
    sealed class Elephant : Animal
    {
        public override int Eat()
        {
            return Energy + 50;
        }
        public override int EnergyUse()
        {
            return Energy - 5;
        }

    }
}
