using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Enums;
using Moq;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    public class RatingsClientTests : ClientsTestBase<RatingsClient>
    {
        public RatingsClientTests()
        {
            Client = new RatingsClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }

        public static IEnumerable<object[]> AlbumRelationships =>
            new List<object[]>(
                Enum.GetValues(typeof(AlbumRelationship))
                    .Cast<AlbumRelationship>()
                    .Select(x => new object[] { x })
                    .AsEnumerable()
            );

        public static IEnumerable<object[]> MusicVideoRelationships =>
            new List<object[]>(
                Enum.GetValues(typeof(MusicVideoRelationship))
                    .Cast<MusicVideoRelationship>()
                    .Select(x => new object[] { x })
                    .AsEnumerable()
            );

        public static IEnumerable<object[]> PlaylistRelationships =>
            new List<object[]>(
                Enum.GetValues(typeof(PlaylistRelationship))
                    .Cast<PlaylistRelationship>()
                    .Select(x => new object[] { x })
                    .AsEnumerable()
            );

        public static IEnumerable<object[]> SongRelationships =>
            new List<object[]>(
                Enum.GetValues(typeof(SongRelationship))
                    .Cast<SongRelationship>()
                    .Select(x => new object[] { x })
                    .AsEnumerable()
            );

        public static IEnumerable<object[]> LibraryMusicVideoRelationships =>
            new List<object[]>(
                Enum.GetValues(typeof(LibraryMusicVideoRelationship))
                    .Cast<LibraryMusicVideoRelationship>()
                    .Select(x => new object[] { x })
                    .AsEnumerable()
            );

        public static IEnumerable<object[]> LibraryPlaylistRelationships =>
            new List<object[]>(
                Enum.GetValues(typeof(LibraryPlaylistRelationship))
                    .Cast<LibraryPlaylistRelationship>()
                    .Select(x => new object[] { x })
                    .AsEnumerable()
            );

        public static IEnumerable<object[]> LibrarySongRelationships =>
            new List<object[]>(
                Enum.GetValues(typeof(LibrarySongRelationship))
                    .Cast<LibrarySongRelationship>()
                    .Select(x => new object[] { x })
                    .AsEnumerable()
            );

        public class GetAlbumRating : RatingsClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetAlbumRating(userToken, Id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetAlbumRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetAlbumRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(AlbumRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(AlbumRelationship type)
            {
                // Arrange

                // Act
                await Client.GetAlbumRating(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = new List<AlbumRelationship>
                {
                    AlbumRelationship.Artists,
                    AlbumRelationship.Genres
                };

                // Act
                await Client.GetAlbumRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={AlbumRelationship.Artists.GetValue()},{AlbumRelationship.Genres.GetValue()}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetAlbumRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/albums/{Id}"));
            }
        }

        public class GetMusicVideoRating : RatingsClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMusicVideoRating(userToken, Id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMusicVideoRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMusicVideoRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(MusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(MusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMusicVideoRating(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = new List<MusicVideoRelationship>
                {
                    MusicVideoRelationship.Albums,
                    MusicVideoRelationship.Artists
                };

                // Act
                await Client.GetMusicVideoRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={MusicVideoRelationship.Albums.GetValue()},{MusicVideoRelationship.Artists.GetValue()}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMusicVideoRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/music-videos/{Id}"));
            }
        }

        public class GetPlaylistRating : RatingsClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetPlaylistRating(userToken, Id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetPlaylistRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetPlaylistRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(PlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(PlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetPlaylistRating(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = new List<PlaylistRelationship>
                {
                    PlaylistRelationship.Curator,
                    PlaylistRelationship.Tracks
                };

                // Act
                await Client.GetPlaylistRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={PlaylistRelationship.Curator.GetValue()},{PlaylistRelationship.Tracks.GetValue()}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetPlaylistRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/playlists/{Id}"));
            }
        }

        public class GetSongRating : RatingsClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetSongRating(userToken, Id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetSongRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetSongRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(SongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(SongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetSongRating(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = new List<SongRelationship>
                {
                    SongRelationship.Albums,
                    SongRelationship.Artists
                };

                // Act
                await Client.GetSongRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={SongRelationship.Albums.GetValue()},{SongRelationship.Artists.GetValue()}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetSongRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/songs/{Id}"));
            }
        }

        public class GetStationRating : RatingsClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetStationRating(userToken, Id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetStationRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetStationRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetStationRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/stations/{Id}"));
            }
        }

        public class GetLibraryMusicVideoRating : RatingsClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryMusicVideoRating(userToken, Id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryMusicVideoRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideoRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryMusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryMusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideoRating(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = new List<LibraryMusicVideoRelationship>
                {
                    LibraryMusicVideoRelationship.Albums,
                    LibraryMusicVideoRelationship.Artists
                };

                // Act
                await Client.GetLibraryMusicVideoRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={LibraryMusicVideoRelationship.Albums.GetValue()},{LibraryMusicVideoRelationship.Artists.GetValue()}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideoRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/library-music-videos/{Id}"));
            }
        }

        public class GetLibraryPlaylistRating : RatingsClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryPlaylistRating(userToken, Id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryPlaylistRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylistRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryPlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryPlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylistRating(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = new List<LibraryPlaylistRelationship>
                {
                    LibraryPlaylistRelationship.Tracks,
                    LibraryPlaylistRelationship.Tracks
                };

                // Act
                await Client.GetLibraryPlaylistRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={LibraryPlaylistRelationship.Tracks.GetValue()},{LibraryPlaylistRelationship.Tracks.GetValue()}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylistRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/library-playlists/{Id}"));
            }
        }

        public class GetLibrarySongRating : RatingsClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibrarySongRating(userToken, Id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibrarySongRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibrarySongRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibrarySongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibrarySongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibrarySongRating(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = new List<LibrarySongRelationship>
                {
                    LibrarySongRelationship.Albums,
                    LibrarySongRelationship.Artists
                };

                // Act
                await Client.GetLibrarySongRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={LibrarySongRelationship.Albums.GetValue()},{LibrarySongRelationship.Artists.GetValue()}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibrarySongRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/library-songs/{Id}"));
            }
        }
    }
}
