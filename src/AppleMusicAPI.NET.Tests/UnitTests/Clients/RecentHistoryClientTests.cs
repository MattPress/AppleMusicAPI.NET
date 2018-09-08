using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    public class RecentHistoryClientTests : ClientsTestBase<RecentHistoryClient>
    {
        public RecentHistoryClientTests()
        {
            Client = new RecentHistoryClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }
    }
}
