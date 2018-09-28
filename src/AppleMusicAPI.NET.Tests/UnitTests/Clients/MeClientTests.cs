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
                var pageOptions = new Pag
eOptions
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
    }
}
