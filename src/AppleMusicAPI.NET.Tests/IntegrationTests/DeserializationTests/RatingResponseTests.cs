using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "RatingResponseTests")]
    public class RatingResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "RatingResponse.json";

        public RatingResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact(Skip = "")]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<RatingResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
