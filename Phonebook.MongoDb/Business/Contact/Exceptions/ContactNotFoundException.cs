using Business.Common;

namespace Business.Contact.Exceptions
{
    public class ContactNotFoundException : BaseException
    {
        public const string Message = "Contact not found.";

        public ContactNotFoundException() : base(Message) { }
    }
}
