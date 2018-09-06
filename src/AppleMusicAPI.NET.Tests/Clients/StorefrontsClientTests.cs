using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Tests.Clients.Fixtures;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
    public class StorefrontsClientTests : IClassFixture<StorefrontsClientFixture>
    {
        protected StorefrontsClientFixture Fixture { get; }

        public StorefrontsClientTests(StorefrontsClientFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
