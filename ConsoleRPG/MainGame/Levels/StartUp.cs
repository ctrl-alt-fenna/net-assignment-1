using Assignment1.Characters;

namespace Assignment1.MainGame.Levels
{
    public class StartUp
    {
        public static bool IsRunning = false;
        protected static string UserName;
        protected static Character user;
        public static void RunGame()
        {
            IsRunning = true;
            while (IsRunning)
            {
                Console.Clear();
                bool completedChar = CreateCharacter();
                // Wait for character to be created succesfully before entering level 1
                if (completedChar)
                {
                    Console.Clear();
                    Level1.LevelOne(user);
                }
                else IsRunning = false;
            }
        }
        public static bool CreateCharacter()
        {
            // Setup charactername
            Console.WriteLine("What name do you wish to go by?");
            UserName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Username is now " + UserName);
            // User picks characterclass based on printed options
            Console.WriteLine("What class do you wish to be? (Enter 0 to exit)");
            ShowClassOptions();
            int userClass = int.Parse(Console.ReadLine());
            // Checks if user wants to exit character creation
            if (userClass == 0) return false;
            // User entered wrong input
            while (userClass < 0 || userClass > 4)
            {
                Console.Clear();
                Console.WriteLine("INVALID INPUT: What class do you wish to be?");
                ShowClassOptions();
                userClass = int.Parse(Console.ReadLine());

            }
            // Sets up character with UserName and class selected by user
            switch (userClass)
            {
                case 1:
                    {
                        user = new Mage(UserName);
                        return true;
                        break;
                    }
                case 2:
                    {
                        user = new Ranger(UserName);
                        return true;
                        break;
                    }
                case 3:
                    {
                        user = new Rogue(UserName);
                        return true;
                        break;
                    }
                case 4:
                    {
                        user = new Warrior(UserName);
                        return true;
                        break;
                    }
                // Should never be reached, but C# wants return from all paths
                default:
                    return false;
            }
        }
        public static void ShowClassOptions()
        {
            Console.WriteLine("1. Mage: High Intelligence but low Strength and Dexterity");
            Console.WriteLine("2. Ranger: High Dexterity but low Intelligence and Strength");
            Console.WriteLine("3. Rogue: High Dexterity, medium Strength but low Intelligence");
            Console.WriteLine("4. Warrior: High Strength but low Intelligence and Dexterity");
        }
    }
}
