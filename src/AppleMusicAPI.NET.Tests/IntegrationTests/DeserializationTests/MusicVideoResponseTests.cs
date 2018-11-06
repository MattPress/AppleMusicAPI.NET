using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "MusicVideoResponseTests")]
    public class MusicVideoResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "MusicVideoResponse.json";

        public MusicVideoResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<MusicVideoResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
