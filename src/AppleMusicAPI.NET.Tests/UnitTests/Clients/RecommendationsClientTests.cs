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
    [Trait("Category", "RecommendationsClient")]
    public class RecommendationsClientTests : ClientsTestBase<RecommendationsClient>
    {
        public class GetRecommendation : RecommendationsClientTests
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

        public class GetMultipleRecommendations : RecommendationsClientTests
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

        public class GetDefaultRecommendations : RecommendationsClientTests
        {
            public static IEnumerable<object[]> RecommendationTypes =>
                new List<object[]>(
                    Enum.GetValues(typeof(RecommendationType))
                        .Cast<RecommendationType>()
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
    }
}
