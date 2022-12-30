namespace WebAPI.Test.Contact
{
    [TestClass]
    public class DeleteTests : ContactBaseTest
    {
        [TestMethod]
        public async Task DeleteAsync_ShouldWorkSuccessfully()
        {
            var contactDto = GenerateContactDto();
            var contactId = (await PostAsync(contactDto)).Data.ToString();

            await DeleteAsync(contactId);

            var output = await GetAsync(contactId);
            output.Data.Should().BeNull();
        }
    }
}
