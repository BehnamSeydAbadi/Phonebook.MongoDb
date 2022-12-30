using Business.Contact.Dtos;
using WebAPI.Contact.ViewModels;

namespace WebAPI.Test.Contact
{
    [TestClass]
    public class UpdateTests : ContactBaseTest
    {
        [TestMethod]
        public async Task UpdateAsync_ShouldWorkSuccessfully()
        {
            var intertingDto = GenerateContactDto();
            var contactId = (await PostAsync(intertingDto)).Data.ToString();
            var updatingDto = GenerateContactDto();

            await PutAsync(contactId, updatingDto);

            var output = await GetAsync(contactId);
            var viewModel = DeserializeJson<ContactViewModel>(output.Data.ToString());
            viewModel.FirstName.Should().Be(updatingDto.FirstName);
            viewModel.LastName.Should().Be(updatingDto.LastName);
            viewModel.PhoneNumber.Should().Be(updatingDto.PhoneNumber);
            viewModel.Address.Should().Be(updatingDto.Address);
            viewModel.Email.Should().Be(updatingDto.Email);
        }
    }
}
