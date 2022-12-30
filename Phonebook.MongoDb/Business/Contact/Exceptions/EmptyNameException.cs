namespace Business.Contact.Exceptions
{
    public sealed class EmptyNameException : Exception
    {
        public const string Message = "Both first name and last name can not be empty.";

        public EmptyNameException() : base(Message) { }
    }
}
