using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
#pragma warning disable IDE1006 // Naming Styles
    public class iCloudMusicLibraryClientTests : ClientsTestBase<iCloudMusicLibraryClient>
#pragma warning restore IDE1006 // Naming Styles
    {
        public iCloudMusicLibraryClientTests()
        {
            Client = new iCloudMusicLibraryClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }
    }
}
