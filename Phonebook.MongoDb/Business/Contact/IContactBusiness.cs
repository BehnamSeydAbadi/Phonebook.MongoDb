using Business.Contact.Dtos;

namespace Business.Contact
{
    public interface IContactBusiness
    {
        Task<int> InsertAsync(ContactDto dto);
    }
}
