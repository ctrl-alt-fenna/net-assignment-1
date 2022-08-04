using Assignment1.Attributes;
using Assignment1.Equipment;
namespace Assignment1.Characters
{
    public class Rogue : Character
    {
        public Rogue(string name) : base(name)
        {
            LevelUpPrimaryAttributes = new PrimaryAttribute
            {
                Strength = 2,
                Dexterity = 6,
                Intelligence = 1
            };
            PrimaryAttribute = new PrimaryAttribute
            {
                Strength = 2,
                Dexterity = 6,
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
            currDamage = (currDamage * (1 + TotalAttribute.Dexterity / 100));
            Console.WriteLine(Name + " damage enemy for " + currDamage + " damage points!");
            return currDamage;
        }
    }
}
