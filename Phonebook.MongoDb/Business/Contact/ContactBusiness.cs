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

        public async Task DeleteAsync(string id)
            => await _contactDataAccess.DeleteAsync(id);

        public async Task UpdateAsync(string id, ContactDto dto)
        {
            var entity = await GetAsync(id);

            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.Address = dto.Address;
            entity.Email = dto.Email;

            await _contactDataAccess.UpdateAsync(entity);
        }
    }
}
