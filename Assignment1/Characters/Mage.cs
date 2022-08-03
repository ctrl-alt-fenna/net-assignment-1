using Assignment1.Attributes;
namespace Assignment1.Characters
{
    public class Mage : Character
    {
        public PrimaryAttribute levelUpPrimaryAttribute = new PrimaryAttribute
        {
            Strength = 1,
            Dexterity = 1,
            Intelligence = 5
        };
        public Mage(string name) : base(name)
        {
            PrimaryAttribute = new PrimaryAttribute
            {
                Strength = 1,
                Dexterity = 1,
                Intelligence = 8
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
