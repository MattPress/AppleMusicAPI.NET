using System;
using System.Collections.Generic;
using System.Linq;
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
    [Trait("Category", "LibraryPlaylistsClient")]
    public class LibraryPlaylistsClientTests : ClientsTestBase<LibraryPlaylistsClient>
    {
        public class CreateLibraryPlaylist : LibraryPlaylistsClientTests
        {
            protected LibraryPlaylistCreationRequest Request { get; set; }

            public CreateLibraryPlaylist()
            {
                Request = Fixture.Create<LibraryPlaylistCreationRequest>();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    Request = null;
                }

                base.Dispose(disposing);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.CreateLibraryPlaylist(userToken, Request);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.CreateLibraryPlaylist(UserToken, Request);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryPlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryPlaylistRelationship relationship)
            {
                // Arrange

                // Act
                await Client.CreateLibraryPlaylist(UserToken, Request, new []{ relationship });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={relationship.GetValue()}"));
            }

            [Fact]
            public async Task ValidTracksRelationships_IsAddedToQuery()
            {
                // Arrange - Currently only one relationship
                var relationships = new List<LibraryPlaylistRelationship>
                {
                    LibraryPlaylistRelationship.Tracks
                };

                // Act
                await Client.CreateLibraryPlaylist(UserToken, Request, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.CreateLibraryPlaylist(UserToken, Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/library/playlists"));
            }
        }
    }
}
