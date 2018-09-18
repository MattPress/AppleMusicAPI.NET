using System;
using System.Collections.Generic;
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
    [Trait("Category", "SearchClient")]
    public class SearchClientTests : ClientsTestBase<SearchClient>
    {
        public static IEnumerable<object[]> ResourceTypes => AllEnumsMemberData<ResourceType>();
        public static IEnumerable<object[]> LibraryResources => AllEnumsMemberData<LibraryResource>();

        public class CatalogResourcesSearch : SearchClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.CatalogResourcesSearch(storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidTerm_IsAddedToQuery()
            {
                // Arrange
                const string term = "TestTerm";

                // Act
                await Client.CatalogResourcesSearch(Storefront, term);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?term={term}"));
            }

            [Fact]
            public async Task ValidTermWithSpaces_IsJoinedByPluses()
            {
                // Arrange
                const string term = "Test Term";

                // Act
                await Client.CatalogResourcesSearch(Storefront, term);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?term=Test{UrlEncoder.Default.Encode("+")}Term"));
            }

            [Theory]
            [MemberData(nameof(ResourceTypes))]
            public async Task ValidType_IsAddedToQuery(ResourceType type)
            {
                // Arrange

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: new []{type});

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidActivitiesType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Activities
                }; 

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=activities"));
            }

            [Fact]
            public async Task ValidArtistsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Artists
                };

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=artists"));
            }

            [Fact]
            public async Task ValidAlbumType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Albums
                };

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=albums"));
            }

            [Fact]
            public async Task ValidAppleCuratorType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.AppleCurators
                };

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=apple-curators"));
            }

            [Fact]
            public async Task ValidCuratorType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Curators
                };

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=curators"));
            }

            [Fact]
            public async Task ValidGenresType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Genres
                };

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=genres"));
            }

            [Fact]
            public async Task ValidPlaylistsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Playlists
                };

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=playlists"));
            }

            [Fact]
            public async Task ValidSongsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Songs
                };

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=songs"));
            }

            [Fact]
            public async Task ValidStationsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Stations
                };

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=stations"));
            }

            [Fact]
            public async Task ValidMusicVideoType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.MusicVideos
                };

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=music-videos"));
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
                await Client.CatalogResourcesSearch(Storefront, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.CatalogResourcesSearch(Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/search"));
            }
        }

        public class LibraryResourcesSearch : SearchClientTests
        {
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

        public class GetCatalogSearchHints : SearchClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string storefront)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogSearchHints(storefront);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task ValidTerm_IsAddedToQuery()
            {
                // Arrange
                const string term = "TestTerm";

                // Act
                await Client.GetCatalogSearchHints(Storefront, term);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?term={term}"));
            }

            [Fact]
            public async Task ValidTermWithSpaces_IsJoinedByPluses()
            {
                // Arrange
                const string term = "Test Term";

                // Act
                await Client.GetCatalogSearchHints(Storefront, term);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?term=Test%2BTerm"));
            }

            [Theory]
            [MemberData(nameof(ResourceTypes))]
            public async Task ValidType_IsAddedToQuery(ResourceType type)
            {
                // Arrange

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={type.GetValue()}"));
            }

            [Fact]
            public async Task ValidActivitiesType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Activities
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=activities"));
            }

            [Fact]
            public async Task ValidArtistsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Artists
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=artists"));
            }

            [Fact]
            public async Task ValidAlbumType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Albums
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=albums"));
            }

            [Fact]
            public async Task ValidAppleCuratorType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.AppleCurators
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=apple-curators"));
            }

            [Fact]
            public async Task ValidCuratorType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Curators
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=curators"));
            }

            [Fact]
            public async Task ValidGenresType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Genres
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=genres"));
            }

            [Fact]
            public async Task ValidPlaylistsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Playlists
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=playlists"));
            }

            [Fact]
            public async Task ValidSongsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Songs
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=songs"));
            }

            [Fact]
            public async Task ValidStationsType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.Stations
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=stations"));
            }

            [Fact]
            public async Task ValidMusicVideoType_IsAddedToQuery()
            {
                // Arrange
                var types = new List<ResourceType>
                {
                    ResourceType.MusicVideos
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=music-videos"));
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
                await Client.GetCatalogSearchHints(Storefront, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogSearchHints(Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/search/hints"));
            }
        }
    }
}
