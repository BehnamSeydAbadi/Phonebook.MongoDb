using Business.Contact.Dtos;

namespace WebAPI.Test.Contact
{
    [TestClass]
    public class CreateTests : BaseTest
    {
        public CreateTests() : base("api/Contacts") { }

        [TestMethod]
        public async Task InsertAsync_ShouldWorkSuccessfully()
        {
            var contactDto = new AutoFaker<ContactDto>()
              .RuleFor(fake => fake.FirstName, fake => fake.Random.String())
              .Generate();

            var output = await PostAsync(contactDto);

            output.Data.ToString().Should().NotBeNullOrWhiteSpace();
        }
    }
}
