namespace Business.Contact.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public const string Message = "Contact not found.";

        public ContactNotFoundException() : base(Message) { }
    }
}
