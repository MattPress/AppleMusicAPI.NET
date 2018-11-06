using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "HistoryResponseTests")]
    public class HistoryResponseTests : DeserializationTestBase
    {
        public const string JsonResponseResourceFileName = "HistoryResponse.json";

        public HistoryResponseTests()
            : base(JsonResponseResourceFileName)
        {
        }
    }
}
