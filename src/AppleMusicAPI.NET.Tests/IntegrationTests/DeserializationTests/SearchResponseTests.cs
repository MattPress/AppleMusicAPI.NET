using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Models.Responses;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "SearchResponseTests")]
    public class SearchResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "SearchResponse.json";

        public SearchResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }

        [Fact]
        public void Deserialization_ShouldSucceed()
        {
            // Arrange

            // Act
            var response = JsonSerializer.Deserialize<SearchResponse>(JsonResponse);

            // Assert
            Assert.NotNull(response);
        }
    }
}
