using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "GenreResponseTests")]
    public class GenreResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "GenreResponse.json";

        public GenreResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<GenreResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
