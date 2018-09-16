using System;
using System.Linq;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using Moq;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    [Trait("Category", "ResourceDataClient")]
    public class ResourceDataClientTests : ClientsTestBase<ResourceDataClient>
    {
        #region Get Catalog Resource Data Item Tests

        public class GetCatalogAlbum : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogAlbum(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogAlbum(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(AlbumRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(AlbumRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogAlbum(Id, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<AlbumRelationship>()
                    .ToList();

                // Act
                await Client.GetCatalogAlbum(Id, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=artists,genres,tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogAlbum(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/albums/{Id}"));
            }
        }

        public class GetCatalogMusicVideo : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogMusicVideo(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogMusicVideo(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(MusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(MusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogMusicVideo(Id, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<MusicVideoRelationship>()
                    .ToList();

                // Act
                await Client.GetCatalogMusicVideo(Id, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists,genres"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogMusicVideo(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/music-videos/{Id}"));
            }
        }

        public class GetCatalogPlaylist : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogPlaylist(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogPlaylist(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(PlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(PlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogPlaylist(Id, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<PlaylistRelationship>()
                    .ToList();

                // Act
                await Client.GetCatalogPlaylist(Id, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=curator,tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogPlaylist(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/playlists/{Id}"));
            }
        }

        public class GetCatalogSong : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogSong(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogSong(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(SongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(SongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogSong(Id, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<SongRelationship>()
                    .ToList();

                // Act
                await Client.GetCatalogSong(Id, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists,genres,station"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogSong(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/songs/{Id}"));
            }
        }

        public class GetCatalogStation : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogStation(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogStation(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogStation(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/stations/{Id}"));
            }
        }

        public class GetCatalogArtist : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogArtist(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogArtist(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(ArtistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(ArtistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogArtist(Id, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<ArtistRelationship>()
                    .ToList();

                // Act
                await Client.GetCatalogArtist(Id, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,genres,musicVideos,playlists,stations"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogArtist(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/artists/{Id}"));
            }
        }

        public class GetCatalogCurator : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogCurator(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogCurator(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(CuratorRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(CuratorRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogCurator(Id, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<CuratorRelationship>()
                    .ToList();

                // Act
                await Client.GetCatalogCurator(Id, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=playlists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogCurator(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/curators/{Id}"));
            }
        }

        public class GetCatalogActivity : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogActivity(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogActivity(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(ActivityRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(ActivityRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogActivity(Id, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<ActivityRelationship>()
                    .ToList();

                // Act
                await Client.GetCatalogActivity(Id, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=playlists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogActivity(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/activities/{Id}"));
            }
        }

        public class GetCatalogAppleCurator : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogAppleCurator(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogAppleCurator(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(AppleCuratorRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(AppleCuratorRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogAppleCurator(Id, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<AppleCuratorRelationship>()
                    .ToList();

                // Act
                await Client.GetCatalogAppleCurator(Id, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=playlists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogAppleCurator(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/apple-curators/{Id}"));
            }
        }

        public class GetCatalogGenre : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogGenre(id, Storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogGenre(Id, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogGenre(Id, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/genres/{Id}"));
            }
        }

        #endregion

        #region Get Library Resource Data Item Tests

        public class GetLibraryAlbum : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryAlbum(userToken, Id);

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
                Task Task() => Client.GetLibraryAlbum(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryAlbum(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryAlbumRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryAlbumRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryAlbum(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibraryAlbumRelationship>()
                    .ToList();

                // Act
                await Client.GetLibraryAlbum(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=artists,tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryAlbum(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/albums/{Id}"));
            }
        }

        public class GetLibraryArtist : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryArtist(userToken, Id);

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
                Task Task() => Client.GetLibraryArtist(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryArtist(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryArtistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryArtistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryArtist(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibraryArtistRelationship>()
                    .ToList();

                // Act
                await Client.GetLibraryArtist(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryArtist(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/artists/{Id}"));
            }
        }

        public class GetLibraryMusicVideo : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryMusicVideo(userToken, Id);

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
                Task Task() => Client.GetLibraryMusicVideo(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideo(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryMusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryMusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideo(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibraryMusicVideoRelationship>()
                    .ToList();

                // Act
                await Client.GetLibraryMusicVideo(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideo(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/music-videos/{Id}"));
            }
        }

        public class GetLibraryPlaylist : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryPlaylist(userToken, Id);

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
                Task Task() => Client.GetLibraryPlaylist(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylist(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryPlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryPlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylist(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibraryPlaylistRelationship>()
                    .ToList();

                // Act
                await Client.GetLibraryPlaylist(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylist(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/playlists/{Id}"));
            }
        }

        public class GetLibrarySong : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibrarySong(userToken, Id);

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
                Task Task() => Client.GetLibrarySong(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibrarySong(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibrarySongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibrarySongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibrarySong(UserToken, Id, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibrarySongRelationship>()
                    .ToList();

                // Act
                await Client.GetLibrarySong(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibrarySong(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/songs/{Id}"));
            }
        }

        #endregion

        #region Get Catalog Resource Data Item Relationship Tests

        public class GetCatalogAlbumRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogAlbumRelationship(id, Storefront, AlbumRelationship.Artists);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogAlbumRelationship(Id, storefront, AlbumRelationship.Artists);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(AlbumRelationships))]
            public async Task ValidRelationship_IsAddedToPath(AlbumRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogAlbumRelationship(Id, Storefront, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogAlbumRelationship(Id, Storefront, AlbumRelationship.Artists, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidArtistRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogAlbumRelationship(Id, Storefront, AlbumRelationship.Artists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/albums/{Id}/artists"));
            }

            [Fact]
            public async Task WithValidGenreRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogAlbumRelationship(Id, Storefront, AlbumRelationship.Genres);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/albums/{Id}/genres"));
            }

            [Fact]
            public async Task WithValidTrackRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogAlbumRelationship(Id, Storefront, AlbumRelationship.Tracks);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/albums/{Id}/tracks"));
            }
        }

        public class GetCatalogMusicVideoRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogMusicVideoRelationship(id, Storefront, MusicVideoRelationship.Albums);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogMusicVideoRelationship(Id, storefront, MusicVideoRelationship.Albums);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(MusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToPath(MusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogMusicVideoRelationship(Id, Storefront, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogMusicVideoRelationship(Id, Storefront, MusicVideoRelationship.Albums, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogMusicVideoRelationship(Id, Storefront, MusicVideoRelationship.Albums);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/music-videos/{Id}/albums"));
            }

            [Fact]
            public async Task WithValidArtistsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogMusicVideoRelationship(Id, Storefront, MusicVideoRelationship.Artists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/music-videos/{Id}/artists"));
            }

            [Fact]
            public async Task WithValidGenresRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogMusicVideoRelationship(Id, Storefront, MusicVideoRelationship.Genres);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/music-videos/{Id}/genres"));
            }
        }

        public class GetCatalogPlaylistRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogPlaylistRelationship(id, Storefront, PlaylistRelationship.Curator);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogPlaylistRelationship(Id, storefront, PlaylistRelationship.Curator);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(PlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToPath(PlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogPlaylistRelationship(Id, Storefront, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogPlaylistRelationship(Id, Storefront, PlaylistRelationship.Curator, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogPlaylistRelationship(Id, Storefront, PlaylistRelationship.Curator);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/playlists/{Id}/curator"));
            }

            [Fact]
            public async Task WithValidArtistsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogPlaylistRelationship(Id, Storefront, PlaylistRelationship.Tracks);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/playlists/{Id}/tracks"));
            }
        }

        public class GetCatalogSongRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogSongRelationship(id, Storefront, SongRelationship.Albums);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogSongRelationship(Id, storefront, SongRelationship.Albums);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(SongRelationships))]
            public async Task ValidRelationship_IsAddedToPath(SongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogSongRelationship(Id, Storefront, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogSongRelationship(Id, Storefront, SongRelationship.Albums, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogSongRelationship(Id, Storefront, SongRelationship.Albums);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/songs/{Id}/albums"));
            }

            [Fact]
            public async Task WithValidArtistsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogSongRelationship(Id, Storefront, SongRelationship.Artists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/songs/{Id}/artists"));
            }

            [Fact]
            public async Task WithValidGenresRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogSongRelationship(Id, Storefront, SongRelationship.Genres);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/songs/{Id}/genres"));
            }

            [Fact]
            public async Task WithValidStationRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogSongRelationship(Id, Storefront, SongRelationship.Station);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/songs/{Id}/station"));
            }
        }

        public class GetCatalogArtistRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogArtistRelationship(id, Storefront, ArtistRelationship.Albums);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogArtistRelationship(Id, storefront, ArtistRelationship.Albums);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(ArtistRelationships))]
            public async Task ValidRelationship_IsAddedToPath(ArtistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogArtistRelationship(Id, Storefront, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogArtistRelationship(Id, Storefront, ArtistRelationship.Albums, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogArtistRelationship(Id, Storefront, ArtistRelationship.Albums);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/artists/{Id}/albums"));
            }

            [Fact]
            public async Task WithValidGenresRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogArtistRelationship(Id, Storefront, ArtistRelationship.Genres);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/artists/{Id}/genres"));
            }

            [Fact]
            public async Task WithValidMusicVideosRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogArtistRelationship(Id, Storefront, ArtistRelationship.MusicVideos);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/artists/{Id}/musicVideos"));
            }

            [Fact]
            public async Task WithValidPlaylistsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogArtistRelationship(Id, Storefront, ArtistRelationship.Playlists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/artists/{Id}/playlists"));
            }

            [Fact]
            public async Task WithValidStationsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogArtistRelationship(Id, Storefront, ArtistRelationship.Stations);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/artists/{Id}/stations"));
            }
        }

        public class GetCatalogCuratorRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogCuratorRelationship(id, Storefront, CuratorRelationship.Playlists);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogCuratorRelationship(Id, storefront, CuratorRelationship.Playlists);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(CuratorRelationships))]
            public async Task ValidRelationship_IsAddedToPath(CuratorRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogCuratorRelationship(Id, Storefront, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogCuratorRelationship(Id, Storefront, CuratorRelationship.Playlists, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogCuratorRelationship(Id, Storefront, CuratorRelationship.Playlists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/curators/{Id}/playlists"));
            }
        }

        public class GetCatalogActivityRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogActivityRelationship(id, Storefront, ActivityRelationship.Playlists);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogActivityRelationship(Id, storefront, ActivityRelationship.Playlists);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(ActivityRelationships))]
            public async Task ValidRelationship_IsAddedToPath(ActivityRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogActivityRelationship(Id, Storefront, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogActivityRelationship(Id, Storefront, ActivityRelationship.Playlists, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogActivityRelationship(Id, Storefront, ActivityRelationship.Playlists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/activities/{Id}/playlists"));
            }
        }

        public class GetCatalogAppleCuratorRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidId_ThrowsArgumentNullException(string id)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogAppleCuratorRelationship(id, Storefront, AppleCuratorRelationship.Playlists);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogAppleCuratorRelationship(Id, storefront, AppleCuratorRelationship.Playlists);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(AppleCuratorRelationships))]
            public async Task ValidRelationship_IsAddedToPath(AppleCuratorRelationship type)
            {
                // Arrange

                // Act
                await Client.GetCatalogAppleCuratorRelationship(Id, Storefront, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogAppleCuratorRelationship(Id, Storefront, AppleCuratorRelationship.Playlists, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogAppleCuratorRelationship(Id, Storefront, AppleCuratorRelationship.Playlists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/apple-curators/{Id}/playlists"));
            }
        }

        #endregion

        #region Get Library Resource Data Item Relationship Tests

        public class GetLibraryAlbumRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryAlbumRelationship(userToken, Id, LibraryAlbumRelationship.Artists);

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
                Task Task() => Client.GetLibraryAlbumRelationship(UserToken, id, LibraryAlbumRelationship.Artists);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryAlbumRelationship(UserToken, Id, LibraryAlbumRelationship.Artists);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryAlbumRelationships))]
            public async Task ValidRelationship_IsAddedToPath(LibraryAlbumRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryAlbumRelationship(UserToken, Id, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task WithPageOptionsArgument_ShouldIncludePageOptionsInQuery()
            {
                // Arrange
                var pageOptions = new PageOptions
                {
                    Limit = 10,
                    Offset = 50
                };

                // Act
                await Client.GetLibraryAlbumRelationship(UserToken, Id, LibraryAlbumRelationship.Artists, pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidArtistsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryAlbumRelationship(UserToken, Id, LibraryAlbumRelationship.Artists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/albums/{Id}/artists"));
            }

            [Fact]
            public async Task WithValidTracksRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryAlbumRelationship(UserToken, Id, LibraryAlbumRelationship.Tracks);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/albums/{Id}/tracks"));
            }
        }

        public class GetLibraryArtistRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryArtistRelationship(userToken, Id, LibraryArtistRelationship.Albums);

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
                Task Task() => Client.GetLibraryArtistRelationship(UserToken, id, LibraryArtistRelationship.Albums);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryArtistRelationship(UserToken, Id, LibraryArtistRelationship.Albums);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryArtistRelationships))]
            public async Task ValidRelationship_IsAddedToPath(LibraryArtistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryArtistRelationship(UserToken, Id, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetLibraryArtistRelationship(Id, Storefront, LibraryArtistRelationship.Albums, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryArtistRelationship(UserToken, Id, LibraryArtistRelationship.Albums);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/artists/{Id}/albums"));
            }
        }

        public class GetLibraryMusicVideoRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryMusicVideoRelationship(userToken, Id, LibraryMusicVideoRelationship.Albums);

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
                Task Task() => Client.GetLibraryMusicVideoRelationship(UserToken, id, LibraryMusicVideoRelationship.Albums);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideoRelationship(UserToken, Id, LibraryMusicVideoRelationship.Albums);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryMusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToPath(LibraryMusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideoRelationship(UserToken, Id, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideoRelationship(Id, Storefront, LibraryMusicVideoRelationship.Albums, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideoRelationship(UserToken, Id, LibraryMusicVideoRelationship.Albums);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/music-videos/{Id}/albums"));
            }

            [Fact]
            public async Task WithValidArtistsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryMusicVideoRelationship(UserToken, Id, LibraryMusicVideoRelationship.Artists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/music-videos/{Id}/artists"));
            }
        }

        public class GetLibraryPlaylistRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibraryPlaylistRelationship(userToken, Id, LibraryPlaylistRelationship.Tracks);

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
                Task Task() => Client.GetLibraryPlaylistRelationship(UserToken, id, LibraryPlaylistRelationship.Tracks);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylistRelationship(UserToken, Id, LibraryPlaylistRelationship.Tracks);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryPlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToPath(LibraryPlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylistRelationship(UserToken, Id, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylistRelationship(Id, Storefront, LibraryPlaylistRelationship.Tracks, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidTracksRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibraryPlaylistRelationship(UserToken, Id, LibraryPlaylistRelationship.Tracks);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/playlists/{Id}/tracks"));
            }
        }

        public class GetLibrarySongRelationship : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetLibrarySongRelationship(userToken, Id, LibrarySongRelationship.Albums);

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
                Task Task() => Client.GetLibrarySongRelationship(UserToken, id, LibrarySongRelationship.Albums);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetLibrarySongRelationship(UserToken, Id, LibrarySongRelationship.Albums);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibrarySongRelationships))]
            public async Task ValidRelationship_IsAddedToPath(LibrarySongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetLibrarySongRelationship(UserToken, Id, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(type.GetValue()));
            }

            [Fact]
            public async Task ValidLimit_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetLibrarySongRelationship(Id, Storefront, LibrarySongRelationship.Albums, 9);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?limit=9"));
            }

            [Fact]
            public async Task WithValidAlbumsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibrarySongRelationship(UserToken, Id, LibrarySongRelationship.Albums);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/songs/{Id}/albums"));
            }

            [Fact]
            public async Task WithValidArtistsRelationship_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetLibrarySongRelationship(UserToken, Id, LibrarySongRelationship.Artists);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/songs/{Id}/artists"));
            }
        }

        #endregion

        #region Get Multiple Resource Data Items Tests



        #endregion

        #region Get Multiple Resource Data Items by ISRC Tests



        #endregion
    }
}
