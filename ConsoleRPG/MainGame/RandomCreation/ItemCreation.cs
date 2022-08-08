using Assignment1.Equipment;
namespace Assignment1.MainGame.RandomCreation
{
    public class ItemCreation
    {
        // Variables for random item creation
        static Random random = new Random();
        const int MAX_DAMAGE = 25;
        const int MAX_ATTACKS_PER_SECOND = 15;

        #region ITEM NAMES
        // These arrays can be used to randomly select an itemname
        public static string[] axeNames = { "Lumberjacks beware...",
                                     "Scares of anyone by it's weight",
                                     "Need some lumber?",
                                     "Heavy... and strong!"};
        public static string[] bowNames = { "A string on a stick!",
                                     "Precise in the right hands",
                                     "Bullseye...",
                                     "Repurposeable as a harp!"};
        public static string[] daggerNames = { "Size may be bigger in person",
                                        "Can be used in the kitchen too!",
                                        "Not allowed for stabbing!",
                                        "Hide it, slice it!"};
        public static string[] hammerNames = { "Even Thor is scared of this one!",
                                        "A hammer, but not for carpentry...",
                                        "Beware of your thumbs!",
                                        "Heavy to hold, easy to love"};
        public static string[] staffNames = { "A magical staff for magical fights",
                                       "Swing it around and see them crumble...",
                                       "Magic is in the air...",
                                       "Only for authorized personnel"};
        public static string[] swordNames = { "A heavy sword",
                                       "Might secretly be a kitchenknife",
                                       "Taken from a stone",
                                       "Knights love it, crooks hate it!",
                                       "Not allowed in stores!"};
        public static string[] wandNames = { "Wait.. Isn't this just a stick?",
                                      "Glorified twig, magical inside!",
                                      "Do not wave around with proper certifications!!",
                                      "Deadly and small",
                                      "Laquered firewood with magical powers"};
        #endregion
        /// <summary>
        /// Function to create random weapon for user
        /// </summary>
        /// <param name="user">A character object</param>
        /// <returns>A weapon with randomized stats like type, requiredLevel and damage</returns>
        public static Weapon CreateWeapon(Character user)
        {
            // Math.Min() so that the highest level an item can be is 100.
            // The requiredLevel is between 1 and the current userLevel because there is currently
            // no way to store items that might be equipped later
            int reqLevel = Math.Min(random.Next(1, user.Level), 100);
            Console.WriteLine(reqLevel);
            // attacksPerSecond and damage are based on constants declared above
            double attacksPerSecond = random.Next(1, MAX_DAMAGE);
            double damage = random.Next(1, MAX_ATTACKS_PER_SECOND);
            // Random WeaponType to access enum
            int type = random.Next(0, 7);
            return new Weapon()
            {
                ItemName = axeNames[(random.Next(0, axeNames.Length))] + " (axe)",
                ItemRequiredLevel = reqLevel,
                ItemSlot = Item.Slot.WeaponSlot,
                WeaponType = (Weapon.WeaponTypes)type,
                AttacksPerSecond = attacksPerSecond,
                BaseDamage = damage,
            };
        }
        /// <summary>
        /// A function to create random armour for the user to equip
        /// </summary>
        /// <param name="user">A character object</param>
        /// <returns>A piece of armour with randomized stats, like requiredLevel, type and primaryAttributes</returns>
        public static Armour CreateArmour(Character user)
        {
            // Math.Min() so the max level is 100, or between 1 and the current userlevel as there is currently
            // no way to store items to equip later
            int reqLevel = Math.Min(random.Next(1, user.Level), 100);
            // Random PrimaryAttributes to add to the armour (between 1 and userLevel + 3
            // so it is not too overpowered but still stacks with userlevel)
            int strengthAdd = random.Next(1, user.Level + 3);
            int dexterityAdd = random.Next(1, user.Level + 3);
            int intelligenceAdd = random.Next(1, user.Level + 3);

            int type = random.Next(0, 4);
            int armourSlot = random.Next(1, 4);
            return new Armour()
            {
                ItemName = "A good piece of armour",
                ItemRequiredLevel = reqLevel,
                ArmourType = (Armour.ArmourTypes)type,
                ArmourSlot = (Armour.ArmourSlots)armourSlot,
                PrimaryAttribute = new Attributes.PrimaryAttribute()
                {
                    Strength = strengthAdd,
                    Dexterity = dexterityAdd,
                    Intelligence = intelligenceAdd
                }
            };
        }
    }
}
