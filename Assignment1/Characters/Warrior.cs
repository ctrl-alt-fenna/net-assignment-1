using Assignment1.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Characters
{
    public class Warrior : Character
    {
        public PrimaryAttribute primaryAttribute { get; set; }
        private PrimaryAttribute levelUpPrimaryAttribute = new PrimaryAttribute
        {
            Strength = 1,
            Dexterity = 4,
            Intelligence = 1
        };

        public Warrior(string name) : base(name)
        {
            this.primaryAttribute = new PrimaryAttribute
            {
                Strength = 5,
                Dexterity = 2,
                Intelligence = 1
            };
        }
        public override void LevelUp()
        {
            this.primaryAttribute += this.levelUpPrimaryAttribute;
        }
    }
}
