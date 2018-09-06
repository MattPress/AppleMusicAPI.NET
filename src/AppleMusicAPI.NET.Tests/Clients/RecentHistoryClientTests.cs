using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Tests.Clients.Fixtures;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
    public class RecentHistoryClientTests : IClassFixture<RecentHistoryClientFixture>
    {
        protected RecentHistoryClientFixture Fixture { get; }

        public RecentHistoryClientTests(RecentHistoryClientFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
