using DataAccess.Common.Entity;
using DataAccess.Contact.ValueObjects;

namespace DataAccess.Contact.Entity
{
    public sealed class Contact : BaseEntity
    {
        public FullName FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; init; }
        public string Email { get; init; }
    }
}
