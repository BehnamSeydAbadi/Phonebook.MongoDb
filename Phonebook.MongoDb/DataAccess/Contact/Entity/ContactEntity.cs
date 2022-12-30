using DataAccess.Common.Entity;

namespace DataAccess.Contact.Entity
{
    public sealed class ContactEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; init; }
        public string Email { get; init; }
    }
}
