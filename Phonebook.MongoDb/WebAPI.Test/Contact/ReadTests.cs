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
              .RuleFor(fake => fake.FirstName, fake => fake.Random.String())
              .Generate();

            var contactId = (await PostAsync(contactDto)).Data.ToString();

            var output = await GetAsync(contactId);

            var viewModel = output.Data as ContactViewModel;

            viewModel.FirstName.Should().Be(contactDto.FirstName);
        }
    }
}
