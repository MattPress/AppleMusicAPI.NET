using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibraryMusicVideoResponseTests")]
    public class LibraryMusicVideoResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibraryMusicVideoResponse.json";

        public LibraryMusicVideoResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
