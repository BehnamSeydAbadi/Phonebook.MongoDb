using DataAccess.Contact.Entity;

namespace DataAccess.Contact
{
    public interface IContactDataAccess
    {
        Task InsertAsync(ContactEntity entity);
    }
}
