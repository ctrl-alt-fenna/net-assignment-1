using Assignment1.Attributes;
using Assignment1.Characters;
using Assignment1.Equipment;
namespace TestData
{
    public class TestingCharacters
    {
        public static Warrior warriorHercules = new Warrior("Hercules");
        public static Mage mageGandalf = new Mage("Gandalf");
        public static Ranger rangerRobin = new Ranger("Robin");
        public static Rogue rogueJohn = new Rogue("John");
    }
    public class BasicLevelTestingWeapons
    {
        public static Weapon testingAxe = new Weapon()
        {
            ItemName = "A sharp, heavy axe",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Axe
        };
        public static Weapon testingBow = new Weapon()
        {
            ItemName = "A flexible, precise bow",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Bow
        };
        public static Weapon testingDagger = new Weapon()
        {
            ItemName = "A piercing little dagger",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Dagger
        };
        public static Weapon testingHammer = new Weapon()
        {
            ItemName = "A hammer, but not for carpentry",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Hammer
        };
        public static Weapon testingStaff = new Weapon()
        {
            ItemName = "Magical stick",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Staff
        };
        public static Weapon testingWand = new Weapon()
        {
            ItemName = "A cool, magic wand",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Wand
        };
    }
    public class HighLevelTestingWeapons
    {
        public static Weapon epicStaff = new Weapon()
        {
            ItemName = "A magical-er stick",
            ItemRequiredLevel = 1000,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Staff
        };
        public static Weapon epicAxe = new Weapon()
        {
            ItemName = "A sharper-er, heavier-er axe",
            ItemRequiredLevel = 1000,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Axe
        };
        public static Weapon epicBow = new Weapon()
        {
            ItemName = "A flexibler, preciser bow",
            ItemRequiredLevel = 1000,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Bow
        };
        public static Weapon epicDagger = new Weapon()
        {
            ItemName = "A piercinger little-er dagger",
            ItemRequiredLevel = 1000,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Dagger
        };
        public static Weapon epicHammer = new Weapon()
        {
            ItemName = "A hammer, but (even more so) not for carpentry",
            ItemRequiredLevel = 1000,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Hammer
        };
        public static Weapon epicWand = new Weapon()
        {
            ItemName = "A cooler, magicer wand",
            ItemRequiredLevel = 1000,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Wand
        };
    }
    public class BasicLevelTestingArmour
    {
        public static Armour testingHeadCloth = new Armour()
        {
            ArmourType = Armour.ArmourTypes.Cloth,
            PrimaryAttribute = new PrimaryAttribute() { Intelligence = 2 },
            ItemRequiredLevel = 1,
            ItemName = "Covers your head in cloth",
            ArmourSlot = Armour.ArmourSlots.ArmourSlot_Head
        };
        public static Armour testingLegsLeather = new Armour()
        {
            ArmourType = Armour.ArmourTypes.Leather,
            PrimaryAttribute = new PrimaryAttribute() { Strength = 1, Dexterity = 1, Intelligence = -1 },
            ItemRequiredLevel = 1,
            ItemName = "Leather pants never felt this tight!",
            ArmourSlot = Armour.ArmourSlots.ArmourSlot_Legs
        };
        public static Armour testingBodyMail = new Armour()
        {
            ArmourType = Armour.ArmourTypes.Mail,
            PrimaryAttribute = new PrimaryAttribute() { Strength = 1, Dexterity = -1 },
            ItemRequiredLevel = 1,
            ItemName = "Heavy armour made from chainmail",
            ArmourSlot = Armour.ArmourSlots.ArmourSlot_Body
        };
        public static Armour testingHeadPlate = new Armour()
        {
            ArmourType = Armour.ArmourTypes.Plate,
            PrimaryAttribute = new PrimaryAttribute() { Strength = 4, Dexterity = -3 },
            ItemRequiredLevel = 1,
            ItemName = "Heavier than 1kg of feathers",
            ArmourSlot = Armour.ArmourSlots.ArmourSlot_Head
        };
    }
    public class HighLevelTestingArmour
    {
        public static Armour epicHeadCloth = new Armour()
        {
            ArmourType = Armour.ArmourTypes.Cloth,
            PrimaryAttribute = new PrimaryAttribute() { Intelligence = 100 },
            ItemRequiredLevel = 1000,
            ItemName = "Covers your head in epicer cloth",
            ArmourSlot = Armour.ArmourSlots.ArmourSlot_Head
        };
        public static Armour epicLegsLeather = new Armour()
        {
            ArmourType = Armour.ArmourTypes.Leather,
            PrimaryAttribute = new PrimaryAttribute() { Strength = 100, Dexterity = -15 },
            ItemRequiredLevel = 1000,
            ItemName = "Leather pants never felt this more tight!",
            ArmourSlot = Armour.ArmourSlots.ArmourSlot_Legs
        };
        public static Armour epicBodyMail = new Armour()
        {
            ArmourType = Armour.ArmourTypes.Mail,
            PrimaryAttribute = new PrimaryAttribute() { Strength = 10, Dexterity = -10 },
            ItemRequiredLevel = 1000,
            ItemName = "Heavier armour made from chainmail",
            ArmourSlot = Armour.ArmourSlots.ArmourSlot_Body
        };
        public static Armour epicHeadPlate = new Armour()
        {
            ArmourType = Armour.ArmourTypes.Plate,
            PrimaryAttribute = new PrimaryAttribute() { Strength = 45, Dexterity = -32 },
            ItemRequiredLevel = 1000,
            ItemName = "Heavier than 1000kg of feathers",
            ArmourSlot = Armour.ArmourSlots.ArmourSlot_Head
        };
    }
}

