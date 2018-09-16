using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using Moq;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    [Trait("Category", "ChartsClient")]
    public class ChartsClientTests : ClientsTestBase<ChartsClient>
    {
        public class GetCatalogCharts : ChartsClientTests
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

            [Fact]
            public async Task WithValidStorefrontArgument_ShouldCallGet()
            {
                // Arrange

                // Act
                await Client.GetCatalogCharts(Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once());
            }

            [Fact]
            public async Task WithValidStorefrontArgument_ShouldIncludeStorefrontInRequestUri()
            {
                // Arrange

                // Act
                await Client.GetCatalogCharts(Storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(Storefront) && string.IsNullOrWhiteSpace(x.RequestUri.Query));
            }

            [Theory]
            [InlineData(CatalogChartType.Albums)]
            [InlineData(CatalogChartType.MusicVideos)]
            [InlineData(CatalogChartType.Songs)]
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
                var types = new List<CatalogChartType>
                {
                    CatalogChartType.Albums,
                    CatalogChartType.MusicVideos,
                    CatalogChartType.Songs
                };

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

            [Fact]
            public async Task WithAllArguments_ShouldAllBeIncludedInRequestUri()
            {
                // Arrange
                var types = new List<CatalogChartType>
                {
                    CatalogChartType.Albums,
                    CatalogChartType.MusicVideos,
                    CatalogChartType.Songs
                };
                var pageOptions = new PageOptions
                {
                    Limit = 10,
                    Offset = 50
                };

                // Act
                await Client.GetCatalogCharts(Storefront, types, Chart, Genre, pageOptions);

                // Assert
                var expectedRequestUri = $"/v1/catalog/{Storefront}/charts?types=albums,music-videos,songs&chart={Chart}&genre={Genre}&limit={pageOptions.Limit}&offset={pageOptions.Offset}";
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.PathAndQuery.Equals(expectedRequestUri));
            }
        }
    }
}
