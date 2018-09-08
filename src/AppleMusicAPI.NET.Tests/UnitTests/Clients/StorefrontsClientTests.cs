using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    public class StorefrontsClientTests : ClientsTestBase<StorefrontsClient>
    {
        public StorefrontsClientTests()
        {
            Client = new StorefrontsClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }
    }
}
