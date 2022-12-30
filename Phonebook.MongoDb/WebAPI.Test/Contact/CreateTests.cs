using Business.Contact.Dtos;
using Business.Contact.Exceptions;

namespace WebAPI.Test.Contact
{
    [TestClass]
    public class CreateTests : ContactBaseTest
    {
        [TestMethod]
        public async Task InsertAsync_ShouldWorkSuccessfully()
        {
            var contactDto = GenerateContactDto();

            var output = await PostAsync(contactDto);

            output.Data.ToString().Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public async Task InsertAsync_WhenNamesAreEmpty_ShouldThrowEmptyNameException()
        {
            var contactDto = DtoBuilder.Create().AddPhoneNumber().AddAddress().AddEmail().Build();

            var output = await PostAsync(contactDto);

            output.Error.Should().Be(EmptyNameException.Message);
        }
    }
}
