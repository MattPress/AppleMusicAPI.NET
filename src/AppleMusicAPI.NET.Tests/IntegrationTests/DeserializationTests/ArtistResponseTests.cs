using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "ArtistResponseTests")]
    public class ArtistResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "ArtistResponse.json";

        public ArtistResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<ArtistResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
