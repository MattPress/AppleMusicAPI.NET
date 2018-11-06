using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibrarySearchResponseTests")]
    public class LibrarySearchResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibrarySearchResponse.json";

        public LibrarySearchResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
