using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "StorefrontResponseTests")]
    public class StorefrontResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "StorefrontResponse.json";

        public StorefrontResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<StorefrontResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
