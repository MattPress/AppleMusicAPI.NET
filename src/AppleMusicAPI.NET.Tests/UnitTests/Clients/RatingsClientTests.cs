using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    public class RatingsClientTests : ClientsTestBase<RatingsClient>
    {
        public RatingsClientTests()
        {
            Client = new RatingsClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }
    }
}
