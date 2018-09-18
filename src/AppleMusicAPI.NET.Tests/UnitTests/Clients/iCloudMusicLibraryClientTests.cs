using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Enums;
using Moq;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    [Trait("Category", "iCloudMusicLibraryClient")]
#pragma warning disable IDE1006 // Naming Styles
    public class iCloudMusicLibraryClientTests : ClientsTestBase<iCloudMusicLibraryClient>
#pragma warning restore IDE1006 // Naming Styles
    {
        public static IEnumerable<object[]> AlliCloudMusicLibraryTypeDictMemberData()
        {
            return new List<object[]>(AllEnumsOfType<iCloudMusicLibraryType>()
                    .Select(x => new object[]
                    {
                        new Dictionary<iCloudMusicLibraryType, List<string>>
                        {
                            { x, new List<string> { $"{x.ToString()}Id1", $"{x.ToString()}Id2" } }
                        }
                    })
                    .AsEnumerable());
        }

        public class AddResourceToLibrary : iCloudMusicLibraryClientTests
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
    }
}
