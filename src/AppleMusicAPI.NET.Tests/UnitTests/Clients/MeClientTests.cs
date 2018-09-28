using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Requests;
using AutoFixture;
using Moq;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    [Trait("Category", "MeClientTests")]
    public class MeClientTests : ClientsTestBase<MeClient>
    {
        public class AddResourceToLibrary : MeClientTests
        {
            private readonly Dictionary<iCloudMusicLibraryType, List<string>> _ids = new Dictionary<iCloudMusicLibraryType, List<string>>
            {
                { iCloudMusicLibraryType.Albums, new List<string> { "Album1", "Album2" } },
                { iCloudMusicLibraryType.MusicVideos, new List<string> { "MusicVideo1", "MusicVideo2" } }
            };

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.AddResourceToLibrary(userToken, _ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task NullIdsCollection_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddResourceToLibrary(UserToken, null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task EmptyIdsCollection_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddResourceToLibrary(UserToken, new Dictionary<iCloudMusicLibraryType, List<string>>());

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task EmptyTypeIdsCollection_ThrowsArgumentNullException()
            {
                // Arrange
                var ids = new Dictionary<iCloudMusicLibraryType, List<string>>
                {
                    { iCloudMusicLibraryType.Albums, new List<string>() }
                };

                // Act
                Task Task() => Client.AddResourceToLibrary(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.AddResourceToLibrary(UserToken, _ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidAlbumsTypeAndIds_AreAddedToQuery()
            {
                // Arrange
                var ids = new Dictionary<iCloudMusicLibraryType, List<string>>
                {
                    { iCloudMusicLibraryType.Albums, new List<string>{ "Id1", "Id2" } }
                };

                // Act
                await Client.AddResourceToLibrary(UserToken, ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?{UrlEncoder.Default.Encode("ids[albums]")}=Id1,Id2"));
            }

            [Fact]
            public async Task ValidMusicVideosTypeAndIds_AreAddedToQuery()
            {
                // Arrange
                var ids = new Dictionary<iCloudMusicLibraryType, List<string>>
                {
                    { iCloudMusicLibraryType.MusicVideos, new List<string>{ "Id1", "Id2" } }
                };

                // Act
                await Client.AddResourceToLibrary(UserToken, ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?{UrlEncoder.Default.Encode("ids[music-videos]")}=Id1,Id2"));
            }

            [Fact]
            public async Task ValidPlaylistsTypeAndIds_AreAddedToQuery()
            {
                // Arrange
                var ids = new Dictionary<iCloudMusicLibraryType, List<string>>
                {
                    { iCloudMusicLibraryType.Playlists, new List<string>{ "Id1", "Id2" } }
                };

                // Act
                await Client.AddResourceToLibrary(UserToken, ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?{UrlEncoder.Default.Encode("ids[playlists]")}=Id1,Id2"));
            }

            [Fact]
            public async Task ValidSongsTypeAndIds_AreAddedToQuery()
            {
                // Arrange
                var ids = new Dictionary<iCloudMusicLibraryType, List<string>>
                {
                    { iCloudMusicLibraryType.Songs, new List<string>{ "Id1", "Id2" } }
                };

                // Act
                await Client.AddResourceToLibrary(UserToken, ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?{UrlEncoder.Default.Encode("ids[songs]")}=Id1,Id2"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.AddResourceToLibrary(UserToken, _ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/library"));
            }
        }

        public class CreateLibraryPlaylist : MeClientTests
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
                await Client.CreateLibraryPlaylist(UserToken, Request, new[] { relationship });

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

        public class LibraryResourcesSearch : MeClientTests
        {
            public static IEnumerable<object[]> LibraryResources => AllEnumsMemberData<LibraryResource>();

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.LibraryResourcesSearch(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.LibraryResourcesSearch(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidTerm_IsAddedToQuery()
            {
                // Arrange
                const string term = "TestTerm";

                // Act
                await Client.LibraryResourcesSearch(UserToken, term);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?term={term}"));
            }

            [Fact]
            public async Task ValidTermWithSpaces_IsJoinedByPluses()
            {
                // Arrange
                const string term = "Test Term";

                // Act
                await Client.LibraryResourcesSearch(UserToken, term);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?term=Test{UrlEncoder.Default.Encode("+")}Term"));
            }

            [Theory]
            [MemberData(nameof(LibraryResources))]
            public async Task ValidType_IsAddedToQuery(LibraryResource type)
            {
                // Arrange

                // Act
                await Client.LibraryResourcesSearch(UserToken, types: new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidAlbumsTypes_IsAddedToQuery()
            {
                // Arrange
                var types = new List<LibraryResource>
                {
                    LibraryResource.Albums
                };

                // Act
                await Client.LibraryResourcesSearch(UserToken, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=library-albums"));
            }

            [Fact]
            public async Task ValidArtistsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<LibraryResource>
                {
                    LibraryResource.Artists
                };

                // Act
                await Client.LibraryResourcesSearch(UserToken, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=library-artists"));
            }

            [Fact]
            public async Task ValidMusicVideosType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<LibraryResource>
                {
                    LibraryResource.MusicVideos
                };

                // Act
                await Client.LibraryResourcesSearch(UserToken, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=library-music-videos"));
            }

            [Fact]
            public async Task ValidPlaylistsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<LibraryResource>
                {
                    LibraryResource.Playlists
                };

                // Act
                await Client.LibraryResourcesSearch(UserToken, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=library-playlists"));
            }

            [Fact]
            public async Task ValidSongsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<LibraryResource>
                {
                    LibraryResource.Songs
                };

                // Act
                await Client.LibraryResourcesSearch(UserToken, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=library-songs"));
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
                await Client.LibraryResourcesSearch(UserToken, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.LibraryResourcesSearch(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/library/search"));
            }
        }

        public class GetRecommendation : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetRecommendation(userToken, Id);

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
                Task Task() => Client.GetRecommendation(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetRecommendation(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
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
                await Client.GetRecommendation(UserToken, Id, pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetRecommendation(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/recommendations/{Id}"));
            }
        }

        public class GetMultipleRecommendations : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleRecommendations(userToken, Ids);

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
                Task Task() => Client.GetMultipleRecommendations(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleRecommendations(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleRecommendations(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
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
                await Client.GetMultipleRecommendations(UserToken, Ids, pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleRecommendations(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/recommendations"));
            }
        }

        public class GetDefaultRecommendations : MeClientTests
        {
            public static IEnumerable<object[]> RecommendationTypes => AllEnumsMemberData<RecommendationType>();

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetDefaultRecommendations(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetDefaultRecommendations(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Theory]
            [MemberData(nameof(RecommendationTypes))]
            public async Task ValidType_IsAddedToQuery(RecommendationType type)
            {
                // Arrange

                // Act
                await Client.GetDefaultRecommendations(UserToken, type);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?type={type.GetValue()}"));
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
                await Client.GetDefaultRecommendations(UserToken, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains($"limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetDefaultRecommendations(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/recommendations"));
            }
        }

        public class GetUsersStorefront : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetUsersStorefront(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetUsersStorefront(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetUsersStorefront(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/storefront"));
            }
        }

        public class GetAlbumRating : MeClientTests
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
                var relationships = AllEnumsOfType<AlbumRelationship>()
                    .ToList();

                // Act
                await Client.GetAlbumRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=artists,genres,tracks"));
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

        public class GetMusicVideoRating : MeClientTests
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
                var relationships = AllEnumsOfType<MusicVideoRelationship>()
                    .ToList();

                // Act
                await Client.GetMusicVideoRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists,genres"));
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

        public class GetPlaylistRating : MeClientTests
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
                var relationships = AllEnumsOfType<PlaylistRelationship>()
                    .ToList();

                // Act
                await Client.GetPlaylistRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=curator,tracks"));
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

        public class GetSongRating : MeClientTests
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
                var relationships = AllEnumsOfType<SongRelationship>()
                    .ToList();

                // Act
                await Client.GetSongRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists,genres,station"));
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

        public class GetStationRating : MeClientTests
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

        public class GetLibraryMusicVideoRating : MeClientTests
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
                var relationships = AllEnumsOfType<LibraryMusicVideoRelationship>()
                    .ToList();

                // Act
                await Client.GetLibraryMusicVideoRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists"));
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

        public class GetLibraryPlaylistRating : MeClientTests
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
                var relationships = AllEnumsOfType<LibraryPlaylistRelationship>()
                    .ToList();

                // Act
                await Client.GetLibraryPlaylistRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=tracks"));
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

        public class GetLibrarySongRating : MeClientTests
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
                var relationships = AllEnumsOfType<LibrarySongRelationship>()
                    .ToList();

                // Act
                await Client.GetLibrarySongRating(UserToken, Id, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?include=albums,artists"));
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

        public class GetMultipleAlbumRatings : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleAlbumRatings(userToken, Ids);

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
                Task Task() => Client.GetMultipleAlbumRatings(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleAlbumRatings(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleAlbumRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(AlbumRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(AlbumRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleAlbumRatings(UserToken, Ids, new[] { type });

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
                await Client.GetMultipleAlbumRatings(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=artists,genres,tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleAlbumRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/albums"));
            }
        }

        public class GetMultipleMusicVideoRatings : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleMusicVideoRatings(userToken, Ids);

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
                Task Task() => Client.GetMultipleMusicVideoRatings(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleMusicVideoRatings(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleMusicVideoRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(MusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(MusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleMusicVideoRatings(UserToken, Ids, new[] { type });

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
                await Client.GetMultipleMusicVideoRatings(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums,artists,genres"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleMusicVideoRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/music-videos"));
            }
        }

        public class GetMultiplePlaylistRatings : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultiplePlaylistRatings(userToken, Ids);

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
                Task Task() => Client.GetMultiplePlaylistRatings(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultiplePlaylistRatings(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultiplePlaylistRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(PlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(PlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultiplePlaylistRatings(UserToken, Ids, new[] { type });

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
                await Client.GetMultiplePlaylistRatings(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=curator,tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultiplePlaylistRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/ratings/playlists"));
            }
        }

        public class GetMultipleSongRatings : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleSongRatings(userToken, Ids);

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
                Task Task() => Client.GetMultipleSongRatings(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleSongRatings(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleSongRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(SongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(SongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleSongRatings(UserToken, Ids, new[] { type });

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
                await Client.GetMultipleSongRatings(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums,artists,genres,station"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleSongRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/ratings/songs"));
            }
        }

        public class GetMultipleStationRatings : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleStationRatings(userToken, Ids);

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
                Task Task() => Client.GetMultipleStationRatings(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleStationRatings(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleStationRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleStationRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/ratings/stations"));
            }
        }

        public class GetMultipleLibraryMusicVideoRatings : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryMusicVideoRatings(userToken, Ids);

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
                Task Task() => Client.GetMultipleLibraryMusicVideoRatings(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryMusicVideoRatings(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryMusicVideoRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(LibraryMusicVideoRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryMusicVideoRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryMusicVideoRatings(UserToken, Ids, new[] { type });

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
                await Client.GetMultipleLibraryMusicVideoRatings(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums,artists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryMusicVideoRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/ratings/library-music-videos"));
            }
        }

        public class GetMultipleLibraryPlaylistRatings : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibraryPlaylistRatings(userToken, Ids);

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
                Task Task() => Client.GetMultipleLibraryPlaylistRatings(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryPlaylistRatings(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryPlaylistRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(LibraryPlaylistRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibraryPlaylistRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryPlaylistRatings(UserToken, Ids, new[] { type });

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
                await Client.GetMultipleLibraryPlaylistRatings(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=tracks"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibraryPlaylistRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/ratings/library-playlists"));
            }
        }

        public class GetMultipleLibrarySongRatings : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetMultipleLibrarySongRatings(userToken, Ids);

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
                Task Task() => Client.GetMultipleLibrarySongRatings(UserToken, ids);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibrarySongRatings(UserToken, Ids);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task ValidIdsCollections_AreAddedToQuery()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibrarySongRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?ids={Ids[0]},{Ids[1]}"));
            }

            [Theory]
            [MemberData(nameof(LibrarySongRelationships))]
            public async Task ValidRelationship_IsAddedToQuery(LibrarySongRelationship type)
            {
                // Arrange

                // Act
                await Client.GetMultipleLibrarySongRatings(UserToken, Ids, new[] { type });

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
                await Client.GetMultipleLibrarySongRatings(UserToken, Ids, relationships);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Contains("&include=albums,artists"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetMultipleLibrarySongRatings(UserToken, Ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/ratings/library-songs"));
            }
        }

        public class AddAlbumRating : MeClientTests
        {
            public RatingRequest Request { get; set; }

            public AddAlbumRating()
            {
                Request = Fixture.Create<RatingRequest>();
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
                Task Task() => Client.AddAlbumRating(userToken, Id, Request);

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
                Task Task() => Client.AddAlbumRating(UserToken, id, Request);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task InvalidRequest_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddAlbumRating(UserToken, Id, null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.AddAlbumRating(UserToken, Id, Request);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.AddAlbumRating(UserToken, Id, Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/albums/{Id}"));
            }
        }

        public class AddMusicVideoRating : MeClientTests
        {
            public RatingRequest Request { get; set; }

            public AddMusicVideoRating()
            {
                Request = Fixture.Create<RatingRequest>();
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
                Task Task() => Client.AddMusicVideoRating(userToken, Id, Request);

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
                Task Task() => Client.AddMusicVideoRating(UserToken, id, Request);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task InvalidRequest_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddMusicVideoRating(UserToken, Id, null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.AddMusicVideoRating(UserToken, Id, Request);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.AddMusicVideoRating(UserToken, Id, Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/music-videos/{Id}"));
            }
        }

        public class AddPlaylistRating : MeClientTests
        {
            public RatingRequest Request { get; set; }

            public AddPlaylistRating()
            {
                Request = Fixture.Create<RatingRequest>();
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
                Task Task() => Client.AddPlaylistRating(userToken, Id, Request);

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
                Task Task() => Client.AddPlaylistRating(UserToken, id, Request);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task InvalidRequest_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddPlaylistRating(UserToken, Id, null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.AddPlaylistRating(UserToken, Id, Request);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.AddPlaylistRating(UserToken, Id, Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/playlists/{Id}"));
            }
        }

        public class AddSongRating : MeClientTests
        {
            public RatingRequest Request { get; set; }

            public AddSongRating()
            {
                Request = Fixture.Create<RatingRequest>();
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
                Task Task() => Client.AddSongRating(userToken, Id, Request);

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
                Task Task() => Client.AddSongRating(UserToken, id, Request);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task InvalidRequest_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddSongRating(UserToken, Id, null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.AddSongRating(UserToken, Id, Request);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.AddSongRating(UserToken, Id, Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/songs/{Id}"));
            }
        }

        public class AddStationRating : MeClientTests
        {
            public RatingRequest Request { get; set; }

            public AddStationRating()
            {
                Request = Fixture.Create<RatingRequest>();
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
                Task Task() => Client.AddStationRating(userToken, Id, Request);

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
                Task Task() => Client.AddStationRating(UserToken, id, Request);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task InvalidRequest_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddStationRating(UserToken, Id, null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.AddStationRating(UserToken, Id, Request);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.AddStationRating(UserToken, Id, Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/stations/{Id}"));
            }
        }

        public class AddLibraryMusicVideoRating : MeClientTests
        {
            public RatingRequest Request { get; set; }

            public AddLibraryMusicVideoRating()
            {
                Request = Fixture.Create<RatingRequest>();
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
                Task Task() => Client.AddLibraryMusicVideoRating(userToken, Id, Request);

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
                Task Task() => Client.AddLibraryMusicVideoRating(UserToken, id, Request);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task InvalidRequest_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddLibraryMusicVideoRating(UserToken, Id, null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.AddLibraryMusicVideoRating(UserToken, Id, Request);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.AddLibraryMusicVideoRating(UserToken, Id, Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/library-music-videos/{Id}"));
            }
        }

        public class AddLibraryPlaylistRating : MeClientTests
        {
            public RatingRequest Request { get; set; }

            public AddLibraryPlaylistRating()
            {
                Request = Fixture.Create<RatingRequest>();
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
                Task Task() => Client.AddLibraryPlaylistRating(userToken, Id, Request);

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
                Task Task() => Client.AddLibraryPlaylistRating(UserToken, id, Request);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task InvalidRequest_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddLibraryPlaylistRating(UserToken, Id, null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.AddLibraryPlaylistRating(UserToken, Id, Request);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.AddLibraryPlaylistRating(UserToken, Id, Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/library-playlists/{Id}"));
            }
        }

        public class AddLibrarySongRating : MeClientTests
        {
            public RatingRequest Request { get; set; }

            public AddLibrarySongRating()
            {
                Request = Fixture.Create<RatingRequest>();
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
                Task Task() => Client.AddLibrarySongRating(userToken, Id, Request);

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
                Task Task() => Client.AddLibrarySongRating(UserToken, id, Request);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task InvalidRequest_ThrowsArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.AddLibrarySongRating(UserToken, Id, null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.AddLibrarySongRating(UserToken, Id, Request);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.AddLibrarySongRating(UserToken, Id, Request);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/library-songs/{Id}"));
            }
        }

        public class DeleteAlbumRating : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.DeleteAlbumRating(userToken, Id);

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
                Task Task() => Client.DeleteAlbumRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.DeleteAlbumRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.DeleteAlbumRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/albums/{Id}"));
            }
        }

        public class DeleteMusicVideoRating : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.DeleteMusicVideoRating(userToken, Id);

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
                Task Task() => Client.DeleteMusicVideoRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.DeleteMusicVideoRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.DeleteMusicVideoRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/music-videos/{Id}"));
            }
        }

        public class DeletePlaylistRating : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.DeletePlaylistRating(userToken, Id);

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
                Task Task() => Client.DeletePlaylistRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.DeletePlaylistRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.DeletePlaylistRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/playlists/{Id}"));
            }
        }

        public class DeleteSongRating : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.DeleteSongRating(userToken, Id);

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
                Task Task() => Client.DeleteSongRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.DeleteSongRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.DeleteSongRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/songs/{Id}"));
            }
        }

        public class DeleteStationRating : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.DeleteStationRating(userToken, Id);

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
                Task Task() => Client.DeleteStationRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.DeleteStationRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.DeleteStationRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/stations/{Id}"));
            }
        }

        public class DeleteLibraryMusicVideoRating : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.DeleteLibraryMusicVideoRating(userToken, Id);

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
                Task Task() => Client.DeleteLibraryMusicVideoRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.DeleteLibraryMusicVideoRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.DeleteLibraryMusicVideoRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/library-music-videos/{Id}"));
            }
        }

        public class DeleteLibraryPlaylistRating : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.DeleteLibraryPlaylistRating(userToken, Id);

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
                Task Task() => Client.DeleteLibraryPlaylistRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.DeleteLibraryPlaylistRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.DeleteLibraryPlaylistRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/library-playlists/{Id}"));
            }
        }

        public class DeleteLibrarySongRating : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.DeleteLibrarySongRating(userToken, Id);

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
                Task Task() => Client.DeleteLibrarySongRating(UserToken, id);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.DeleteLibrarySongRating(UserToken, Id);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.DeleteLibrarySongRating(UserToken, Id);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/me/ratings/library-songs/{Id}"));
            }
        }

        public class GetHeavyRotationContent : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetHeavyRotationContent(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetHeavyRotationContent(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
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
                await Client.GetHeavyRotationContent(UserToken, pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetHeavyRotationContent(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/history/heavy-rotation"));
            }
        }

        public class GetRecentlyPlayedResources : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetRecentlyPlayedResources(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetRecentlyPlayedResources(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
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
                await Client.GetRecentlyPlayedResources(UserToken, pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetRecentlyPlayedResources(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/recent/played"));
            }
        }

        public class GetRecentlyPlayedStations : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetRecentlyPlayedStations(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetRecentlyPlayedStations(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
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
                await Client.GetRecentlyPlayedStations(UserToken, pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetRecentlyPlayedStations(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/recent/radio-stations"));
            }
        }

        public class GetRecentlyAddedResources : MeClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidUserToken_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetRecentlyAddedResources(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidUserToken_IsAddedToRequestHeaders()
            {
                // Arrange

                // Act
                await Client.GetRecentlyAddedResources(UserToken);

                // Assert
                Assert.Contains(HttpClient.DefaultRequestHeaders, x => x.Key == "Music-User-Token" && x.Value.First() == UserToken);
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
                await Client.GetRecentlyAddedResources(UserToken, pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetRecentlyAddedResources(UserToken);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals("/v1/me/library/recently-added"));
            }
        }

        public class GetLibraryAlbum : MeClientTests
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

        public class GetLibraryArtist : MeClientTests
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

        public class GetLibraryMusicVideo : MeClientTests
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

        public class GetLibraryPlaylist : MeClientTests
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

        public class GetLibrarySong : MeClientTests
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

        public class GetLibraryAlbumRelationship : MeClientTests
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

        public class GetLibraryArtistRelationship : MeClientTests
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

        public class GetLibraryMusicVideoRelationship : MeClientTests
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

        public class GetLibraryPlaylistRelationship : MeClientTests
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

        public class GetLibrarySongRelationship : MeClientTests
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

        public class GetMultipleLibraryAlbums : MeClientTests
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

        public class GetMultipleLibraryArtists : MeClientTests
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

        public class GetMultipleLibraryMusicVideos : MeClientTests
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

        public class GetMultipleLibraryPlaylists : MeClientTests
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

        public class GetMultipleLibrarySongs : MeClientTests
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

        public class GetAllLibraryAlbums : MeClientTests
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

        public class GetAllLibraryArtists : MeClientTests
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

        public class GetAllLibraryMusicVideos : MeClientTests
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

        public class GetAllLibraryPlaylists : MeClientTests
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

        public class GetAllLibrarySongs : MeClientTests
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
    }
}
