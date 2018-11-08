using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "RecommendationResponseTests")]
    public class RecommendationResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "RecommendationResponse.json";

        public RecommendationResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact(Skip = "")]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<RecommendationResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
