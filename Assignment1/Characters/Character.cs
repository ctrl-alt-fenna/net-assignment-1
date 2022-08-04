using Assignment1.Attributes;
using Assignment1.CustomExceptions;
using Assignment1.Equipment;

namespace Assignment1
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Inventory Inventory { get; set; }
        public PrimaryAttribute PrimaryAttribute { get; set; }
        public PrimaryAttribute LevelUpPrimaryAttributes;
        public PrimaryAttribute TotalAttribute { get; set; }
        public Character(string name)
        {
            TotalAttribute = PrimaryAttribute;
            Inventory = new Inventory();
            Level = 1;
            Name = name;
        }
        public abstract void LevelUp();
        public abstract double Damage();
        public string EquipItem(Item item)
        {
            try
            {
                if (item.AllowEquip(this))
                {
                    if (item.ItemSlot == Item.Slot.ArmourSlot)
                    {
                        Armour newArmour = (Armour)item;
                        try
                        {
                            Armour oldArmour = (Armour)Inventory.GetItem(Item.Slot.ArmourSlot);
                            TotalAttribute -= oldArmour.PrimaryAttribute;
                            TotalAttribute += newArmour.PrimaryAttribute;
                        }
                        // Cannot fetch inventory, so add TotalAttribute anew
                        catch
                        {
                            TotalAttribute += newArmour.PrimaryAttribute;
                        }
                    }
                    Inventory.AddItem(item);
                    return "Item succesfully equiped!";
                }
                else if (item.ItemSlot == Item.Slot.ArmourSlot) throw new InvalidArmourException("Character type not allowed to equip current item");
                else if (item.ItemSlot == Item.Slot.WeaponSlot) throw new InvalidWeaponException("Character type not allowed to equip current item");
                else throw new InvalidItemException();
            }
            catch (InvalidWeaponException exception)
            {
                throw new InvalidWeaponException(exception.Message);
            }
            catch (InvalidArmourException exception)
            {
                throw new InvalidArmourException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
