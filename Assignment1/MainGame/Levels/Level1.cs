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
                CreateEncounters();
                Console.WriteLine(user.Name + " leveled up!!!!");
                user.LevelUp();
                Console.WriteLine("Should they go on to the next level? Y/N");
                char userAns = Console.ReadLine()[0];
                if (userAns == 'Y' || userAns == 'y') Console.WriteLine("Not yet implemented :(");
                else StartUp.IsRunning = false;
            }
        }
        public static void CreateEncounters()
        {
            double ghoulHealth = RandomCreation.EnemyCreation.EnemyHealth();
            Console.WriteLine("Dangerous ghoul encountered.... his current health is " + ghoulHealth);
            Thread.Sleep(500);
            while (ghoulHealth > 0) {
                    Console.WriteLine("You attack with all your might...");
                    Thread.Sleep(1000);
                    ghoulHealth -= user.Damage();
                    Console.WriteLine("Ghoul is now at " + ghoulHealth);
            }
            Console.WriteLine(user.Name + " defeated the Ghoul!");
        }
        public static Weapon DropItem()
        {
            return (Weapon)RandomCreation.ItemCreation.CreateWeapon(user);
        }
        public static bool EquipedItem()
        {
            Console.WriteLine("It's dangerous alone! Take this:");
            Weapon weapon = DropItem();
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

    }
}
