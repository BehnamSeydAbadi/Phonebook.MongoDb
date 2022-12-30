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
              .RuleFor(fake => fake.FirstName, fake => fake.Name.FullName())
              .Generate();

            var contactId = (await PostAsync(contactDto)).Data.ToString();

            await DeleteAsync(contactId);

            var output = await GetAsync(contactId);

            output.Data.Should().BeNull();
        }
    }
}
