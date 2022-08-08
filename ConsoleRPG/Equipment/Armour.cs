using Assignment1.Attributes;
using Assignment1.CustomExceptions;
namespace Assignment1.Equipment
{
    public class Armour : Item
    {
        public PrimaryAttribute PrimaryAttribute { get; set; }
        public ArmourTypes ArmourType { get; set; }
        // The type of armour and the given slot it should be in
        public ArmourSlots? ArmourSlot { get; set; }
        public enum ArmourTypes
        {
            Cloth,
            Leather,
            Mail,
            Plate
        }
        public enum ArmourSlots
        {
            Body = 1,
            Head = 2,
            Legs = 3
        }
        /// <summary>
        /// Function to check if current charactertype matches allowed type for given armourtype
        /// </summary>
        /// <param name="c">A character object</param>
        /// <returns>True if character c is of correct class for given armour, false if not</returns>
        /// <exception cref="InvalidArmourException">Thrown if character c is not able/allowed to equip armour in the current state</exception>
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
            PrimaryAttribute = new PrimaryAttribute();
            ItemSlot = Slot.ArmourSlot;
        }

    }
}
