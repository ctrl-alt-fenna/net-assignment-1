using Assignment1.MainGame.Levels;

namespace Assignment1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to my RPG!\n ...............\nDo you want to start the game? Y/N");
            try
            {
                char userAns = Console.ReadLine()[0];
                if (userAns == 'Y' || userAns == 'y') StartUp.RunGame();
                   else { 
                    Console.WriteLine("Exiting.....");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}