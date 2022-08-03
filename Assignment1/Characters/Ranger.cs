using Assignment1.Attributes;

namespace Assignment1.Characters
{
    public class Ranger : Character
    {
        private PrimaryAttribute levelUpPrimaryAttribute =
            new PrimaryAttribute
            {
                Strength = 1,
                Dexterity = 5,
                Intelligence = 1
            };
        public Ranger(string name) : base(name)
        {
            PrimaryAttribute = new PrimaryAttribute
            {
                Strength = 1,
                Dexterity = 7,
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
