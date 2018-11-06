using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "ChartResponseTests")]
    public class ChartResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "ChartResponse.json";

        public ChartResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<ChartResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
