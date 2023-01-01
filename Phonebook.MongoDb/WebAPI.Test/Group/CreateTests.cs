using Bogus;
using WebAPI.Group.Dtos;

namespace WebAPI.Test.Group
{
    [TestClass]
    public class CreateTests : BaseTest
    {
        public CreateTests() : base("api/groups") { }

        [TestMethod]
        public async Task InsertAsync_ShouldWorkSuccessfully()
        {
            var groupDto = new AutoFaker<GroupDto>().Generate();

            var output = await PostAsync(groupDto);

            output.Data.ToString().Should().NotBeNullOrWhiteSpace();
        }
    }
}
