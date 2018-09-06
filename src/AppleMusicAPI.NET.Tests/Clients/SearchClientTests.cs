using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Tests.Clients.Fixtures;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
    public class SearchClientTests : IClassFixture<SearchClientFixture>
    {
        protected SearchClientFixture Fixture { get; }

        public SearchClientTests(SearchClientFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
