using Business.Contact.Exceptions;
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
            ValidateNames(dto.FirstName, dto.LastName);
            ValidatePhoneNumber(dto.PhoneNumber);

            var entity = new ContactEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                Email = dto.Email,
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
            ValidateNames(dto.FirstName, dto.LastName);
            ValidatePhoneNumber(dto.PhoneNumber);

            var entity = await GetAsync(id);

            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.Address = dto.Address;
            entity.Email = dto.Email;

            await _contactDataAccess.UpdateAsync(entity);
        }


        private void ValidateNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                throw new EmptyNameException();
        }
        private void ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new EmptyPhoneNumberException();
        }
    }
}
