namespace Assignment1.Equipment
{
    public abstract class Item
    {
        public string? ItemName { get; set; }
        public Slot ItemSlot { get; set; }
        public int ItemRequiredLevel { get; set; }
        public enum Slot
        {
            WeaponSlot,
            ArmourSlot,
            EquipmentSlot
        }
        /// <summary>
        /// Function to check whether a character is able to equip item. A character may equip an
        /// item if the RequiredLevel is lower or equal to the character Level and if the character class
        /// matches the ItemAllowedCharacter
        /// </summary>
        /// <param name="c">A character object</param>
        /// <returns>True if Character c is allowed to equip the item, or exception if they can not</returns>
        /// <exception cref="InvalidWeaponException">A custom exception, with its message explaining the reason why Character c may not equip item</exception>
        public abstract bool AllowEquip(Character c);
    }
}
