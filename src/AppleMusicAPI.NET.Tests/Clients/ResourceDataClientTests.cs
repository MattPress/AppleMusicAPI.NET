using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Tests.Clients.Fixtures;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
    public class ResourceDataClientTests : IClassFixture<ResourceDataClientFixture>
    {
        protected ResourceDataClientFixture Fixture { get; }

        public ResourceDataClientTests(ResourceDataClientFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
