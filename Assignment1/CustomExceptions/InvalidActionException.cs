namespace Assignment1.CustomExceptions
{
    public class InvalidActionException : Exception
    {
        public InvalidActionException() : base("Current action cannot be performed")
        { }

        public InvalidActionException(string? message) : base(message)
        { }
    }
}
