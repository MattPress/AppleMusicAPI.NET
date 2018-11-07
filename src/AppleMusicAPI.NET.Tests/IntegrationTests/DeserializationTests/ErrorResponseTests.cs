using AppleMusicAPI.NET.Models.Core;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "ErrorResponseTests")]
    public class ErrorResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "ErrorResponse.json";

        public ErrorResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<ResponseRoot>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
