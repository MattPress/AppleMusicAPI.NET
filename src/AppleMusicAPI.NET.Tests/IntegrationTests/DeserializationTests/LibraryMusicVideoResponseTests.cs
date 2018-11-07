using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibraryMusicVideoResponseTests")]
    public class LibraryMusicVideoResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibraryMusicVideoResponse.json";

        public LibraryMusicVideoResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<LibraryMusicVideoResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
