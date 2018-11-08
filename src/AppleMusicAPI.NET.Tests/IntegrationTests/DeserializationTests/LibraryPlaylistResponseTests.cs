using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibraryPlaylistResponseTests")]
    public class LibraryPlaylistResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibraryPlaylistResponse.json";

        public LibraryPlaylistResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact(Skip = "")]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<LibraryPlaylistResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
