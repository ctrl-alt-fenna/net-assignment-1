using Assignment1.CustomExceptions;
using Assignment1.Equipment;
using TestData;
namespace ApplicationTests;
[Collection("C_Weapon Tests")]
public class WeaponTests
{
    #region Character/Weapon Test Data
    /// <summary>
    /// A function to return invalid CharacterType - Item combinations for all characters.
    /// </summary>
    /// <returns>An IEnumberable of type object[] </returns>
    public static IEnumerable<object[]> InvalidType_CharacterData()
    {
        yield return new object[] { TestingCharacters.mageGandalf, BasicLevelTestingWeapons.testingAxe };
        yield return new object[] { TestingCharacters.rangerRobin, BasicLevelTestingWeapons.testingStaff };
        yield return new object[] { TestingCharacters.rogueJohn, BasicLevelTestingWeapons.testingWand };
        yield return new object[] { TestingCharacters.warriorHercules, BasicLevelTestingWeapons.testingBow };
    }
    /// <summary>
    /// A function to return invalid CharacterLevel - ItemLevel combinations for all characters.
    /// </summary>
    /// <returns>An IEnumberable of type object[] </returns>
    public static IEnumerable<object[]> InvalidLevel_CharacterData()
    {
        yield return new object[] { TestingCharacters.mageGandalf, HighLevelTestingWeapons.epicStaff };
        yield return new object[] { TestingCharacters.rangerRobin, HighLevelTestingWeapons.epicBow };
        yield return new object[] { TestingCharacters.rogueJohn, HighLevelTestingWeapons.epicDagger };
        yield return new object[] { TestingCharacters.warriorHercules, HighLevelTestingWeapons.epicHammer };
    }
    /// <summary>
    /// A function to return valid Character - Item combinations for all characters.
    /// </summary>
    /// <returns>An IEnumberable of type object[]</returns>
    public static IEnumerable<object[]> Valid_CharacterData()
    {
        yield return new object[] { TestingCharacters.mageGandalf, BasicLevelTestingWeapons.testingWand };
        yield return new object[] { TestingCharacters.rangerRobin, BasicLevelTestingWeapons.testingBow };
        yield return new object[] { TestingCharacters.rogueJohn, BasicLevelTestingWeapons.testingDagger };
        yield return new object[] { TestingCharacters.warriorHercules, BasicLevelTestingWeapons.testingHammer };
    }
    #endregion
    [Theory]
    [MemberData(nameof(InvalidType_CharacterData))]
    public void EquipItem_InvalidCharacterType_ShouldThrow(Assignment1.Character character, Weapon weapon)
    {
        {
            string expected = "Character type not allowed to equip current item";
            string actual = Assert.Throws<InvalidWeaponException>(() => { character.EquipItem(weapon); }).Message;
            Assert.Equal(expected, actual);
        }
    }
    [Theory]
    [MemberData(nameof(InvalidLevel_CharacterData))]
    public void EquipItem_InvalidCharacterLevel_ShouldThrow(Assignment1.Character character, Weapon weapon)
    {
        {
            string expected = "Current level is too low to equip item: " + weapon.ItemRequiredLevel + " > " + character.Level;
            string actual = Assert.Throws<InvalidWeaponException>(() => { character.EquipItem(weapon); }).Message;

        }
    }
    [Theory]
    [MemberData(nameof(Valid_CharacterData))]
    public void EquipItem_ValidCharacter_ShouldSucceed(Assignment1.Character character, Weapon weapon)
    {
        {
            string expected = "Item succesfully equiped!";
            string actual = character.EquipItem(weapon);
            Assert.Equal(expected, actual);
        }
    }
}
