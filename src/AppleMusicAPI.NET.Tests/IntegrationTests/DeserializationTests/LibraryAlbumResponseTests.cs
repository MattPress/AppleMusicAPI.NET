using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibraryAlbumResponseTests")]
    public class LibraryAlbumResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibraryAlbumResponse.json";

        public LibraryAlbumResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
