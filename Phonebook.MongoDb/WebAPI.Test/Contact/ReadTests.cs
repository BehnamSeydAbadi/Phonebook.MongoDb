using Business.Contact.Dtos;
using WebAPI.Contact.ViewModels;

namespace WebAPI.Test.Contact
{
    [TestClass]
    public class ReadTests : BaseTest
    {
        public ReadTests() : base("api/Contacts") { }

        [TestMethod]
        public async Task GetAsync_ShouldWorkSuccessfully()
        {
            var contactDto = new AutoFaker<ContactDto>()
              .RuleFor(fake => fake.FirstName, fake => fake.Name.FirstName())
              .RuleFor(fake => fake.LastName, fake => fake.Name.LastName())
              .RuleFor(fake => fake.PhoneNumber, fake => fake.Phone.PhoneNumber())
              .RuleFor(fake => fake.Address, fake => fake.Address.FullAddress())
              .RuleFor(fake => fake.Email, fake => fake.Internet.Email())
              .Generate();

            var contactId = (await PostAsync(contactDto)).Data.ToString();

            var output = await GetAsync(contactId);

            var viewModel = DeserializeJson<ContactViewModel>(output.Data.ToString());

            viewModel.FirstName.Should().Be(contactDto.FirstName);
        }
    }
}
