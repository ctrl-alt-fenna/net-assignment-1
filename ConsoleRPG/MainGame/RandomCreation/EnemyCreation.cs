namespace Assignment1.MainGame.RandomCreation
{
    public class EnemyCreation
    {
        /// <summary>
        /// Function to return random enemy health
        /// </summary>
        /// <returns>Random EnemyHealth (int)</returns>
        public static int EnemyHealth()
        {
            Random random = new Random();
            return random.Next(10, 50);
        }
    }
}
