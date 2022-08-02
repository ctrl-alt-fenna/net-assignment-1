using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Character(string name)
        {
            this.Name = name;
        }
        public abstract void LevelUp();
    }
}
