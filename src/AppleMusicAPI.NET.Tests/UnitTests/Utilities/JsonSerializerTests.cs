using System.Text;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;
using AutoFixture;
using Newtonsoft.Json.Linq;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Utilities
{
    public class JsonSerializerTests : UtilitiesTestBase
    {
        public JsonSerializer JsonSerializer { get; set; }

        public JsonSerializerTests()
        {
            JsonSerializer = new JsonSerializer();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                JsonSerializer = null;
            }
            base.Dispose(disposing);
        }

        public class Serialize : JsonSerializerTests
        {
            [Fact]
            public void SerializeRatingRequest_Success()
            {
                // Arrange
                var request = Fixture.Create<RatingRequest>();

                // Act
                var json = JsonSerializer.Serialize(request);

                // Assert
                var expectedJson = BuildRatingRequestJson(request);
                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void SerializeLibraryPlaylistCreationRequest_Success()
            {
                // Arrange
                var request = Fixture.Create<LibraryPlaylistCreationRequest>();

                // Act
                var json = JsonSerializer.Serialize(request);

                // Assert
                var expectedJson = BuildLibraryPlaylistCreationRequestJson(request);
                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void SerializeLibraryPlaylistTracksRequest_Success()
            {
                // Arrange
                var request = Fixture.Create<LibraryPlaylistTracksRequest>();

                // Act
                var json = JsonSerializer.Serialize(request);

                // Assert
                var expectedJson = BuildLibraryPlaylistTracksRequestJson(request);
                Assert.Equal(expectedJson, json);
            }

            private static string BuildRatingRequestJson(RatingRequest request)
            {
                return $"{{\"attributes\":{{\"value\":{request?.Attributes?.Value}}},\"type\":\"{request?.Type}\"}}";
            }

            private static string BuildLibraryPlaylistCreationRequestJson(LibraryPlaylistCreationRequest request)
            {
                var builder = new StringBuilder($"{{\"attributes\":{{\"description\":\"{request.Attributes.Description}\",\"name\":\"{request.Attributes.Name}\"}},\"relationships\":{{\"tracks\":[");

                for (var i = 0; i < request.Relationships.Tracks.Count; i++)
                {
                    builder.Append($"{{\"id\":\"{request.Relationships.Tracks[i].Id}\",\"type\":\"{request.Relationships.Tracks[i].Type}\"}}");

                    if (i != request.Relationships.Tracks.Count - 1)
                        builder.Append(",");
                }

                builder.Append("]}}");

                return builder.ToString();
            }

            private static string BuildLibraryPlaylistTracksRequestJson(LibraryPlaylistTracksRequest request)
            {
                var builder = new StringBuilder("{\"data\":[");

                for (var i = 0; i < request.Data.Count; i++)
                {
                    builder.Append($"{{\"id\":\"{request.Data[i].Id}\",\"type\":\"{request.Data[i].Type}\"}}");

                    if (i != request.Data.Count - 1)
                        builder.Append(",");
                }

                builder.Append("]}");

                return builder.ToString();
            }
        }

        public class Deserialize : JsonSerializerTests
        {
            [Fact]
            public void DeserializeActivityResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<ActivityResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeAlbumResponse_Success()
            {
                // Arrange
                var json = @"{
                    ""data"": [
                        {
                            ""attributes"": {
                                ""artistName"": ""Bruce Springsteen"",
                                ""artwork"": {
                                    ""bgColor"": ""ffffff"",
                                    ""height"": 1500,
                                    ""textColor1"": ""0c0b09"",
                                    ""textColor2"": ""2a2724"",
                                    ""textColor3"": ""3d3c3a"",
                                    ""textColor4"": ""555250"",
                                    ""url"": ""https://example.mzstatic.com/image/thumb/Music3/v4/2d/02/4a/2d024aaa-4547-ca71-7ba1-b8f5e1d98256/source/{w}x{h}bb.jpeg"",
                                    ""width"": 1500
                                },
                                ""copyright"": ""\u2117 1975 Bruce Springsteen"",
                                ""editorialNotes"": {
                                    ""short"": ""Springsteen's third album was the one that broke it all open for him."",
                                    ""standard"": ""Springsteen's third album was the one that broke it all open for him, planting his tales of Jersey girls, cars, and nights spent sleeping on the beach firmly in the Top Five. He shot for an unholy hybrid of Orbison, Dylan and Spector \u2014 and actually reached it. \""Come take my hand,\"" he invited in the opening lines. \""We're ridin' out tonight to case the Promised Land.\"" Soon after this album, he'd discover the limits of such dreams, but here, it's a wide-open road: Even the tales of petty crime (\""Meeting Across the River\"") and teen-gang violence (\""Jungleland\"") are invested with all the wit and charm you can handle. Bruce's catalog is filled with one-of-a-kind albums from <i>The Wild, The Innocent and the E Street Shuffle</i> to <i>The Ghost of Tom Joad</i>. Forty years on, <i>Born to Run</i> still sits near the very top of that stack.""
                                },
                                ""genreNames"": [
                                    ""Rock"",
                                    ""Music"",
                                    ""Arena Rock"",
                                    ""Rock & Roll"",
                                    ""Pop"",
                                    ""Pop/Rock""
                                ],
                                ""isComplete"": true,
                                ""isMasteredForItunes"": true,
                                ""isSingle"": false,
                                ""name"": ""Born to Run"",
                                ""playParams"": {
                                    ""id"": ""310730204"",
                                    ""kind"": ""album""
                                },
                                ""recordLabel"": ""Columbia"",
                                ""releaseDate"": ""1975 -08-25"",
                                ""trackCount"": 8,
                                ""url"": ""https://itunes.apple.com/us/album/born-to-run/310730204""
                            },
                            ""href"": "" / v1/catalog/us/albums/310730204"",
                            ""id"": ""310730204"",
                            ""relationships"": {
                            },
                            ""type"": ""albums""
                        }
                    ]
                }";

                // Act
                var response = JsonSerializer.Deserialize<AlbumResponse>(json);

                // Assert
                var parsedJson = JToken.Parse(json);
                Assert.NotNull(response);
            }

            [Fact]
            public void DeserializeAppleCuratorResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<AppleCuratorResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeArtistResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<ArtistResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeChartResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<ChartResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeCuratorResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<CuratorResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeGenreResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<GenreResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeHistoryResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<HistoryResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeLibraryAlbumResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<LibraryAlbumResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeLibraryArtistResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<LibraryArtistResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeLibraryMusicVideoResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<LibraryMusicVideoResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeLibraryPlaylistResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<LibraryPlaylistResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeLibrarySearchResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<LibrarySearchResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeLibrarySongResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<LibrarySongResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeMusicVideoResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<MusicVideoResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializePlaylistResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<PlaylistResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeRatingResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<RatingResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeRecentlyAddedResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<RecentlyAddedResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeRecommendationResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<RecommendationResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeSearchHintsResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<SearchHintsResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeSearchResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<SearchResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeSongResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<SongResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeStationResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<StationResponse>(json);

                // Assert
                //Assert.Equal();
            }

            [Fact]
            public void DeserializeStorefrontResponse_Success()
            {
                // Arrange
                var json = "";

                // Act
                var response = JsonSerializer.Deserialize<StorefrontResponse>(json);

                // Assert
                //Assert.Equal();
            }
        }
    }
}
