using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibraryArtistResponseTests")]
    public class LibraryArtistResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibraryArtistResponse.json";

        public LibraryArtistResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact(Skip = "")]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<LibraryArtistResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
