using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "AppleCuratorResponseTests")]
    public class AppleCuratorResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "AppleCuratorResponse.json";

        public AppleCuratorResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<AppleCuratorResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
