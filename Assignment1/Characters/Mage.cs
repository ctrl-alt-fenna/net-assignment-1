using Assignment1.Attributes;
using Assignment1.Equipment;
namespace Assignment1.Characters
{
    public class Mage : Character
    {
        public Mage(string name) : base(name)
        {
            LevelUpPrimaryAttributes = new PrimaryAttribute
            {
                Strength = 1,
                Dexterity = 1,
                Intelligence = 5
            };
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
            currDamage = (currDamage * (1 + TotalAttribute.Intelligence / 100));
            Console.WriteLine(Name + " damage enemy for " + currDamage + " damage points!");
            return currDamage;
        }
    }
}
