using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    public class LibraryPlaylistsClientTests : ClientsTestBase<LibraryPlaylistsClient>
    {
        public LibraryPlaylistsClientTests()
        {
            Client = new LibraryPlaylistsClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }
    }
}
