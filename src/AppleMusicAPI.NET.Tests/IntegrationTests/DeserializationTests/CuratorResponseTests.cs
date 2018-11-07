using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "CuratorResponseTests")]
    public class CuratorResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "CuratorResponse.json";

        public CuratorResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<CuratorResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
