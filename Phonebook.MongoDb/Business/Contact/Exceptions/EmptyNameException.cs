using Business.Common;

namespace Business.Contact.Exceptions
{
    public sealed class EmptyNameException : BaseException
    {
        public const string Message = "Both first name and last name can not be empty.";

        public EmptyNameException() : base(Message) { }
    }
}
