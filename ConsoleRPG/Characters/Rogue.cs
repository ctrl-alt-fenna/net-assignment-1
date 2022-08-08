using Assignment1.Attributes;
using Assignment1.Equipment;
namespace Assignment1.Characters
{
    public class Rogue : Character
    {
        public Rogue(string name) : base(name)
        {
            PrimaryAttribute = new PrimaryAttribute
            {
                Strength = 2,
                Dexterity = 6,
                Intelligence = 1
            };
            LevelUpPrimaryAttributes = new PrimaryAttribute
            {
                Strength = 1,
                Dexterity = 4,
                Intelligence = 1
            };
            TotalAttribute = PrimaryAttribute;
        }
        public override void LevelUp()
        {
            PrimaryAttribute += LevelUpPrimaryAttributes;
            TotalAttribute += LevelUpPrimaryAttributes;
            Level++;
        }
        public override double Damage()
        {
            double currDamage = 1;
            if (Inventory.ContainsType(Item.Slot.WeaponSlot))
            {
                currDamage = ((Weapon)Inventory.GetItem(Item.Slot.WeaponSlot)).DPS();
            }
            currDamage = Math.Round((currDamage * (1 + TotalAttribute.Dexterity / 100)), 2);
            return currDamage;
        }
    }
}
