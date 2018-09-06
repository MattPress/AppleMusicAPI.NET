using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Tests.Clients.Fixtures;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
#pragma warning disable IDE1006 // Naming Styles
    public class iCloudMusicLibraryClientTests : IClassFixture<iCloudMusicLibraryClientFixture>
#pragma warning restore IDE1006 // Naming Styles
    {
        protected iCloudMusicLibraryClientFixture Fixture { get; }

        public iCloudMusicLibraryClientTests(iCloudMusicLibraryClientFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
