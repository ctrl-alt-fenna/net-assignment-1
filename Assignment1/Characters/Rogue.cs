using Assignment1.Attributes;

namespace Assignment1.Characters
{
    public class Rogue : Character
    {
        private PrimaryAttribute levelUpPrimaryAttribute = new PrimaryAttribute
        {
            Strength = 2,
            Dexterity = 6,
            Intelligence = 1
        };

        public Rogue(string name) : base(name)
        {
            this.PrimaryAttribute = new PrimaryAttribute
            {
                Strength = 2,
                Dexterity = 6,
                Intelligence = 1
            };
            TotalAttribute = PrimaryAttribute;
        }
        public override void LevelUp()
        {
            PrimaryAttribute += levelUpPrimaryAttribute;
            Level++;
        }
    }
}
