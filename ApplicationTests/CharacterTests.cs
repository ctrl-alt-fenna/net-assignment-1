using Assignment1.Attributes;
using TestData;
namespace ApplicationTests
{
    public class CharacterTests
    {
        #region Character Test Data
        public static IEnumerable<object[]> CharacterData()
        {
            yield return new object[] { TestingCharacters.mageGandalf };
            yield return new object[] { TestingCharacters.warriorHercules };
            yield return new object[] { TestingCharacters.rangerRobin };
            yield return new object[] { TestingCharacters.rogueJohn };
        }
        public static IEnumerable<object[]> BaseCharacterPrimaryAttributeData()
        {
            yield return new object[] { TestingCharacters.mageGandalf, BaseAttributesTestingCharacters.mageBasePrimary };
            yield return new object[] { TestingCharacters.warriorHercules, BaseAttributesTestingCharacters.warriorBasePrimary };
            yield return new object[] { TestingCharacters.rangerRobin, BaseAttributesTestingCharacters.rangerBasePrimary };
            yield return new object[] { TestingCharacters.rogueJohn, BaseAttributesTestingCharacters.rogueBasePrimary };
        }
        #endregion
        [Theory]
        [MemberData(nameof(BaseCharacterPrimaryAttributeData))]
        public void CreateCharacter_ValidCharacter_ShouldReturnCorrectStartingStats(Assignment1.Character character, PrimaryAttribute primaryAttribute)
        {
            PrimaryAttribute expected = primaryAttribute;
            PrimaryAttribute actual = character.PrimaryAttribute;
            Assert.True(actual.IsEqual(expected) && character.Level == 1);
        }
        [Theory]
        [MemberData(nameof(BaseCharacterPrimaryAttributeData))]
        public void LevelUp_ValidCharacter_ShouldUpdateLevelAndAttribute(Assignment1.Character character, PrimaryAttribute primaryAttribute)
        {
            const int expectedLevel = 2;
            PrimaryAttribute expectedNewPrimaryAttribute = primaryAttribute + character.LevelUpPrimaryAttributes;
            character.LevelUp();
            int actual = character.Level;
            Assert.True(expectedLevel == actual && expectedNewPrimaryAttribute.IsEqual(character.PrimaryAttribute));
        }
    }
}