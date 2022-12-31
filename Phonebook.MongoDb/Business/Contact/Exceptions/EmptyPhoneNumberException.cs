using Business.Common;

namespace Business.Contact.Exceptions
{
    public class EmptyPhoneNumberException : BaseException
    {
        public const string Message = "Phone number can not be empty.";

        public EmptyPhoneNumberException() : base(Message) { }
    }
}
