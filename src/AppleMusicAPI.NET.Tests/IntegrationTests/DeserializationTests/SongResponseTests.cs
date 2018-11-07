using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "SongResponseTests")]
    public class SongResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "SongResponse.json";

        public SongResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<SongResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
