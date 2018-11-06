using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "RecommendationResponseTests")]
    public class RecommendationResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "RecommendationResponse.json";

        public RecommendationResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
