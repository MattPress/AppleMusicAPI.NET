using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibraryPlaylistResponseTests")]
    public class LibraryPlaylistResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibraryPlaylistResponse.json";

        public LibraryPlaylistResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
