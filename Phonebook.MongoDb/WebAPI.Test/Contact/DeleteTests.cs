using Business.Contact.Dtos;

namespace WebAPI.Test.Contact
{
    [TestClass]
    public class DeleteTests : BaseTest
    {
        public DeleteTests() : base("api/Contacts") { }

        [TestMethod]
        public async Task DeleteAsync_ShouldWorkSuccessfully()
        {
            var contactDto = new AutoFaker<ContactDto>()
              .RuleFor(fake => fake.FirstName, fake => fake.Name.FirstName())
              .RuleFor(fake => fake.LastName, fake => fake.Name.LastName())
              .RuleFor(fake => fake.PhoneNumber, fake => fake.Phone.PhoneNumber())
              .RuleFor(fake => fake.Address, fake => fake.Address.FullAddress())
              .RuleFor(fake => fake.Email, fake => fake.Internet.Email())
              .Generate();

            var contactId = (await PostAsync(contactDto)).Data.ToString();

            await DeleteAsync(contactId);

            var output = await GetAsync(contactId);

            output.Data.Should().BeNull();
        }
    }
}
