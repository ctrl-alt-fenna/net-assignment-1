using Assignment1.CustomExceptions;
using Assignment1.Equipment;

namespace Assignment1.Attributes
{
    public class Inventory
    {
        private Dictionary<Item.Slot, Item> inventoryDictionary { get; set; }
        /// <summary>
        /// Inventory in form Dictionary<Slot, Item> so looking up of items is easier
        /// </summary>
        public Inventory()
        {
            inventoryDictionary = new Dictionary<Item.Slot, Item>();
        }
        /// <summary>
        /// Function to add givenitem to current inventory (Overwrites any existing item in current slot)
        /// </summary>
        /// <param name="item">Item object</param>
        public void AddItem(Item item)
        {
            inventoryDictionary[item.ItemSlot] = item;
        }
        /// <summary>
        /// Function to check if there is an item in the given slot
        /// </summary>
        /// <param name="itemSlot">An item slot to check</param>
        /// <returns>True if there is an item in slot itemSlot, false if not</returns>
        public bool ContainsType(Item.Slot itemSlot)
        {
            if (inventoryDictionary == null) return false;
            return inventoryDictionary.ContainsKey(itemSlot);
        }
        /// <summary>
        /// Function to return the item from a given itemSlot
        /// </summary>
        /// <param name="itemSlot">An item slot to check</param>
        /// <returns>The item found or an exception if one occurs</returns>
        /// <exception cref="InvalidItemException">Thrown if method was called while inventory is null</exception>
        /// <exception cref="InvalidActionException">Thrown if method was called when slot is empty</exception>
        public Item GetItem(Item.Slot itemSlot)
        {
            if (inventoryDictionary == null) throw new InvalidItemException("Inventory is empty");
            try
            {

                if (itemSlot == Item.Slot.WeaponSlot)
                    return (Weapon)inventoryDictionary[itemSlot];
                if (itemSlot == Item.Slot.ArmourSlot)
                    return (Armour)inventoryDictionary[itemSlot];
                else return inventoryDictionary[itemSlot];
            }
            catch
            {
                throw new InvalidActionException("Cannot perform current inventory action");
            }
        }
    }
}
