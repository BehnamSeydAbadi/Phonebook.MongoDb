using DataAccess.Common.ValueObject;

namespace DataAccess.Contact.ValueObjects
{
    public record FullName : IValueObject
    {
        public string FirstName { get; init; }
        public string MiddleName { get; init; }
        public string LastName { get; init; }
    }
}
