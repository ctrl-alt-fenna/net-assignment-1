using Assignment1.Attributes;
using Assignment1.Characters;
namespace ApplicationTests
{
    public class CharacterTests
    {
        [Fact]
        public void CreateCharacter_Mage_ShouldReturnCorrectDamage()
        {
            Mage mage = new Mage("Harry Potter");
            double expected = 1 * (1 + mage.PrimaryAttribute.Intelligence / 100);
            double actual = mage.Damage();
            Assert.True(expected == actual && mage.Level == 1);
        }
        [Fact]
        public void CreateCharacter_Ranger_ShouldReturnCorrectDamage()
        {
            Ranger ranger = new Ranger("Robin Hood");
            double expected = 1 * (1 + ranger.PrimaryAttribute.Dexterity / 100);
            double actual = ranger.Damage();
            Assert.True(expected == actual && ranger.Level == 1);
        }
        [Fact]
        public void CreateCharacter_Warrior_ShouldReturnCorrectDamage()
        {
            Warrior warrior = new Warrior("Hercules");
            double expected = 1 * (1 + warrior.PrimaryAttribute.Strength / 100);
            double actual = warrior.Damage();
            Assert.True(expected == actual && warrior.Level == 1);
        }
        [Fact]
        public void CreateCharacter_Rogue_ShouldReturnCorrectDamage()
        {
            Rogue rogue = new Rogue("Peter Pan");
            double expected = 1 * (1 + rogue.PrimaryAttribute.Dexterity / 100);
            double actual = rogue.Damage();
            Assert.True(expected == actual && rogue.Level == 1);
        }
        [Fact]
        public void LevelUp_Mage_ShouldReturnCorrectAttributes()
        {
            Mage mage = new Mage("Harry Potter");
            PrimaryAttribute expected = mage.PrimaryAttribute + mage.LevelUpPrimaryAttributes;
            mage.LevelUp();
            PrimaryAttribute actual = mage.PrimaryAttribute;
            Assert.True(expected.IsEqual(actual) && mage.Level == 2);
        }
        [Fact]
        public void LevelUp_Ranger_ShouldReturnCorrectAttributes()
        {
            Ranger ranger = new Ranger("Robin Hood");
            PrimaryAttribute expected = ranger.PrimaryAttribute + ranger.LevelUpPrimaryAttributes;
            ranger.LevelUp();
            PrimaryAttribute actual = ranger.PrimaryAttribute;
            Assert.True(expected.IsEqual(actual) && ranger.Level == 2);
        }
        [Fact]
        public void LevelUp_Warrior_ShouldReturnCorrectAttributes()
        {
            Warrior warrior = new Warrior("Hercules");
            PrimaryAttribute expected = warrior.PrimaryAttribute + warrior.LevelUpPrimaryAttributes;
            warrior.LevelUp();
            PrimaryAttribute actual = warrior.PrimaryAttribute;
            Assert.True(expected.IsEqual(actual) && warrior.Level == 2);
        }
        [Fact]
        public void LevelUp_Rogue_ShouldReturnCorrectAttributes()
        {
            Rogue rogue = new Rogue("Peter Pan");
            PrimaryAttribute expected = rogue.PrimaryAttribute + rogue.LevelUpPrimaryAttributes;
            rogue.LevelUp();
            PrimaryAttribute actual = rogue.PrimaryAttribute;
            Assert.True(expected.IsEqual(actual) && rogue.Level == 2);
        }
    }
}