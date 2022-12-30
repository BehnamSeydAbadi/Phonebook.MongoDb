namespace Business.Contact.Exceptions
{
    public class EmptyPhoneNumberException : Exception
    {
        public const string Message = "Phone number can not be empty.";

        public EmptyPhoneNumberException() : base(Message) { }
    }
}
