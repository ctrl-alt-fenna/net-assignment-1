namespace Assignment1.CustomExceptions
{
    public class InvalidArmourException : Exception
    {
        public InvalidArmourException() : base("Armour cannot be equipped in current state")
        { }

        public InvalidArmourException(string? message) : base(message)
        { }
    }
}
