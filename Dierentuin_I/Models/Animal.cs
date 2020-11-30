using System;
using System.Collections.Generic;
using System.Text;

namespace Dierentuin_I.Models
{
    abstract class Animal
    {
        public string Name { get; set; }
        public int Energy { get; set; }
        public string TypeOfAnimal { get; set; }

        public virtual int Eat()
        {
            return Energy += 25;
        }
        public abstract int EnergyUse();
    }
}
