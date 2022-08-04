using Assignment1.Attributes;
using Assignment1.Equipment;
namespace Assignment1.Characters
{
    public class Warrior : Character
    {
        public Inventory inventory { get; set; }
        public Warrior(string name) : base(name)
        {
            inventory = new Inventory();
            LevelUpPrimaryAttributes = new PrimaryAttribute
            {
                Strength = 1,
                Dexterity = 4,
                Intelligence = 1
            };
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
            PrimaryAttribute += LevelUpPrimaryAttributes;
            Level++;
        }
        public override double Damage()
        {
            double currDamage = 1;
            if (Inventory.ContainsType(Item.Slot.WeaponSlot))
            {
                currDamage = ((Weapon)Inventory.GetItem(Item.Slot.WeaponSlot)).DPS();
            }
            currDamage = (currDamage * (1 + TotalAttribute.Strength / 100));
            Console.WriteLine(Name + " damage enemy for " + currDamage + " damage points!");
            return currDamage;
        }
    }
}
