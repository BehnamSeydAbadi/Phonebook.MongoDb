using Business.Contact.Dtos;

namespace WebAPI.Test.Contact
{
    [TestClass]
    public class CreateTests : BaseTest
    {
        [TestMethod]
        public async Task InsertAsync_ShouldWorkSuccessfully()
        {
            var contactDto = new AutoFaker<ContactDto>()
              .RuleFor(fake => fake.FirstName, fake => fake.Random.String())
              .Generate();

            var response = await _httpClient.PostAsJsonAsync("", contactDto);
            var stringResult = await response.Content.ReadAsStringAsync();
            var output = JsonConvert.DeserializeObject<OutputViewModel>(stringResult);

            ((int)output.Data).Should().BeGreaterThan(default);
        }
    }
}
