using Bogus;

namespace WebAPI.Test.Group
{
    [TestClass]
    public class CreateTests : BaseTest
    {
        public CreateTests() : base("api/groups") { }

        [TestMethod]
        public async Task InsertAsync_ShouldWorkSuccessfully()
        {
            var title = string.Empty;

            var output = await PostAsync(title);

            output.Data.ToString().Should().NotBeNullOrWhiteSpace();
        }
    }
}
