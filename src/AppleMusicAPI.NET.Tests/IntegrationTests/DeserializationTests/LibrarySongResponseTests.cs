using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibrarySongResponseTests")]
    public class LibrarySongResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibrarySongResponse.json";

        public LibrarySongResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact(Skip = "")]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<LibrarySongResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
