using Assignment1.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Characters
{
    public class Ranger : Character
    {
        public PrimaryAttribute primaryAttribute { get; set; }
        private PrimaryAttribute levelUpPrimaryAttribute =
            new PrimaryAttribute
            {
                Strength = 1,
                Dexterity = 5,
                Intelligence = 1
            };

        public Ranger(string name) : base(name)
        {
            this.primaryAttribute = new PrimaryAttribute
            {
                Strength = 1,
                Dexterity = 7,
                Intelligence = 1
            };
        }
        public override void LevelUp()
        {
            this.primaryAttribute += this.levelUpPrimaryAttribute;
        }
    }
}
