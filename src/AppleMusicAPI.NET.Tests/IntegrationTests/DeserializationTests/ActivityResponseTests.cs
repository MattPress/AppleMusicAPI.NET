using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "ActivityResponseTests")]
    public class ActivityResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "ActivityResponse.json";

        public ActivityResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<ActivityResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
