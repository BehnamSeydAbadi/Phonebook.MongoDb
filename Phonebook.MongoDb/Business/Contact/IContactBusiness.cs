using Business.Contact.Dtos;
using DataAccess.Contact.Entity;

namespace Business.Contact
{
    public interface IContactBusiness
    {
        Task<string> InsertAsync(ContactDto dto);

        Task<ContactEntity> GetAsync(string id);
    }
}
