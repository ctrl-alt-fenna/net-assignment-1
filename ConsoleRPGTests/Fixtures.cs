namespace Assignment1Tests
{
    public static class Fixtures
    {
        public static Warrior Warrior() => new Warrior("Hercules");
        public static Weapon baseAxe() => new Weapon()
        {
            ItemName = "Axe-l Rose",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Axe,
            AttacksPerSecond = 15,
            BaseDamage = 10
        };
        public static Weapon expertAxe() => new Weapon()
        {
            ItemName = "Axe-ler Rose",
            ItemRequiredLevel = 10,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Axe,
            AttacksPerSecond = 25,
            BaseDamage = 30
        };
        public static Weapon baseBow() => new Weapon()
        {
            ItemName = "Pew",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Bow,
            AttacksPerSecond = 1,
            BaseDamage = 25
        };
        public static Armour basePlateHead() => new Armour()
        {
            ItemRequiredLevel = 1,
            ArmourSlot = Item.ArmourSlots.Head,
            ArmourType = Armour.ArmourTypes.Plate,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Strength = 5
            }
        };
        public static Armour expertPlateHead() => new Armour()
        {
            ItemRequiredLevel = 10,
            ArmourSlot = Item.ArmourSlots.Head,
            ArmourType = Armour.ArmourTypes.Plate,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Strength = 15
            }
        };
        public static Armour basePlateBody() => new Armour()
        {
            ItemRequiredLevel = 1,
            ArmourSlot = Item.ArmourSlots.Body,
            ArmourType = Armour.ArmourTypes.Plate,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Strength = 5
            }
        };
        public static Armour basePlateLegs() => new Armour()
        {
            ItemRequiredLevel = 1,
            ArmourSlot = Item.ArmourSlots.Legs,
            ArmourType = Armour.ArmourTypes.Plate,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Strength = 5
            }
        };
        public static Armour baseClothHead() => new Armour()
        {
            ItemRequiredLevel = 1,
            ArmourSlot = Item.ArmourSlots.Head,
            ArmourType = Armour.ArmourTypes.Cloth,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Dexterity = 5
            }
        };
        public static Armour baseClothBody() => new Armour()
        {
            ItemRequiredLevel = 1,
            ArmourSlot = Item.ArmourSlots.Body,
            ArmourType = Armour.ArmourTypes.Cloth,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Dexterity = 5
            }
        };
        public static Armour baseClothLegs() => new Armour()
        {
            ItemRequiredLevel = 1,
            ArmourSlot = Item.ArmourSlots.Legs,
            ArmourType = Armour.ArmourTypes.Cloth,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Dexterity = 5
            }
        };
    }
}
