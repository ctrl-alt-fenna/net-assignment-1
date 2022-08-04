using Assignment1.Equipment;
using Assignment1.CustomExceptions;
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
                while (!equipedItem)
                {
                    equipedItem = EquipedItem();
                }
                CreateEncounters(1);
                Console.WriteLine(user.Name + " leveled up!\n");
                user.LevelUp();
                user.CharacterSheet();
                Thread.Sleep(1000);
                equipedItem = false;
                while (!equipedItem)
                {
                    equipedItem = EquipedArmour();
                }
                Console.WriteLine();
                user.CharacterSheet();
                Thread.Sleep(2000);
                CreateEncounters(2);
                Console.WriteLine(user.Name + " leveled up!\n");
                user.LevelUp();
                user.CharacterSheet();
                Console.WriteLine("Go on to the next level? Y/N");
                char userAns = Console.ReadLine()[0];
                if (userAns == 'Y' || userAns == 'y')
                {
                    Console.WriteLine("Not yet implemented :(");
                    StartUp.IsRunning = false;
                }
                else StartUp.IsRunning = false;
            }
        }
        public static void CreateEncounters(int iteration)
        {
            if (iteration == 1)
            {
            double ghoulHealth = RandomCreation.EnemyCreation.EnemyHealth();
            Console.WriteLine("Dangerous ghoul encountered.... his current health is " + ghoulHealth);
            Thread.Sleep(1000);
            while (ghoulHealth > 0) {
                    Console.WriteLine("You attack with all your might...\n");
                    Thread.Sleep(1500);
                    Console.WriteLine("Damaged Ghoul with " + user.Damage());
                    ghoulHealth = Math.Round(ghoulHealth - user.Damage(), 2);
                    Console.WriteLine("Ghoul is now at " + ghoulHealth);
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
                    Console.WriteLine("Damaged Ghoul with " + user.Damage());
                    ogreHealth =  Math.Round(ogreHealth - user.Damage(), 2);
                    Console.WriteLine("Ogre is now at " + ogreHealth);
                }
                Console.WriteLine(user.Name + " defeated the scary Ogre!\n");
            }
        }
        public static bool EquipedItem()
        {
            Console.WriteLine("It's dangerous alone! Take this:");
            Weapon weapon = RandomCreation.ItemCreation.CreateWeapon(user);
            Console.WriteLine(weapon.ItemName + ": " + weapon.DPS() + " DPS");
            Console.WriteLine("Do you wish to equip this? Y/N");

            char userAns = Console.ReadLine()[0];
            if (userAns == 'N' || userAns == 'n')
            {
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
                    Console.WriteLine(ex.Message + "\n Try Again!");
                    return false;
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
                    Console.WriteLine(ex.Message + "\n Try Again!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
