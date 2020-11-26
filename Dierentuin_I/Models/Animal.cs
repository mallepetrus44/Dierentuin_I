using System;
using System.Collections.Generic;
using System.Text;

namespace Dierentuin_I.Models
{
    abstract class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Energy { get; set; }
        public AnimalType TypeOfAnimal { get; set; }
        public virtual void Eat()
        {
            Energy += 25;
        }
    }
}
