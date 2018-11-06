using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "RatingResponseTests")]
    public class RatingResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "RatingResponse.json";

        public RatingResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
