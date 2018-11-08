using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "RecentlyAddedResponseTests")]
    public class RecentlyAddedResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "RecentlyAddedResponse.json";

        public RecentlyAddedResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact(Skip = "")]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<RecentlyAddedResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
