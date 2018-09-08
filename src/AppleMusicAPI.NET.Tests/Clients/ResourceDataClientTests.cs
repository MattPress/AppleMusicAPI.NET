using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
    public class ResourceDataClientTests : ClientsTestBase<ResourceDataClient>
    {
        public ResourceDataClientTests()
        {
            Client = new ResourceDataClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }
    }
}
