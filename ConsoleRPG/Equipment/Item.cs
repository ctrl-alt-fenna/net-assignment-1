namespace Assignment1.Equipment
{
    public abstract class Item
    {
        public string? ItemName { get; set; }
        // The type of item and the given slot it should be in
        public Slot ItemSlot { get; set; }
        // Level Character must be to be able to equip current item
        public int ItemRequiredLevel { get; set; }
        public enum Slot
        {
            WeaponSlot,
            ArmourSlot,
            EquipmentSlot
        }
        public abstract bool AllowEquip(Character c);
    }
}
