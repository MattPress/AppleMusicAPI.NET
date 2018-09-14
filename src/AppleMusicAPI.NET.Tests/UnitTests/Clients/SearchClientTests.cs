using System;
using System.Collections.Generic;
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
    public class SearchClientTests : ClientsTestBase<SearchClient>
    {
        public SearchClientTests()
        {
            Client = new SearchClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }

        public class CatalogResourcesSearch : SearchClientTests
        {
            public static IEnumerable<object[]> CatalogResources =>
                new List<object[]>(
                    Enum.GetValues(typeof(CatalogResource))
                        .Cast<CatalogResource>()
                        .Select(x => new object[] { x })
                        .AsEnumerable()
                );

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
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?term=Test%2BTerm"));
            }

            [Theory]
            [MemberData(nameof(CatalogResources))]
            public async Task ValidType_IsAddedToQuery(CatalogResource type)
            {
                // Arrange

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: new []{type});

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={type.GetValue()}"));
            }

            [Fact]
            public async Task MultipleValidTypes_AreAddedToQuery()
            {
                // Arrange
                var types = new List<CatalogResource>
                {
                    CatalogResource.Activities,
                    CatalogResource.Albums
                }; 

                // Act
                await Client.CatalogResourcesSearch(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={CatalogResource.Activities.GetValue()},{CatalogResource.Albums.GetValue()}"));
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
            public static IEnumerable<object[]> Libraries =>
                new List<object[]>(
                    Enum.GetValues(typeof(Library))
                        .Cast<Library>()
                        .Select(x => new object[] { x })
                        .AsEnumerable()
                );

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
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?term=Test%2BTerm"));
            }

            [Theory]
            [MemberData(nameof(Libraries))]
            public async Task ValidType_IsAddedToQuery(Library type)
            {
                // Arrange

                // Act
                await Client.LibraryResourcesSearch(UserToken, types: new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={type.GetValue()}"));
            }

            [Fact]
            public async Task MultipleValidTypes_AreAddedToQuery()
            {
                // Arrange
                var types = new List<Library>
                {
                    Library.Albums,
                    Library.Artists
                };

                // Act
                await Client.LibraryResourcesSearch(UserToken, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={Library.Albums.GetValue()},{Library.Artists.GetValue()}"));
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
            public static IEnumerable<object[]> CatalogResources =>
                new List<object[]>(
                    Enum.GetValues(typeof(CatalogResource))
                        .Cast<CatalogResource>()
                        .Select(x => new object[] { x })
                        .AsEnumerable()
                );

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
            [MemberData(nameof(CatalogResources))]
            public async Task ValidType_IsAddedToQuery(CatalogResource type)
            {
                // Arrange

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: new[] { type });

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={type.GetValue()}"));
            }

            [Fact]
            public async Task MultipleValidTypes_AreAddedToQuery()
            {
                // Arrange
                var types = new List<CatalogResource>
                {
                    CatalogResource.Activities,
                    CatalogResource.Albums
                };

                // Act
                await Client.GetCatalogSearchHints(Storefront, types: types);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals($"?types={CatalogResource.Activities.GetValue()},{CatalogResource.Albums.GetValue()}"));
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
