using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "HistoryResponseTests")]
    public class HistoryResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "HistoryResponse.json";

        public HistoryResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact(Skip = "")]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<HistoryResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
