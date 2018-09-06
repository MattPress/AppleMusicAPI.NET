using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Tests.Clients.Fixtures;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
    public class LibraryPlaylistsClientTests : IClassFixture<LibraryPlaylistsClientFixture>
    {
        protected LibraryPlaylistsClientFixture Fixture { get; }

        public LibraryPlaylistsClientTests(LibraryPlaylistsClientFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
