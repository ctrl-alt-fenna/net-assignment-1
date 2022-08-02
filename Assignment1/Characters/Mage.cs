using Assignment1.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment1.Characters
{
    class Mage : Character
    {
        public PrimaryAttribute primaryAttribute {
            get; set; 
        }
        public PrimaryAttribute levelUpPrimaryAttribute = new PrimaryAttribute 
        {   Strength = 1, 
            Dexterity = 1,
            Intelligence = 5 };
        public Mage(string name) : base(name)
        {
            this.primaryAttribute = new Attributes.PrimaryAttribute
            {
                Strength = 1,
                Dexterity = 1,
                Intelligence = 8
            };
        }
        public override void LevelUp()
        {
            this.primaryAttribute += this.levelUpPrimaryAttribute; 
        }
    }
}
