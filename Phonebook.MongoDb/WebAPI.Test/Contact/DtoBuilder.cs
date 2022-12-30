using Bogus;
using Business.Contact.Dtos;

namespace WebAPI.Test.Contact
{
    internal class DtoBuilder
    {
        internal static DtoBuilder Create() => new();

        private readonly Faker<ContactDto> _faker;

        private DtoBuilder()
        {
            _faker = new Faker<ContactDto>();

            _faker.RuleFor(fake => fake.FirstName, string.Empty);
            _faker.RuleFor(fake => fake.LastName, string.Empty);
            _faker.RuleFor(fake => fake.PhoneNumber, string.Empty);
            _faker.RuleFor(fake => fake.Address, string.Empty);
            _faker.RuleFor(fake => fake.Email, string.Empty);
        }

        internal DtoBuilder AddFirstName()
        {
            _faker.RuleFor(fake => fake.FirstName, fake => fake.Name.FirstName());
            return this;
        }
        internal DtoBuilder AddLastName()
        {
            _faker.RuleFor(fake => fake.LastName, fake => fake.Name.LastName());
            return this;
        }
        internal DtoBuilder AddPhoneNumber()
        {
            _faker.RuleFor(fake => fake.PhoneNumber, fake => fake.Phone.PhoneNumber());
            return this;
        }
        internal DtoBuilder AddAddress()
        {
            _faker.RuleFor(fake => fake.Address, fake => fake.Address.FullAddress());
            return this;
        }
        internal DtoBuilder AddEmail()
        {
            _faker.RuleFor(fake => fake.Email, fake => fake.Internet.Email());
            return this;
        }
        internal ContactDto Build() => _faker.Generate();
    }
}
