using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibraryAlbumResponseTests")]
    public class LibraryAlbumResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibraryAlbumResponse.json";

        public LibraryAlbumResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<LibraryAlbumResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
