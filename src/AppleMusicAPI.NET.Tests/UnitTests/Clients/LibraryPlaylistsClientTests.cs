using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Requests;
using AutoFixture;
using Moq;
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

        public class CreateLibraryPlaylist : LibraryPlaylistsClientTests
        {
            public static IEnumerable<object[]> LibraryPlaylistRelationships =>
                new List<object[]>(
                    Enum.GetValues(typeof(LibraryPlaylistRelationship))
                        .Cast<LibraryPlaylistRelationship>()
                        .Select(x => new object[] { x })
                        .AsEnumerable()
                );

            protected Fixture Fixture { get; set; }

            protected LibraryPlaylistCreationRequest Request { get; set; }

            public CreateLibraryPlaylist()
            {
                Fixture = new Fixture();
                Request = Fixture.Create<LibraryPlaylistCreationRequest>();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    Request = null;
                    Fixture = null;
                }

                base.Dispose(disposing);
            }

            [Theory(Skip = "NeedToFixToMockSerialize")]
            [MemberData(nameof(LibraryPlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryPlaylistRelationship relationship)
            {
                // Arrange

                // Act
                await Client.CreateLibraryPlaylist(Request, new []{ relationship });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={relationship.GetValue()}"));
            }

            [Fact(Skip = "NeedToFixToMockSerialize")]
            public async Task MultipleValidRelationships_AreAddedToQuery()
            {
                // Arrange - Currently only one relationship
                var relationships = new List<LibraryPlaylistRelationship>
                {
                    LibraryPlaylistRelationship.Tracks,
                    LibraryPlaylistRelationship.Tracks
                };

                // Act
                await Client.CreateLibraryPlaylist(Request, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={LibraryPlaylistRelationship.Tracks.GetValue()},{LibraryPlaylistRelationship.Tracks.GetValue()}"));
            }

            [Fact(Skip = "NeedToFixToMockSerialize")]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.CreateLibraryPlaylist(Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/library/playlists"));
            }
        }
    }
}
