using Assignment1.CustomExceptions;
using Assignment1.Equipment;
namespace Assignment1.MainGame.Levels
{
    public class Level1
    {
        public static Character user;
        public static bool equipedItem = false;
        public static void LevelOne(Character c)
        {
            user = c;
            while (StartUp.IsRunning)
            {
                user.CharacterSheet();
                Console.WriteLine("\nIt's dangerous alone! Take this:\n");
                while (!equipedItem)
                {
                    equipedItem = EquipedItem();
                }
                CreateEncounters(1);
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine(user.Name + " leveled up!\n");
                user.LevelUp();
                user.CharacterSheet();
                Thread.Sleep(2000);
                equipedItem = false;
                while (!equipedItem)
                {
                    equipedItem = EquipedArmour();
                }
                CreateEncounters(2);
                Console.WriteLine(user.Name + " leveled up!\n");
                user.LevelUp();
                user.CharacterSheet();
                Console.WriteLine("Go on to the next level? Y/N");
                char userAns = Console.ReadLine()[0];
                Console.Clear();
                if (userAns == 'Y' || userAns == 'y')
                {
                    Console.WriteLine("Not yet implemented :(");
                    StartUp.IsRunning = false;
                }
                else
                {
                    StartUp.IsRunning = false;
                    Environment.Exit(0);
                }
            }
        }
        public static void CreateEncounters(int iteration)
        {
            Console.Clear();
            user.CharacterSheet();
            if (iteration == 1)
            {
                double ghoulHealth = RandomCreation.EnemyCreation.EnemyHealth();
                Console.WriteLine("Dangerous ghoul encountered.... his current health is " + ghoulHealth);
                Thread.Sleep(1000);
                while (ghoulHealth > 0)
                {
                    Console.WriteLine("You attack with all your might...\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("Damaged Ghoul with " + user.Damage() + " damage points!");
                    ghoulHealth = Math.Round(ghoulHealth - user.Damage(), 2);
                    Console.WriteLine("Ghoul is now at " + ghoulHealth + "HP");
                }
                Console.WriteLine(user.Name + " defeated the Ghoul!\n");
            }
            else if (iteration == 2)
            { 
                double ogreHealth = RandomCreation.EnemyCreation.EnemyHealth();
                Console.WriteLine("With a few scratches, " + user.Name + " encountered a scary Ogre...'GET OUT OF MY SWAMP' he screams! His current health is " + ogreHealth);
                Thread.Sleep(1000);
                while (ogreHealth > 0)
                {
                    Console.WriteLine("You attack with all your might...\n");
                    Thread.Sleep(1500);
                    Console.WriteLine("Damaged Ogre with " + user.Damage() + " damage points");
                    ogreHealth = Math.Round(ogreHealth - user.Damage(), 2);
                    Console.WriteLine("Ogre is now at " + ogreHealth + " HP");
                }
                Console.WriteLine(user.Name + " defeated the scary Ogre!\n");
            }
        }
        public static bool EquipedItem()
        {
            Weapon weapon = RandomCreation.ItemCreation.CreateWeapon(user);
            Console.WriteLine(weapon.ItemName + ": " + weapon.DPS() + " DPS");
            Console.WriteLine("Do you wish to equip this? Y/N");

            char userAns = Console.ReadLine()[0];
            if (userAns == 'N' || userAns == 'n')
            {
                Console.Clear();
                user.CharacterSheet();
                return EquipedItem();
            }
            if (userAns == 'Y' || userAns == 'y')
            {
                try
                {
                    user.EquipItem(weapon);
                    return true;
                }
                catch (InvalidWeaponException ex)
                {
                    return DealWithExceptions(ex);
                }
            }
            else
            {
                return false;
            }
        }
        public static bool EquipedArmour()
        {
            Console.WriteLine("Enemy dropped armour:");
            Armour armour = RandomCreation.ItemCreation.CreateArmour(user);
            Console.WriteLine(armour.ItemName + ": " + armour.ArmourType +
                ": \n +" + armour.PrimaryAttribute.Strength + " Strength, \n +" +
                armour.PrimaryAttribute.Dexterity + " Dexterity, \n +" + armour.PrimaryAttribute.Intelligence + " Intelligence");
            Console.WriteLine("Do you wish to equip this armour? Y/N");

            char userAns = Console.ReadLine()[0];
            if (userAns == 'N' || userAns == 'n')
            {
                Console.Clear();
                user.CharacterSheet();
                return EquipedArmour();
            }
            if (userAns == 'Y' || userAns == 'y')
            {
                try
                {
                    user.EquipItem(armour);
                    return true;
                }
                catch (InvalidArmourException ex)
                {
                    return DealWithExceptions(ex);
                }
            }
            else
            {
                return false;
            }
        }
        public static bool DealWithExceptions(Exception ex)
        {
            Console.Clear();
            user.CharacterSheet();
            Console.WriteLine(ex.Message + "\nTry Again!\n................\n");
            return false;
        }
    }
}
