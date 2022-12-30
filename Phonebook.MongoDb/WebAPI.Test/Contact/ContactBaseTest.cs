using Business.Contact.Dtos;

namespace WebAPI.Test.Contact
{
    public abstract class ContactBaseTest : BaseTest
    {
        public ContactBaseTest() : base("api/contacts") { }

        protected ContactDto GenerateContactDto()
            => new AutoFaker<ContactDto>()
                .RuleFor(fake => fake.FirstName, fake => fake.Name.FirstName())
                .RuleFor(fake => fake.LastName, fake => fake.Name.LastName())
                .RuleFor(fake => fake.PhoneNumber, fake => fake.Phone.PhoneNumber())
                .RuleFor(fake => fake.Address, fake => fake.Address.FullAddress())
                .RuleFor(fake => fake.Email, fake => fake.Internet.Email())
                .Generate();
    }
}
