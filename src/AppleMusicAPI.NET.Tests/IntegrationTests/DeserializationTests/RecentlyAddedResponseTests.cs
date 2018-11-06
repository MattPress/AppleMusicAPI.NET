using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "RecentlyAddedResponseTests")]
    public class RecentlyAddedResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "RecentlyAddedResponse.json";

        public RecentlyAddedResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
