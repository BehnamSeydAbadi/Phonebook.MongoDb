using DataAccess.Contact.Entity;
using Business.Contact.Dtos;
using DataAccess.Contact;

namespace Business.Contact
{
    internal sealed class ContactBusiness : IContactBusiness
    {
        private readonly IContactDataAccess _contactDataAccess;

        public ContactBusiness(IContactDataAccess contactDataAccess)
        {
            _contactDataAccess = contactDataAccess;
        }
        public async Task<string> InsertAsync(ContactDto dto)
        {
            var entity = new ContactEntity
            {
                FirstName = dto.FirstName
            };

            await _contactDataAccess.InsertAsync(entity);

            return entity.Id;
        }

        public async Task<ContactEntity> GetAsync(string id)
            => await _contactDataAccess.GetAsync(id);
    }
}
