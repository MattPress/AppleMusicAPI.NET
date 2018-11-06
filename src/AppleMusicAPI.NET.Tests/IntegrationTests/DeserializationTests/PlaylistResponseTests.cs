using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "PlaylistResponseTests")]
    public class PlaylistResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "PlaylistResponse.json";

        public PlaylistResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<PlaylistResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
