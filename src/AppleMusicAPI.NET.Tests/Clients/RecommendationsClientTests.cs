using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
    public class RecommendationsClientTests : ClientsTestBase<RecommendationsClient>
    {
        public RecommendationsClientTests()
        {
            Client = new RecommendationsClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }
    }
}
