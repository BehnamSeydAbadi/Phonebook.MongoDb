using Business.Contact.Dtos;

namespace Business.Contact
{
    internal sealed class ContactBusiness : IContactBusiness
    {
        public Task<int> InsertAsync(ContactDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
