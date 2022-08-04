using Assignment1.CustomExceptions;
using Assignment1.Equipment;

namespace Assignment1.Attributes
{
    public class Inventory
    {
        private Dictionary<Item.Slot, Item>? inventoryDictionary { get; set; }
        public Inventory()
        {
            inventoryDictionary = new Dictionary<Item.Slot, Item>();
        }
        public void AddItem(Item item)
        {
            inventoryDictionary[item.ItemSlot] = item;
        }
        public bool ContainsType(Item.Slot itemSlot)
        {
            if (inventoryDictionary == null) return false;
            return inventoryDictionary.ContainsKey(itemSlot);
        }
        public Item GetItem(Item.Slot itemSlot)
        {
            if (inventoryDictionary == null) throw new InvalidItemException("Inventory is empty");
            if (itemSlot == Item.Slot.WeaponSlot)
                return (Weapon)inventoryDictionary[itemSlot];
            if (itemSlot == Item.Slot.ArmourSlot)
                return (Armour)inventoryDictionary[itemSlot];
            else return inventoryDictionary[itemSlot];
        }
    }
}
