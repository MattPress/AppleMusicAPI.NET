using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using Moq;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
    public class ChartsClientTests : ClientsTestBase<ChartsClient>
    {
        public ChartsClientTests()
        {
            Client = new ChartsClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }

        public class GetCatalogCharts : ChartsClientTests
        {
            [Fact]
            public async Task WithNullStorefrontArgument_ShouldThrowArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Client.GetCatalogCharts(null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task WithValidStorefrontArgument_ShouldCallGetAsync()
            {
                // Arrange
                const string storefront = "storefront";

                // Act
                await Client.GetCatalogCharts(storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once());
            }

            [Fact]
            public async Task WithValidStorefrontArgument_ShouldIncludeStorefrontInRequestUriAsync()
            {
                // Arrange
                const string storefront = "storefront";

                // Act
                await Client.GetCatalogCharts(storefront);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.AbsolutePath.Contains(storefront) && string.IsNullOrWhiteSpace(x.RequestUri.Query));
            }

            [Theory]
            [InlineData(CatalogChartType.Albums)]
            [InlineData(CatalogChartType.MusicVideos)]
            [InlineData(CatalogChartType.Songs)]
            public async Task CatalogChartType_IsAddedToQuery(CatalogChartType type)
            {
                // Arrange
                const string storefront = "storefront";
                var types = new List<CatalogChartType> { type };

                // Act
                await Client.GetCatalogCharts(storefront, types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={type.GetValue()}"));
            }

            [Fact]
            public async Task WithChartArgument_ShouldIncludeChartInQueryAsync()
            {
                // Arrange
                const string storefront = "storefront";
                const string chart = "TestChart";

                // Act
                await Client.GetCatalogCharts(storefront, chart: chart);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?chart={chart}"));
            }

            [Fact]
            public async Task WithGenreArgument_ShouldIncludeGenreInQueryAsync()
            {
                // Arrange
                const string storefront = "storefront";
                const string genre = "TestGenre";

                // Act
                await Client.GetCatalogCharts(storefront, genre: genre);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?genre={genre}"));
            }

            [Fact]
            public async Task WithPageOptionsArgument_ShouldIncludePageOptionsInQueryAsync()
            {
                // Arrange
                const string storefront = "storefront";
                var pageOptions = new PageOptions
                {
                    Limit = 10,
                    Offset = 50
                };

                // Act
                await Client.GetCatalogCharts(storefront, pageOptions: pageOptions);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?limit={pageOptions.Limit}&offset={pageOptions.Offset}"));
            }
        }
    }
}
