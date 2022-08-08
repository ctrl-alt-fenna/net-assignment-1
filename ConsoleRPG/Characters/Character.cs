using Assignment1.Attributes;
using Assignment1.CustomExceptions;
using Assignment1.Equipment;
using System.Text;
namespace Assignment1
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Inventory Inventory { get; set; }
        /// <summary>
        /// Base Stats for any given character
        /// </summary>
        public PrimaryAttribute PrimaryAttribute { get; set; }
        /// <summary>
        /// The LevelUp stats for any given character to add once a character levels up
        /// </summary>
        public PrimaryAttribute LevelUpPrimaryAttributes;
        /// <summary>
        /// The Total of primary attributes, including the Attributes given from the armour stats. 
        /// </summary>
        public PrimaryAttribute TotalAttribute { get; set; }
        /// <summary>
        /// Sets up characters to start with empty inventory and Level 1.
        /// </summary>
        /// <param name="name">String of username</param>
        public Character(string name)
        {
            TotalAttribute = PrimaryAttribute;
            Inventory = new Inventory();
            Level = 1;
            Name = name;
        }
        /// <summary>
        /// Levels up character (Implemented in specific classes)
        /// </summary>
        public abstract void LevelUp();
        /// <summary>
        /// Function to return Damage of character. Formula: (WeaponDPS (1 if no weapon equipped) * (1 + MainPrimaryAttribute / 100)) 
        /// </summary>
        /// <returns>Double of damage character can induce</returns>
        public abstract double Damage();
        /// <summary>
        /// Function to print charactersheet
        /// </summary>
        public void CharacterSheet()
        {
            StringBuilder sb = new StringBuilder(".........................\nCharacter Sheet:\n", 255);
            sb.Append(Name + ": Level " + Level + '\n');
            sb.Append("Strength: Base " + PrimaryAttribute.Strength + " + " + (TotalAttribute.Strength - PrimaryAttribute.Strength) + " (Equipment Bonus) \n");
            sb.Append("Dexterity: Base " + PrimaryAttribute.Dexterity + " + " + (TotalAttribute.Dexterity - PrimaryAttribute.Dexterity) + " (Equipment Bonus) \n");
            sb.Append("Intelligence: Base " + PrimaryAttribute.Intelligence + " + " + (TotalAttribute.Intelligence - PrimaryAttribute.Intelligence) + " (Equipment Bonus) \n");
            sb.Append("Damage: " + Damage() + "\n.........................");
            Console.WriteLine(sb);
        }
        /// <summary>
        /// Function to try to equip current item with current character
        /// </summary>
        /// <param name="item">Item object</param>
        /// <returns>A string if successful, or a custom exception if not</returns>
        /// <exception cref="InvalidItemException">Thrown if character is trying to access invalid item</exception>
        /// <exception cref="InvalidWeaponException">Thrown if character is of wrong class/level for given weapon</exception>
        /// <exception cref="InvalidArmourException">Thrown if character is of wrong class/level for given armour</exception>
        /// <exception cref="Exception">Thrown if somehow there was an error along the way</exception>
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
                            if (oldArmour.ArmourSlot == newArmour.ArmourSlot)
                            {
                                TotalAttribute -= oldArmour.PrimaryAttribute;
                                TotalAttribute += newArmour.PrimaryAttribute;
                            }
                        }
                        // Couldn't find armour in inventory so add TotalAttribute with new armour only
                        catch
                        {
                            TotalAttribute += newArmour.PrimaryAttribute;
                        }
                        Inventory.AddItem(item);
                        return "New armour equipped!";
                    }
                    Inventory.AddItem(item);
                    return "New weapon equipped!";
                }
                else if (item.ItemSlot == Item.Slot.ArmourSlot) throw new InvalidArmourException("Character type not allowed to equip current armour");
                else if (item.ItemSlot == Item.Slot.WeaponSlot) throw new InvalidWeaponException("Character type not allowed to equip current weapon");
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
