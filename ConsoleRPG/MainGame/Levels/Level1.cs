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
                Console.WriteLine("\nIt's dangerous to go alone! Take this:\n");
                while (!equipedItem)
                {
                    equipedItem = EquipedWeapon();
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
        /// <summary>
        /// Method to print out enemy encounters (in a very basic form)
        /// </summary>
        /// <param name="iteration">Used to check which enemy to 'spawn'</param>
        public static void CreateEncounters(int iteration)
        {
            Console.Clear();
            user.CharacterSheet();
            // Thread.Sleep() are used here so screen doesn't print out too fast for people to read
            if (iteration == 1)
            {
                double ghoulHealth = RandomCreation.EnemyCreation.EnemyHealth();
                Console.WriteLine("Dangerous ghoul encountered.... his current health is " + ghoulHealth);
                Thread.Sleep(1000);
                // Keep attacking until enemy dies
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
                Thread.Sleep(1500);
                // Keep attacking until enemy dies.
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
        /// <summary>
        /// A method to check if user has equipped a weapon (required to continue to first encounter)
        /// </summary>
        /// <returns>true if weapon was succesfully equiped, false if ther was an exception along the way</returns>
        public static bool EquipedWeapon()
        {
            Weapon weapon = RandomCreation.ItemCreation.CreateWeapon(user);
            Console.WriteLine(weapon.ItemName + ": " + weapon.DPS() + " DPS");
            Console.WriteLine("Do you wish to equip this? Y/N");
            try
            {
                char userAns = Console.ReadLine()[0];
                if (userAns == 'N' || userAns == 'n')
                {
                    Console.Clear();
                    user.CharacterSheet();
                    return EquipedWeapon();
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
                        DealWithExceptions(ex);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            // Mostly reached if a parsing error occurs
            catch (Exception ex)
            {
                DealWithExceptions(ex);
                return false;
            }
        }
        /// <summary>
        /// A method to check if user has equipped the current armour (needed to continue)
        /// </summary>
        /// <returns>true if equipping was succesful, false if something went wrong along the way</returns>
        public static bool EquipedArmour()
        {
            Console.WriteLine("Enemy dropped armour:");
            Armour armour = RandomCreation.ItemCreation.CreateArmour(user);
            // Print the armour with all the stats
            Console.WriteLine(armour.ItemName + ": " + armour.ArmourType +
                ": \n +" + armour.PrimaryAttribute.Strength + " Strength, \n +" +
                armour.PrimaryAttribute.Dexterity + " Dexterity, \n +" + armour.PrimaryAttribute.Intelligence + " Intelligence");
            Console.WriteLine("Do you wish to equip this armour? Y/N");
            try
            {
                char userAns = Console.ReadLine()[0];
                // Reload new armour
                if (userAns == 'N' || userAns == 'n')
                {
                    Console.Clear();
                    user.CharacterSheet();
                    return EquipedArmour();
                }
                // Check if user can equip current armour
                else if (userAns == 'Y' || userAns == 'y')
                {
                    try
                    {
                        user.EquipItem(armour);
                        return true;
                    }
                    catch (InvalidArmourException ex)
                    {
                        DealWithExceptions(ex);
                        return false;
                    }
                }
                else return false;
            }
            // Mostly reached if a parsing error occurs 
            catch (Exception ex)
            {
                DealWithExceptions(ex);
                return false;
            }
        }
        /// <summary>
        /// If an exception occurs while equipping armour/weapon, reload the screen and print the exception message
        /// </summary>
        /// <param name="ex">The exception that was thrown</param>
        public static void DealWithExceptions(Exception ex)
        {
            Console.Clear();
            user.CharacterSheet();
            Console.WriteLine(ex.Message + "\nTry Again!\n................\n");
        }
    }
}
