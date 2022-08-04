using Assignment1.Equipment;
namespace Assignment1.MainGame.RandomCreation
{
    public class ItemCreation
    {
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
        /// <summary>
        /// Function to create random weapon for user
        /// </summary>
        /// <param name="user">A character object</param>
        /// <returns>A weapon with randomized stats like type, requiredLevel and damage</returns>
        public static Weapon CreateWeapon(Character user)
        {
            Random random = new Random();
            int reqLevel = Math.Min(random.Next(1, user.Level + 1), 100);
            double attacksPerSecond = random.Next(1, 15);
            double damage = random.Next(1, 10);
            int type = random.Next(0, 7);
            switch (type)
            {
                case 0:
                    return new Weapon()
                    {
                        ItemName = axeNames[(random.Next(0, axeNames.Length))] + " (axe)",
                        ItemRequiredLevel = reqLevel,
                        ItemSlot = Item.Slot.WeaponSlot,
                        WeaponType = Weapon.WeaponTypes.Axe,
                        AttacksPerSecond = attacksPerSecond,
                        BaseDamage = damage,
                    };
                    break;
                case 1:
                    return new Weapon()
                    {
                        ItemName = bowNames[(random.Next(0, bowNames.Length))] + " (bow)",
                        ItemRequiredLevel = reqLevel,
                        ItemSlot = Item.Slot.WeaponSlot,
                        WeaponType = Weapon.WeaponTypes.Bow,
                        AttacksPerSecond = attacksPerSecond,
                        BaseDamage = damage,
                    };
                    break;
                case 2:
                    return new Weapon()
                    {
                        ItemName = daggerNames[(random.Next(0, daggerNames.Length))] + " (dagger)",
                        ItemRequiredLevel = reqLevel,
                        ItemSlot = Item.Slot.WeaponSlot,
                        WeaponType = Weapon.WeaponTypes.Dagger,
                        AttacksPerSecond = attacksPerSecond,
                        BaseDamage = damage,
                    };
                    break;
                case 3:
                    return new Weapon()
                    {
                        ItemName = hammerNames[(random.Next(0, hammerNames.Length))] + " (hammer)",
                        ItemRequiredLevel = reqLevel,
                        ItemSlot = Item.Slot.WeaponSlot,
                        WeaponType = Weapon.WeaponTypes.Hammer,
                        AttacksPerSecond = attacksPerSecond,
                        BaseDamage = damage,
                    };
                    break;
                case 4:
                    return new Weapon()
                    {
                        ItemName = staffNames[(random.Next(0, staffNames.Length))] + " (staff)",
                        ItemRequiredLevel = reqLevel,
                        ItemSlot = Item.Slot.WeaponSlot,
                        WeaponType = Weapon.WeaponTypes.Staff,
                        AttacksPerSecond = attacksPerSecond,
                        BaseDamage = damage,
                    };
                    break;
                case 5:
                    return new Weapon()
                    {
                        ItemName = swordNames[(random.Next(0, swordNames.Length))] + " (sword)",
                        ItemRequiredLevel = reqLevel,
                        ItemSlot = Item.Slot.WeaponSlot,
                        WeaponType = Weapon.WeaponTypes.Sword,
                        AttacksPerSecond = attacksPerSecond,
                        BaseDamage = damage,
                    };
                    break;
                case 6:
                    return new Weapon()
                    {
                        ItemName = wandNames[(random.Next(0, wandNames.Length))] + " (wand)",
                        ItemRequiredLevel = reqLevel,
                        ItemSlot = Item.Slot.WeaponSlot,
                        WeaponType = Weapon.WeaponTypes.Wand,
                        AttacksPerSecond = attacksPerSecond,
                        BaseDamage = damage,
                    };
                    break;
                default:
                    return new Weapon()
                    {
                        ItemName = axeNames[(random.Next(0, axeNames.Length))] + " (axe)",
                        ItemRequiredLevel = reqLevel,
                        ItemSlot = Item.Slot.WeaponSlot,
                        WeaponType = Weapon.WeaponTypes.Axe,
                        AttacksPerSecond = attacksPerSecond,
                        BaseDamage = damage,
                    };
            }
        }
        /// <summary>
        /// A function to create random armour for the user to equip
        /// </summary>
        /// <param name="user">A character object</param>
        /// <returns>A piece of armour with randomized stats, like requiredLevel, type and primaryAttributes</returns>
        public static Armour CreateArmour(Character user)
        {
            Random random = new Random();
            int reqLevel = Math.Min(random.Next(1, user.Level + 1), 100);
            int strengthAdd = random.Next(1, 5);
            int dexterityAdd = random.Next(1, 5);
            int intelligenceAdd = random.Next(1, 5);
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
