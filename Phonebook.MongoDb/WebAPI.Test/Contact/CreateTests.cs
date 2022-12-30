using Business.Contact.Dtos;

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
    }
}
