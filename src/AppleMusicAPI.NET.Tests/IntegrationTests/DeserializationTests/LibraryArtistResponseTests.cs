using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "LibraryArtistResponseTests")]
    public class LibraryArtistResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "LibraryArtistResponse.json";

        public LibraryArtistResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
