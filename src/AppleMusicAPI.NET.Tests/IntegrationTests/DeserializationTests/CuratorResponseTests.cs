using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "CuratorResponseTests")]
    public class CuratorResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "CuratorResponse.json";

        public CuratorResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
