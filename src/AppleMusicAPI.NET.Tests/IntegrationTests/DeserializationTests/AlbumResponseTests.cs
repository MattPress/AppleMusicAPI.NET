using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "AlbumResponseTests")]
    public class AlbumResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "AlbumResponse.json";

        public AlbumResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<AlbumResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
