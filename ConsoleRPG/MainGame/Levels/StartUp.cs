using Assignment1.Characters;

namespace Assignment1.MainGame.Levels
{
    public class StartUp
    {
        public static bool IsRunning = false;
        protected static string UserName = "username";
        protected static Character user = new Mage(UserName);
        /// <summary>
        /// Initiates a new game if User wants to play or exits
        /// </summary>
        /// <exception cref="Exception">Thrown if there was an error processing the user input</exception>
        public static void StartGame()
        {
            Console.WriteLine("Welcome to my RPG!\n ...............\nDo you want to start the game? Y/N");
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                char userAns = Console.ReadLine()[0];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                if (userAns == 'Y' || userAns == 'y') RunGame();
                else
                {
                    Console.WriteLine("Exiting.....");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Main game driver code
        /// </summary>
        public static void RunGame()
        {
            IsRunning = true;
            while (IsRunning)
            {
                // Clears "Start Game" question.
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
        /// <summary>
        /// Method to create character based on user's choice for character class. 
        /// </summary>
        /// <returns>true if user succesfully selected the options, false if they wished to exit by entering 0</returns>
        public static bool CreateCharacter()
        {
            // Setup charactername
            Console.WriteLine("What name do you wish to go by?");
#pragma warning disable CS8601 // Possible null reference assignment.
            UserName = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
            if (UserName == null) return false;
            Console.Clear();
            Console.WriteLine("Username is now " + UserName);
            // User picks characterclass based on printed options
            Console.WriteLine("What class do you wish to be? (Enter 0 to exit)");
            ShowClassOptions();
#pragma warning disable CS8604 // Possible null reference argument.
            int userClass = Int32.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.
            // Checks if user wants to exit character creation
            if (userClass == 0) return false;
            // User entered wrong input
            while (userClass < 0 || userClass > 4)
            {
                Console.Clear();
                Console.WriteLine("INVALID INPUT: What class do you wish to be?");
                ShowClassOptions();
#pragma warning disable CS8604 // Possible null reference argument.
                userClass = Int32.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.
            }
            // Sets up character with UserName and class selected by user
            switch (userClass)
            {
                case 1:
                    {
                        user = new Mage(UserName);
                        return true;
                    }
                case 2:
                    {
                        user = new Ranger(UserName);
                        return true;
                    }
                case 3:
                    {
                        user = new Rogue(UserName);
                        return true;
                    }
                case 4:
                    {
                        user = new Warrior(UserName);
                        return true;
                    }
                // Should never be reached, but C# wants return from all paths
                default:
                    return false;
            }
        }
        // Simplifies the printing of classes and cleans up code
        public static void ShowClassOptions()
        {
            Console.WriteLine("1. Mage: High Intelligence but low Strength and Dexterity");
            Console.WriteLine("2. Ranger: High Dexterity but low Intelligence and Strength");
            Console.WriteLine("3. Rogue: High Dexterity, medium Strength but low Intelligence");
            Console.WriteLine("4. Warrior: High Strength but low Intelligence and Dexterity");
        }
    }
}