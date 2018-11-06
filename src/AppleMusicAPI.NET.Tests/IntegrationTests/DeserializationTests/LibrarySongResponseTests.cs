using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibrarySongResponseTests")]
    public class LibrarySongResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibrarySongResponse.json";

        public LibrarySongResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
