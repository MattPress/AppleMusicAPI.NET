using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "AppleCuratorResponseTests")]
    public class AppleCuratorResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "AppleCuratorResponse.json";

        public AppleCuratorResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
