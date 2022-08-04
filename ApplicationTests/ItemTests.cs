using Assignment1.CustomExceptions;
using Assignment1.Equipment;
using Assignment1.Characters;
using Assignment1Tests;

namespace ApplicationTests;
public class ItemTests
{
    [Fact]
    public void EquipItem_WarriorBow_ShouldThrow()
    {
        {
            Warrior warrior = Fixtures.Warrior();
            Weapon bow = new Weapon()
            {
                ItemRequiredLevel = 1,
                ItemSlot = Item.Slot.WeaponSlot,
                WeaponType = Weapon.WeaponTypes.Bow
            };
            string expected = "Character type not allowed to equip current weapon";
            string actual = Assert.Throws<InvalidWeaponException>(() => { warrior.EquipItem(bow);}).Message;
            Assert.Equal(expected, actual);
        }
    }    
    [Fact]
    public void EquipItem_WarriorHighLevelAxe_ShouldThrow()
    {
        {
            Warrior warrior = Fixtures.Warrior();
            Weapon bow = new Weapon()
            {
                ItemRequiredLevel = 2,
                ItemSlot = Item.Slot.WeaponSlot,
                WeaponType = Weapon.WeaponTypes.Axe
            };
            string expected = "Current level is too low to equip item: " + bow.ItemRequiredLevel + " > " + warrior.Level;
            string actual = Assert.Throws<InvalidWeaponException>(() => { warrior.EquipItem(bow);}).Message;
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void EquipItem_WarriorCloth_ShouldThrow()
    {
        {
            Warrior warrior = Fixtures.Warrior();
            Armour plate = new Armour()
            {
                ItemRequiredLevel = 1,
                ArmourSlot = Item.ArmourSlots.Body,
                ArmourType = Armour.ArmourTypes.Cloth,
                PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
                {
                    Dexterity = 5
                }
            };
            string expected = "Character type not allowed to equip current armour";
            string actual = Assert.Throws<InvalidArmourException>(() => { warrior.EquipItem(plate); }).Message;
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void EquipItem_WarriorHighLevelPlate_ShouldThrow()
    {
        {
            Warrior warrior = Fixtures.Warrior();
            Armour plate = new Armour()
            {
                ItemRequiredLevel = 2,
                ArmourSlot = Item.ArmourSlots.Body,
                ArmourType = Armour.ArmourTypes.Plate,
                PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
                {
                    Strength = 5
                }
            };
            string expected = "Current level is too low to equip item: " + plate.ItemRequiredLevel + " > " + warrior.Level;
            string actual = Assert.Throws<InvalidArmourException>(() => { warrior.EquipItem(plate);}).Message;
            Assert.Equal(expected, actual);
        }
    }    
    [Fact]
    public void EquipItem_WarriorPlate_ShouldSucceed()
    {
        {
            Warrior warrior = Fixtures.Warrior();
            Armour plate = new Armour()
            {
                ItemRequiredLevel = 1,
                ArmourSlot = Item.ArmourSlots.Body,
                ArmourType = Armour.ArmourTypes.Plate,
                PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
                {
                    Strength = 5
                }
            };
            string expected = "New armour equipped!";
            string actual = warrior.EquipItem(plate);
            Assert.Equal(expected, actual);
        }
    }    
    [Fact]
    public void EquipItem_WarriorAxe_ShouldSucceed()
    {
        {
            Warrior warrior = Fixtures.Warrior();
            Weapon axe = new Weapon()
            {
                ItemRequiredLevel = 1,
                WeaponType = Weapon.WeaponTypes.Axe,
                ItemSlot = Item.Slot.WeaponSlot
            };
            string expected = "New weapon equipped!";
            string actual = warrior.EquipItem(axe);
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void Damage_NoWeapon_ShouldOutputBaseStat()
    {
        Warrior warrior = Fixtures.Warrior();
        double expected = 1 * (1 + warrior.TotalAttribute.Strength / 100);
        double actual = warrior.Damage();
        Assert.Equal(expected, actual);
    }    
    [Fact]
    public void Damage_AxeWeapon_ShouldOutputBaseStatAndAxeDPS()
    {
        Warrior warrior = Fixtures.Warrior();
        Weapon axe = new Weapon()
        {
            ItemName = "axe",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Axe,
            AttacksPerSecond = 15,
            BaseDamage = 10
        };
        warrior.EquipItem(axe);
        double expected = (15 * 10) * (1 + (warrior.TotalAttribute.Strength / 100));
        double actual = warrior.Damage();
        Assert.Equal(expected, actual);
    }    
    [Fact]
    public void Damage_AxeWeaponAllArmour_ShouldOutputBaseStatAndAxeDPS()
    {
        Warrior warrior = Fixtures.Warrior();
        Weapon axe = new Weapon()
        {
            ItemName = "axe",
            ItemRequiredLevel = 1,
            ItemSlot = Item.Slot.WeaponSlot,
            WeaponType = Weapon.WeaponTypes.Axe,
            AttacksPerSecond = 15,
            BaseDamage = 10
        };
        Armour plateHead = new Armour()
        {
            ItemSlot = Item.Slot.ArmourSlot,
            ArmourSlot = Item.ArmourSlots.Head,
            ItemRequiredLevel = 1,
            ArmourType = Armour.ArmourTypes.Plate,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Strength = 5
            }
        };        
        Armour plateBody = new Armour()
        {
            ItemSlot = Item.Slot.ArmourSlot,
            ArmourSlot = Item.ArmourSlots.Body,
            ItemRequiredLevel = 1,
            ArmourType = Armour.ArmourTypes.Plate,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Strength = 5
            }
        };        
        Armour plateLegs = new Armour()
        {
            ItemSlot = Item.Slot.ArmourSlot,
            ArmourSlot = Item.ArmourSlots.Legs,
            ItemRequiredLevel = 1,
            ArmourType = Armour.ArmourTypes.Plate,
            PrimaryAttribute = new Assignment1.Attributes.PrimaryAttribute()
            {
                Strength = 5
            }
        };
        warrior.EquipItem(axe);
        warrior.EquipItem(plateLegs);
        warrior.EquipItem(plateBody);
        warrior.EquipItem(plateHead);
        double expected = (15 * 10) * (1 + (warrior.TotalAttribute.Strength / 100));
        double actual = warrior.Damage();
        Assert.Equal(expected, actual);
    }
}
