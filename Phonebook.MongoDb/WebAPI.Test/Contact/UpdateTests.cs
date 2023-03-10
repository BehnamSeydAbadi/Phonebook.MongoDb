using Business.Contact.Exceptions;
using WebAPI.Contact.ViewModels;
using MongoDB.Bson;

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

        [TestMethod]
        public async Task UpdateAsync_WhenNamesAreEmpty_ShouldThrowEmptyNameException()
        {
            var intertingDto = GenerateContactDto();
            var contactId = (await PostAsync(intertingDto)).Data.ToString();

            var updatingDto = DtoBuilder.Create().AddPhoneNumber().AddAddress().AddEmail().Build();

            var output = await PutAsync(contactId, updatingDto);

            output.Error.Should().Be(EmptyNameException.Message);
        }

        [TestMethod]
        public async Task UpdateAsync_WhenPhoneNumberIsEmpty_ShouldThrowEmptyPhoneNumberException()
        {
            var intertingDto = GenerateContactDto();
            var contactId = (await PostAsync(intertingDto)).Data.ToString();

            var updatingDto = DtoBuilder.Create().AddFirstName().AddAddress().AddEmail().Build();

            var output = await PutAsync(contactId, updatingDto);

            output.Error.Should().Be(EmptyPhoneNumberException.Message);
        }

        [TestMethod]
        public async Task UpdateAsync_WhenIdDoesNotExist_ShouldThrowContactNotFoundException()
        {
            var contactDto = GenerateContactDto();

            var fakeId = ObjectId.GenerateNewId().ToString();

            var output = await PutAsync(fakeId, contactDto);

            output.Error.Should().Be(ContactNotFoundException.Message);
        }
    }
}
