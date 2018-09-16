using System;
using System.Linq;
using System.Text.Encodings.Web;
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

        #region Get Multiple Catalog Resource Data Items Tests

        public class GetMultipleCatalogAlbums : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogAlbums(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogAlbums(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogAlbums(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(AlbumRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(AlbumRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogAlbums(Ids, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<AlbumRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogAlbums(Ids, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=artists,genres,tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogAlbums(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/albums"));
            }
        }

        public class GetMultipleCatalogMusicVideos : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogMusicVideos(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogMusicVideos(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogMusicVideos(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(MusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(MusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogMusicVideos(Ids, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<MusicVideoRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogMusicVideos(Ids, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums,artists,genres"));
            }

            [Fact]
            public async Task ValidIsrc_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogMusicVideos(Ids, Storefront, isrc: Isrc);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&{UrlEncoder.Default.Encode("filter[isrc]")}={Isrc}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogMusicVideos(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/music-videos"));
            }
        }

        public class GetMultipleCatalogPlaylists : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogPlaylists(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogPlaylists(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogPlaylists(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(PlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(PlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogPlaylists(Ids, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<PlaylistRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogPlaylists(Ids, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=curator,tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogPlaylists(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/playlists"));
            }
        }

        public class GetMultipleCatalogSongs : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogSongs(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogSongs(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogSongs(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(SongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(SongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogSongs(Ids, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<SongRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogSongs(Ids, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums,artists,genres,station"));
            }

            [Fact]
            public async Task ValidIsrc_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogSongs(Ids, Storefront, isrc: Isrc);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&{UrlEncoder.Default.Encode("filter[isrc]")}={Isrc}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogSongs(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/songs"));
            }
        }

        public class GetMultipleCatalogStations : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogStations(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogStations(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogStations(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogStations(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/stations"));
            }
        }

        public class GetMultipleCatalogArtists : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogArtists(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogArtists(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogArtists(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(ArtistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(ArtistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogArtists(Ids, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<ArtistRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogArtists(Ids, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums,genres,musicVideos,playlists,stations"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogArtists(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/artists"));
            }
        }

        public class GetMultipleCatalogCurators : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogCurators(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogCurators(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogCurators(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(CuratorRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(CuratorRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogCurators(Ids, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<CuratorRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogCurators(Ids, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=playlists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogCurators(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/curators"));
            }
        }

        public class GetMultipleCatalogActivities : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogActivities(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogActivities(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogActivities(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(ActivityRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(ActivityRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogActivities(Ids, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<ActivityRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogActivities(Ids, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=playlists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogActivities(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/activities"));
            }
        }

        public class GetMultipleCatalogAppleCurators : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogAppleCurators(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogAppleCurators(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogAppleCurators(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(AppleCuratorRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(AppleCuratorRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogAppleCurators(Ids, Storefront, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<AppleCuratorRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogAppleCurators(Ids, Storefront, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=playlists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogAppleCurators(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/apple-curators"));
            }
        }

        public class GetMultipleCatalogGenres : ResourceDataClientTests
        {
            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogGenres(ids, Storefront);

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
                Task Task() => Client.GetMultipleCatalogGenres(Ids, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogGenres(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogGenres(Ids, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/genres"));
            }
        }

        #endregion

        #region Get Multiple Library Resource Data Items Tests

        public class GetMultipleLibraryAlbums : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryAlbums(userToken, Ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryAlbums(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryAlbums(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryAlbums(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(LibraryAlbumRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryAlbumRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryAlbums(UserToken, Ids, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibraryAlbumRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleLibraryAlbums(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=artists,tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryAlbums(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/albums"));
            }
        }

        public class GetMultipleLibraryArtists : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryArtists(userToken, Ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryArtists(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryArtists(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryArtists(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(LibraryArtistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryArtistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryArtists(UserToken, Ids, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibraryArtistRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleLibraryArtists(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryArtists(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/artists"));
            }
        }

        public class GetMultipleLibraryMusicVideos : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryMusicVideos(userToken, Ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryMusicVideos(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryMusicVideos(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryMusicVideos(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(LibraryMusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryMusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryMusicVideos(UserToken, Ids, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibraryMusicVideoRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleLibraryMusicVideos(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums,artists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryMusicVideos(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/music-videos"));
            }
        }

        public class GetMultipleLibraryPlaylists : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryPlaylists(userToken, Ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryPlaylists(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryPlaylists(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryPlaylists(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(LibraryPlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryPlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryPlaylists(UserToken, Ids, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibraryPlaylistRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleLibraryPlaylists(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryPlaylists(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/playlists"));
            }
        }

        public class GetMultipleLibrarySongs : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibrarySongs(userToken, Ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [InlineData]
            [InlineData(null)]
            public async Task InvalidIds_ThrowsArgumentNullException(params string[] ids)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibrarySongs(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibrarySongs(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibrarySongs(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(LibrarySongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibrarySongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleLibrarySongs(UserToken, Ids, new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"&include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<LibrarySongRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleLibrarySongs(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums,artists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibrarySongs(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/songs"));
            }
        }

        #endregion

        #region Get Multiple Catalog Resource Data Items by ISRC Tests

        public class GetMultipleCatalogMusicVideosByIsrc : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidIsrc_ThrowsArgumentNullException(string isrc)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogMusicVideosByIsrc(isrc, Storefront);

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
                Task Task() => Client.GetMultipleCatalogMusicVideosByIsrc(Isrc, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIsrc_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogMusicVideosByIsrc(Isrc, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?{UrlEncoder.Default.Encode("filter[isrc]")}={Isrc}"));
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogMusicVideosByIsrc(Isrc, Storefront, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(MusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(MusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogMusicVideosByIsrc(Isrc, Storefront, include: new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<MusicVideoRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogMusicVideosByIsrc(Isrc, Storefront, include: relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("include=albums,artists,genres"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogMusicVideosByIsrc(Isrc, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/music-videos"));
            }
        }

        public class GetMultipleCatalogSongsByIsrc : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidIsrc_ThrowsArgumentNullException(string isrc)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleCatalogSongsByIsrc(isrc, Storefront);

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
                Task Task() => Client.GetMultipleCatalogSongsByIsrc(Isrc, storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidIsrc_IsAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogSongsByIsrc(Isrc, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?{UrlEncoder.Default.Encode("filter[isrc]")}={Isrc}"));
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogSongsByIsrc(Isrc, Storefront, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(SongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(SongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogSongsByIsrc(Isrc, Storefront, include: new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"include={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidRelationships_AreAddedToQuery()
            {
                // Arrange
                var relationships = AllEnumsOfType<SongRelationship>()
                    .ToList();

                // Act
                await Client.GetMultipleCatalogSongsByIsrc(Isrc, Storefront, include: relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("include=albums,artists,genres,station"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleCatalogSongsByIsrc(Isrc, Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/songs"));
            }
        }

        #endregion

        #region Get All Library Resource Data Items Tests

        public class GetAllLibraryAlbums : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetAllLibraryAlbums(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetAllLibraryAlbums(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryAlbumRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryAlbumRelationship type)
            {
                // Arrange

                // Act
                await Client.GetAllLibraryAlbums(UserToken, new[] { type });

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
                await Client.GetAllLibraryAlbums(UserToken, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=artists,tracks"));
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
                await Client.GetAllLibraryAlbums(Storefront, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetAllLibraryAlbums(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/albums"));
            }
        }

        public class GetAllLibraryArtists : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetAllLibraryArtists(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetAllLibraryArtists(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryArtistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryArtistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetAllLibraryArtists(UserToken, new[] { type });

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
                await Client.GetAllLibraryArtists(UserToken, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums"));
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
                await Client.GetAllLibraryArtists(Storefront, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetAllLibraryArtists(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/artists"));
            }
        }

        public class GetAllLibraryMusicVideos : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetAllLibraryMusicVideos(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetAllLibraryMusicVideos(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryMusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryMusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetAllLibraryMusicVideos(UserToken, new[] { type });

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
                await Client.GetAllLibraryMusicVideos(UserToken, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists"));
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
                await Client.GetAllLibraryMusicVideos(Storefront, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetAllLibraryMusicVideos(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/music-videos"));
            }
        }

        public class GetAllLibraryPlaylists : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetAllLibraryPlaylists(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetAllLibraryPlaylists(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibraryPlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryPlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetAllLibraryPlaylists(UserToken, new[] { type });

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
                await Client.GetAllLibraryPlaylists(UserToken, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=tracks"));
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
                await Client.GetAllLibraryPlaylists(Storefront, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetAllLibraryPlaylists(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/playlists"));
            }
        }

        public class GetAllLibrarySongs : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserTask_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetAllLibrarySongs(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetAllLibrarySongs(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(LibrarySongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibrarySongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetAllLibrarySongs(UserToken, new[] { type });

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
                await Client.GetAllLibrarySongs(UserToken, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists"));
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
                await Client.GetAllLibrarySongs(Storefront, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetAllLibrarySongs(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/songs"));
            }
        }

        #endregion

        #region Misc

        public class GetCatalogTopChartsGenres : ResourceDataClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogTopChartsGenres(storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
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
                await Client.GetCatalogTopChartsGenres(Storefront, pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogTopChartsGenres(Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/genres"));
            }
        }

        #endregion
    }
}
