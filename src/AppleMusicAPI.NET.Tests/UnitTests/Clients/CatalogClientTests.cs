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
    [Trait("Category", "CatalogClientTests")]
    public class CatalogClientTests : ClientsTestBase<CatalogClient>
    {
        public static IEnumerable<object[]> CatalogChartTypes => AllEnumsMemberData<CatalogChartType>();
        public static IEnumerable<object[]> ResourceTypes => AllEnumsMemberData<ResourceType>();

        public class GetCatalogCharts : CatalogClientTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public async Task InvalidStorefront_ThrowsArgumentNullException(string userToken)
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogCharts(userToken);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Theory]
            [MemberData(nameof(CatalogChartTypes))]
            public async Task CatalogChartType_IsAddedToQuery(CatalogChartType type)
            {
                // Arrange
                var types = new List<CatalogChartType> { type };

                // Act
                await Client.GetCatalogCharts(Storefront, types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={type.GetValue()}"));
            }

            [Fact]
            public async Task WithMultipleTypes_ShouldIncludeTypeCSVInQuery()
            {
                // Arrange
                var types = AllEnumsOfType<CatalogChartType>()
                    .ToList();

                // Act
                await Client.GetCatalogCharts(Storefront, types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?types=albums,music-videos,songs"));
            }

            [Fact]
            public async Task WithChartArgument_ShouldIncludeChartInQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogCharts(Storefront, chart: Chart);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?chart={Chart}"));
            }

            [Fact]
            public async Task WithGenreArgument_ShouldIncludeGenreInQuery()
            {
                // Arrange

                // Act
                await Client.GetCatalogCharts(Storefront, genre: Genre);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?genre={Genre}"));
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
                await Client.GetCatalogCharts(Storefront, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }

            [Fact]
            public async Task WithValidParameters_AbsolutePathIsCorrect()
            {
                // Arrange

                // Act
                await Client.GetCatalogCharts(Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Equals($"/v1/catalog/{Storefront}/charts"));
            }
        }

        public class CatalogResourcesSearch : CatalogClientTests
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
                await Client.CatalogResourcesSearch(Storefront, types: new[] { type });

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

        public class GetCatalogSearchHints : CatalogClientTests
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

        public class GetCatalogTopChartsGenres : CatalogClientTests
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

        public class GetCatalogAlbum : CatalogClientTests
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

        public class GetCatalogMusicVideo : CatalogClientTests
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

        public class GetCatalogPlaylist : CatalogClientTests
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

        public class GetCatalogSong : CatalogClientTests
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

        public class GetCatalogStation : CatalogClientTests
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

        public class GetCatalogArtist : CatalogClientTests
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

        public class GetCatalogCurator : CatalogClientTests
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

        public class GetCatalogActivity : CatalogClientTests
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

        public class GetCatalogAppleCurator : CatalogClientTests
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

        public class GetCatalogGenre : CatalogClientTests
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

        public class GetCatalogAlbumRelationship : CatalogClientTests
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

        public class GetCatalogMusicVideoRelationship : CatalogClientTests
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

        public class GetCatalogPlaylistRelationship : CatalogClientTests
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

        public class GetCatalogSongRelationship : CatalogClientTests
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

        public class GetCatalogArtistRelationship : CatalogClientTests
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

        public class GetCatalogCuratorRelationship : CatalogClientTests
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

        public class GetCatalogActivityRelationship : CatalogClientTests
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

        public class GetCatalogAppleCuratorRelationship : CatalogClientTests
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

        public class GetMultipleCatalogAlbums : CatalogClientTests
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

        public class GetMultipleCatalogMusicVideos : CatalogClientTests
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

        public class GetMultipleCatalogPlaylists : CatalogClientTests
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

        public class GetMultipleCatalogSongs : CatalogClientTests
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

        public class GetMultipleCatalogStations : CatalogClientTests
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

        public class GetMultipleCatalogArtists : CatalogClientTests
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

        public class GetMultipleCatalogCurators : CatalogClientTests
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

        public class GetMultipleCatalogActivities : CatalogClientTests
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

        public class GetMultipleCatalogAppleCurators : CatalogClientTests
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

        public class GetMultipleCatalogGenres : CatalogClientTests
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

        public class GetMultipleCatalogMusicVideosByIsrc : CatalogClientTests
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

        public class GetMultipleCatalogSongsByIsrc : CatalogClientTests
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
    }
}
