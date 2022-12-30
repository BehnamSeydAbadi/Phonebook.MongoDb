using WebAPI.Contact.ViewModels;

namespace WebAPI.Test.Contact
{
    [TestClass]
    public class ReadTests : ContactBaseTest
    {
        [TestMethod]
        public async Task GetAsync_ShouldWorkSuccessfully()
        {
            var contactDto = GenerateContactDto();
            var contactId = (await PostAsync(contactDto)).Data.ToString();

            var output = await GetAsync(contactId);

            var viewModel = DeserializeJson<ContactViewModel>(output.Data.ToString());
            viewModel.FirstName.Should().Be(contactDto.FirstName);
        }
    }
}
