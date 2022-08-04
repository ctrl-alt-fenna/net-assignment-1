namespace Assignment1.MainGame.RandomCreation
{
    public class EnemyCreation
    {
        public static int EnemyHealth()
        {
            Random random = new Random();
            return random.Next(10,50);
        }
    }
}
