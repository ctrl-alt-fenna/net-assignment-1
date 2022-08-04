using Assignment1.Attributes;
using Assignment1.Equipment;
namespace Assignment1.Characters
{
    public class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            PrimaryAttribute = new PrimaryAttribute
            {
                Strength = 5,
                Dexterity = 2,
                Intelligence = 1
            };
            LevelUpPrimaryAttributes = new PrimaryAttribute
            {
                Strength = 3,
                Dexterity = 2,
                Intelligence = 1
            };
            TotalAttribute = PrimaryAttribute;
        }
        public override void LevelUp()
        {
            TotalAttribute -= PrimaryAttribute;
            PrimaryAttribute += LevelUpPrimaryAttributes;
            TotalAttribute += PrimaryAttribute;
            Level++;
        }
        public override double Damage()
        {
            double currDamage = 1;
            if (Inventory.ContainsType(Item.Slot.WeaponSlot))
            {
                currDamage = ((Weapon)Inventory.GetItem(Item.Slot.WeaponSlot)).DPS();
            }
            currDamage = Math.Round(currDamage * (1 + TotalAttribute.Strength / 100),2);
            return currDamage;
        }
    }
}
