using Assignment1.CustomExceptions;
using TestData;
namespace ApplicationTests
{
    [Collection("B_Armour Tests")]
    public class ArmourTests
    {
        #region Character/Armour Test Data
        public static IEnumerable<object[]> InvalidType_CharacterData()
        {
            yield return new object[] { TestingCharacters.mageGandalf, BasicLevelTestingArmour.testingLegsLeather };
            yield return new object[] { TestingCharacters.rangerRobin, BasicLevelTestingArmour.testingHeadPlate };
            yield return new object[] { TestingCharacters.rogueJohn, BasicLevelTestingArmour.testingHeadCloth };
            yield return new object[] { TestingCharacters.warriorHercules, BasicLevelTestingArmour.testingHeadCloth };
        }
        public static IEnumerable<object[]> InvalidLevel_CharacterData()
        {
            yield return new object[] { TestingCharacters.mageGandalf, HighLevelTestingArmour.epicHeadCloth };
            yield return new object[] { TestingCharacters.rangerRobin, HighLevelTestingArmour.epicLegsLeather };
            yield return new object[] { TestingCharacters.rogueJohn, HighLevelTestingArmour.epicBodyMail };
            yield return new object[] { TestingCharacters.warriorHercules, HighLevelTestingArmour.epicHeadPlate };
        }
        #endregion
        [Theory]
        [MemberData(nameof(InvalidType_CharacterData))]
        public void EquipArmour_InvalidCharacterType_ShouldThrow(Assignment1.Character character, Assignment1.Equipment.Armour armour)
        {
            const string expected = "Character type not allowed to equip current item";
            string actual = Assert.Throws<InvalidArmourException>(() => { character.EquipItem(armour); }).Message;
            Assert.Equal(expected, actual);
        }
        [Theory]
        [MemberData(nameof(InvalidLevel_CharacterData))]
        public void EquipArmour_InvalidCharacterLevel_ShouldThrow(Assignment1.Character character, Assignment1.Equipment.Armour armour)
        {
            string expected = "Current level is too low to equip item: " + armour.ItemRequiredLevel + " > " + character.Level;
            string actual = Assert.Throws<InvalidArmourException>(() => { character.EquipItem(armour); }).Message;
            Assert.Equal(expected, actual);
        }
    }
}
