using Business.Contact.Dtos;
using WebAPI.Contact.ViewModels;

namespace WebAPI.Test.Contact
{
    [TestClass]
    public class UpdateTests : BaseTest
    {
        public UpdateTests() : base("api/Contacts") { }

        [TestMethod]
        public async Task UpdateAsync_ShouldWorkSuccessfully()
        {
            var intertingDto = new AutoFaker<ContactDto>()
              .RuleFor(fake => fake.FirstName, fake => fake.Name.FullName())
              .Generate();

            var contactId = (await PostAsync(intertingDto)).Data.ToString();

            var updatingDto = new AutoFaker<ContactDto>()
              .RuleFor(fake => fake.FirstName, fake => fake.Name.FullName())
              .Generate();

            await PutAsync(contactId, updatingDto);

            var output = await GetAsync(contactId);

            var viewModel = DeserializeJson<ContactViewModel>(output.Data.ToString());

            viewModel.FirstName.Should().Be(updatingDto.FirstName);
        }
    }
}
