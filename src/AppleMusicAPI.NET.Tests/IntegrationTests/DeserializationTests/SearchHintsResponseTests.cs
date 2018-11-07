using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "SearchHintsResponseTests")]
    public class SearchHintsResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "SearchHintsResponse.json";

        public SearchHintsResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<SearchHintsResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
