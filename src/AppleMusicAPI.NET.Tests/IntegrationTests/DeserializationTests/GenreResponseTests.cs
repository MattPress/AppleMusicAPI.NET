using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "GenreResponseTests")]
    public class GenreResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "GenreResponse.json";

        public GenreResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
