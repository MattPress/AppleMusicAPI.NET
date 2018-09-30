using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Utilities;
using AutoFixture;
using Moq;
using Moq.Protected;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests.Clients
{
    [Trait("Category", "Clients")]
    public abstract class ClientsTestBase<TClient> : TestBase
        where TClient : BaseClient
    {
        public static readonly string[] Ids = { "TestId1", "TestId2" };
        public static IEnumerable<object[]> ActivityRelationships => AllEnumsMemberData<ActivityRelationship>();
        public static IEnumerable<object[]> AlbumRelationships => AllEnumsMemberData<AlbumRelationship>();
        public static IEnumerable<object[]> AppleCuratorRelationships => AllEnumsMemberData<AppleCuratorRelationship>();
        public static IEnumerable<object[]> ArtistRelationships => AllEnumsMemberData<ArtistRelationship>();
        public static IEnumerable<object[]> CuratorRelationships => AllEnumsMemberData<CuratorRelationship>();
        public static IEnumerable<object[]> MusicVideoRelationships => AllEnumsMemberData<MusicVideoRelationship>();
        public static IEnumerable<object[]> PlaylistRelationships => AllEnumsMemberData<PlaylistRelationship>();
        public static IEnumerable<object[]> SongRelationships => AllEnumsMemberData<SongRelationship>();
        public static IEnumerable<object[]> LibraryAlbumRelationships => AllEnumsMemberData<LibraryAlbumRelationship>();
        public static IEnumerable<object[]> LibraryArtistRelationships => AllEnumsMemberData<LibraryArtistRelationship>();
        public static IEnumerable<object[]> LibraryMusicVideoRelationships => AllEnumsMemberData<LibraryMusicVideoRelationship>();
        public static IEnumerable<object[]> LibraryPlaylistRelationships => AllEnumsMemberData<LibraryPlaylistRelationship>();
        public static IEnumerable<object[]> LibrarySongRelationships => AllEnumsMemberData<LibrarySongRelationship>();

        protected const string JwtToken = "TestJwtToken";
        protected const string UserToken = "TestUserToken";
        protected const string Id = "TestId";
        protected const string Storefront = "TestStorefront";
        protected const string Locale = "TestLocale";
        protected const string RequestJson = "{ \"TestKey\": \"TestValue\" }";
        protected const string Chart = "TestChart";
        protected const string Genre = "TestGenre";
        protected const string Isrc = "TestIsrc";

        protected Mock<HttpClientHandler> MockHttpClientHandler { get; private set; }
        protected Mock<IJsonSerializer> MockJsonSerializer { get; private set; }
        protected Mock<IJwtProvider> MockJwtProvider { get; private set; }
        protected HttpClient HttpClient { get; private set; }
        protected TClient Client { get; set; }

        protected ClientsTestBase()
        {
            MockHttpClientHandler = Fixture.Freeze<Mock<HttpClientHandler>>();
            MockJsonSerializer = Fixture.Freeze<Mock<IJsonSerializer>>();
            MockJwtProvider = Fixture.Freeze<Mock<IJwtProvider>>();
            HttpClient = new HttpClient(MockHttpClientHandler.Object);
            Fixture.Inject(HttpClient);

            Client = Fixture.Create<TClient>();

            SetupJwtProviderCreateJwt();
            SetupJsonSerializerSerialize();
            // TODO - MJP - This is pretty lazy and wont help test run performance. Remove and call generic overload for each sut class.
            SetupJsonSerializerDeserializeAllResponseTypes();
            SetupHttpClientHandlerSendAsync();
        }

        protected void SetupJwtProviderCreateJwt(string jwtToken = JwtToken)
        {
            MockJwtProvider
                .Setup(x => x.CreateJwt())
                .Returns(jwtToken);
        }

        protected void SetupJsonSerializerSerialize(string result = RequestJson)
        {
            MockJsonSerializer
                .Setup(x => x.Serialize(It.IsAny<object>()))
                .Returns(result);
        }

        protected void SetupJsonSerializerDeserialize<T>(string response = null, T result = null)
            where T : class, new()
        {
            if (response == null)
                response = It.IsAny<string>();

            if (result == null)
                result = new T();

            MockJsonSerializer
                .Setup(x => x.Deserialize<T>(response))
                .Returns(result);
        }

        protected void SetupHttpClientHandlerSendAsync(HttpStatusCode statusCode = HttpStatusCode.OK, string response = "{}")
        {
            var responseMessage = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(response)
            };

            SetupHttpClientHandlerSendAsync(responseMessage, ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        protected void SetupHttpClientHandlerSendAsync(HttpResponseMessage response, params object[] arguments)
        {
            MockHttpClientHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", arguments)
                .ReturnsAsync(response);
        }

        protected void VerifyHttpClientHandlerSendAsync(Times times)
        {
            VerifyHttpClientHandlerSendAsync(times, ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        protected void VerifyHttpClientHandlerSendAsync(Times times, Uri requestUri)
        {
            VerifyHttpClientHandlerSendAsync(times, x => x.RequestUri == requestUri);
        }

        protected void VerifyHttpClientHandlerSendAsync(Times times, Expression<Func<HttpRequestMessage, bool>> itExpr)
        {
            VerifyHttpClientHandlerSendAsync(times, ItExpr.Is(itExpr), ItExpr.IsAny<CancellationToken>());
        }

        protected void VerifyHttpClientHandlerSendAsync(Times times, params object[] args)
        {
            MockHttpClientHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", times, args);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                MockHttpClientHandler = null;
                MockJsonSerializer = null;
                MockJwtProvider = null;
                HttpClient?.Dispose();
                HttpClient = null;
                Client = null;
            }

            base.Dispose(disposing);
        }

        private void SetupJsonSerializerDeserializeAllResponseTypes()
        {
            var resultTypes = typeof(ResponseRoot).Assembly
                .GetTypes()
                .Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && t.IsAssignableFrom(typeof(ResponseRoot)));

            var setupJsonSerializerDeserialize = GetType().GetMethod(nameof(SetupJsonSerializerDeserialize), BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var type in resultTypes)
            {
                var method = setupJsonSerializerDeserialize.MakeGenericMethod(type);
                method.Invoke(this, new[] { Type.Missing, Type.Missing });
            }
        }
    }
}
