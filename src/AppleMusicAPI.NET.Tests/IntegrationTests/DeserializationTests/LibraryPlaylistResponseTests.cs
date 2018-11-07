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

        // TODO - Fix Response
        [Fact(Skip = "Response object requires rework")]
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
