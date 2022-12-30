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
              .RuleFor(fake => fake.FirstName, fake => fake.Name.FirstName())
              .RuleFor(fake => fake.LastName, fake => fake.Name.LastName())
              .RuleFor(fake => fake.PhoneNumber, fake => fake.Phone.PhoneNumber())
              .RuleFor(fake => fake.Address, fake => fake.Address.FullAddress())
              .RuleFor(fake => fake.Email, fake => fake.Internet.Email())
              .Generate();

            var contactId = (await PostAsync(intertingDto)).Data.ToString();

            var updatingDto = new AutoFaker<ContactDto>()
              .RuleFor(fake => fake.FirstName, fake => fake.Name.FirstName())
              .RuleFor(fake => fake.LastName, fake => fake.Name.LastName())
              .RuleFor(fake => fake.PhoneNumber, fake => fake.Phone.PhoneNumber())
              .RuleFor(fake => fake.Address, fake => fake.Address.FullAddress())
              .RuleFor(fake => fake.Email, fake => fake.Internet.Email())
              .Generate();

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
