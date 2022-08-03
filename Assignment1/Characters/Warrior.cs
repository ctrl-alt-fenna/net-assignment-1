using Assignment1.Attributes;

namespace Assignment1.Characters
{
    public class Warrior : Character
    {
        public Inventory inventory { get; set; }
        private PrimaryAttribute levelUpPrimaryAttribute = new PrimaryAttribute
        {
            Strength = 1,
            Dexterity = 4,
            Intelligence = 1
        };

        public Warrior(string name) : base(name)
        {
            inventory = new Inventory();
            PrimaryAttribute = new PrimaryAttribute
            {
                Strength = 5,
                Dexterity = 2,
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
