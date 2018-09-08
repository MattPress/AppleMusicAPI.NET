using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Models.Enums;
using Moq;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
#pragma warning disable IDE1006 // Naming Styles
    public class iCloudMusicLibraryClientTests : ClientsTestBase<iCloudMusicLibraryClient>
#pragma warning restore IDE1006 // Naming Styles
    {
        public iCloudMusicLibraryClientTests()
        {
            Client = new iCloudMusicLibraryClient(
                HttpClient,
                MockJsonSerializer.Object,
                MockJwtProvider.Object);
        }

        public class AddResourceToLibrary : iCloudMusicLibraryClientTests
        {
            private readonly Dictionary<iCloudMusicLibraryType, List<string>> _ids = new Dictionary<iCloudMusicLibraryType, List<string>>
            {
                { iCloudMusicLibraryType.Albums, new List<string> { "Album1", "Album2" }
                },
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
            public async Task EmptyValuesInValidTypeIdsCollection_AreNotAddedToQuery()
            {
                // Arrange
                var ids = new Dictionary<iCloudMusicLibraryType, List<string>>
                {
                    { iCloudMusicLibraryType.Albums, new List<string>{ "album1", string.Empty } }
                };

                // Act
                await Client.AddResourceToLibrary(UserToken, ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?ids%5Balbums%5D=album1"));
            }

            [Fact]
            public async Task MultipleIdsInValidTypeIdsCollection_AreAddedAsCsvToQuery()
            {
                // Arrange
                var ids = new Dictionary<iCloudMusicLibraryType, List<string>>
                {
                    { iCloudMusicLibraryType.Albums, new List<string>{ "album1", "album2" } }
                };

                // Act
                await Client.AddResourceToLibrary(UserToken, ids);

                // Assert
                VerifyHttpClientHandlerSendAsync(Times.Once(), x => x.RequestUri.Query.Equals("?ids%5Balbums%5D=album1,album2"));
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
    }
}
