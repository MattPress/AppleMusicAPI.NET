using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
