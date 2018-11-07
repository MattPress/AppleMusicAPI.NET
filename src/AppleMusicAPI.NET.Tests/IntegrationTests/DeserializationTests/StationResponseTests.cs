using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "StationResponseTests")]
    public class StationResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "StationResponse.json";

        public StationResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<StationResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
