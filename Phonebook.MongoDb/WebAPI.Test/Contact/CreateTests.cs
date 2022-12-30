using Business.Contact.Dtos;

namespace WebAPI.Test.Contact
{
    [TestClass]
    public class CreateTests : BaseTest
    {
        public CreateTests() : base("api/Contacts") { }

        [TestMethod]
        public async Task InsertAsync_ShouldWorkSuccessfully()
        {
            var contactDto = new AutoFaker<ContactDto>()
              .RuleFor(fake => fake.FirstName, fake => fake.Name.FirstName())
              .RuleFor(fake => fake.LastName, fake => fake.Name.LastName())
              .RuleFor(fake => fake.PhoneNumber, fake => fake.Phone.PhoneNumber())
              .RuleFor(fake => fake.Address, fake => fake.Address.FullAddress())
              .RuleFor(fake => fake.Email, fake => fake.Internet.Email())
              .Generate();

            var output = await PostAsync(contactDto);

            output.Data.ToString().Should().NotBeNullOrWhiteSpace();
        }
    }
}
