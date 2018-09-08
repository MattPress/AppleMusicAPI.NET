using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    public class SearchClientTests : ClientsTestBase<SearchClient>
    {
        public SearchClientTests()
        {
            Client = new SearchClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }
    }
}
