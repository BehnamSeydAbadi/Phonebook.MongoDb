using Business.Contact.Dtos;

namespace Business.Contact
{
    public interface IContactBusiness
    {
        Task<string> InsertAsync(ContactDto dto);
    }
}
