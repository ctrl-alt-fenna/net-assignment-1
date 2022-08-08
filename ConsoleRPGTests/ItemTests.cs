using Assignment1Tests;

namespace ApplicationTests;
public class ItemTests
{
    [Fact]
    public void EquipItem_WarriorBow_ShouldThrow()
    {
        {
            // Arrange
            Warrior warrior = Fixtures.Warrior();
            Weapon baseBow = Fixtures.baseBow();
            string expected = "Character type not allowed to equip current weapon";
            // Act
            string actual = Assert.Throws<InvalidWeaponException>(() => { warrior.EquipItem(baseBow); }).Message;
            // Assert
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void EquipItem_WarriorHighLevelAxe_ShouldThrow()
    {
        {
            // Arrange
            Warrior warrior = Fixtures.Warrior();
            Weapon expertAxe = Fixtures.expertAxe();
            string expected = "Current level is too low to equip item: " + expertAxe.ItemRequiredLevel + " > " + warrior.Level;
            // Act
            string actual = Assert.Throws<InvalidWeaponException>(() => { warrior.EquipItem(expertAxe); }).Message;
            // Assert
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void EquipItem_WarriorCloth_ShouldThrow()
    {
        {
            // Arrange
            Warrior warrior = Fixtures.Warrior();
            Armour baseClothHead = Fixtures.baseClothHead();
            string expected = "Character type not allowed to equip current armour";
            // Act
            string actual = Assert.Throws<InvalidArmourException>(() => { warrior.EquipItem(baseClothHead); }).Message;
            // Assert
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void EquipItem_WarriorHighLevelPlate_ShouldThrow()
    {
        {
            // Arrange
            Warrior warrior = Fixtures.Warrior();
            Armour expertPlateHead = Fixtures.expertPlateHead();
            string expected = "Current level is too low to equip item: " + expertPlateHead.ItemRequiredLevel + " > " + warrior.Level;
            // Act
            string actual = Assert.Throws<InvalidArmourException>(() => { warrior.EquipItem(expertPlateHead); }).Message;
            // Assert
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void EquipItem_WarriorPlate_ShouldSucceed()
    {
        {
            // Arrange
            Warrior warrior = Fixtures.Warrior();
            Armour basePlateHead = Fixtures.basePlateHead();
            string expected = "New armour equipped!";
            // Act
            string actual = warrior.EquipItem(basePlateHead);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void EquipItem_WarriorAxe_ShouldSucceed()
    {
        {
            // Arrange
            Warrior warrior = Fixtures.Warrior();
            Weapon baseAxe = Fixtures.baseAxe();
            string expected = "New weapon equipped!";
            // Act
            string actual = warrior.EquipItem(baseAxe);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
    [Fact]
    public void Damage_NoWeapon_ShouldOutputBaseStat()
    {
        // Arrange
        Warrior warrior = Fixtures.Warrior();
        double expected = 1 * (1 + warrior.TotalAttribute.Strength / 100);
        // Act
        double actual = warrior.Damage();
        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Damage_AxeWeapon_ShouldOutputBaseStatAndAxeDPS()
    {
        // Arrange
        Warrior warrior = Fixtures.Warrior();
        Weapon baseAxe = Fixtures.baseAxe();
        double expected = (15 * 10) * (1 + (warrior.TotalAttribute.Strength / 100));
        // Act
        warrior.EquipItem(baseAxe);
        double actual = warrior.Damage();
        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Damage_AxeWeaponAllArmour_ShouldOutputBaseStatAndAxeDPS()
    {
        // Arrange
        Warrior warrior = Fixtures.Warrior();
        Weapon baseAxe = Fixtures.baseAxe();
        Armour basePlateHead = Fixtures.basePlateHead();
        Armour basePlateBody = Fixtures.basePlateBody();
        Armour basePLateLegs = Fixtures.basePlateLegs();
        warrior.EquipItem(baseAxe);
        warrior.EquipItem(basePlateHead);
        warrior.EquipItem(basePlateBody);
        warrior.EquipItem(basePLateLegs);
        double expected = (15 * 10) * (1 + (warrior.TotalAttribute.Strength / 100));
        // Act
        double actual = warrior.Damage();
        // Assert
        Assert.Equal(expected, actual);
    }
}
