using Assignment1.Attributes;
using Assignment1.CustomExceptions;
namespace Assignment1.Equipment
{
    public class Armour : Item
    {
        public PrimaryAttribute PrimaryAttribute { get; set; }
        public ArmourTypes ArmourType { get; set; }
        public ArmourSlots ArmourSlot { get; set; }
        public enum ArmourSlots
        {
            ArmourSlot_Head = 1,
            ArmourSlot_Body = 2,
            ArmourSlot_Legs = 3
        }
        public enum ArmourTypes
        {
            Cloth,
            Leather,
            Mail,
            Plate
        }
        public override bool AllowEquip(Character c)
        {
            if (c.Level >= ItemRequiredLevel)
            {
                if (ArmourType == ArmourTypes.Cloth)
                {
                    return (c is Characters.Mage);
                }
                if (ArmourType == ArmourTypes.Leather)
                {
                    return (c is Characters.Ranger || c is Characters.Rogue);
                }
                if (ArmourType == ArmourTypes.Mail)
                {
                    return (c is Characters.Ranger ||
                            c is Characters.Rogue ||
                            c is Characters.Warrior);
                }
                if (ArmourType == ArmourTypes.Plate)
                {
                    return c is Characters.Warrior;
                }
            }
            throw new InvalidArmourException("Current level is too low to equip item: " + ItemRequiredLevel + " > " + c.Level);
        }
        public Armour()
        {
            ItemSlot = Slot.ArmourSlot;
        }

    }
}
