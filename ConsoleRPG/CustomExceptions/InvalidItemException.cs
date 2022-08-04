namespace Assignment1.CustomExceptions
{
    public class InvalidItemException : Exception
    {
        public InvalidItemException() : base("Current item is not valid")
        { }

        public InvalidItemException(string? message) : base(message)
        { }
    }
}
