namespace Assignment1.CustomExceptions
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException() : base("Weapon cannot be equipped in current state")
        { }

        public InvalidWeaponException(string? message) : base(message)
        { }
    }
}
