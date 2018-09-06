using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Utilities;
using Moq;
using Moq.Protected;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
    public abstract class BaseClientFixture<TClient> : IDisposable
        where TClient : BaseClient
    {
        protected const string JwtToken = "JwtToken";
        protected const string RequestJson = "{}";

        public Mock<HttpClientHandler> MockHttpClientHandler { get; private set; }
        public Mock<IJsonSerializer> MockJsonSerializer { get; private set; }
        public Mock<IJwtProvider> MockJwtProvider { get; private set; }
        public HttpClient HttpClient { get; private set; }
        public TClient Client { get; protected set; }

        protected BaseClientFixture()
        {
            MockHttpClientHandler = new Mock<HttpClientHandler>();
            MockJsonSerializer = new Mock<IJsonSerializer>();
            MockJwtProvider = new Mock<IJwtProvider>();
            HttpClient = new HttpClient(MockHttpClientHandler.Object);

            SetupJwtProviderCreateJwt();
            SetupJsonSerializerSerialize();
            SetupJsonSerializerDeserializeAllResponseTypes();
            SetupHttpClientHandlerSendAsync();
        }

        private void SetupJwtProviderCreateJwt()
        {
            MockJwtProvider
                .Setup(x => x.CreateJwt())
                .Returns(JwtToken);
        }

        private void SetupJsonSerializerSerialize(object request = null, string result = RequestJson)
        {
            if (request == null)
                request = It.IsAny<object>();

            MockJsonSerializer
                .Setup(x => x.Serialize(request))
                .Returns(result);
        }

        private void SetupJsonSerializerDeserializeAllResponseTypes()
        {
            var resultTypes = typeof(ResponseRoot).Assembly
                .GetTypes()
                .Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && t.IsAssignableFrom(typeof(ResponseRoot)));

            var setupJsonSerializerDeserialize = GetType().GetMethod(nameof(SetupJsonSerializerDeserialize), BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance);
            foreach (var type in resultTypes)
            {
                var method = setupJsonSerializerDeserialize.MakeGenericMethod(type);
                method.Invoke(this, new [] { Type.Missing, Type.Missing });
            }
        }
   
        public void SetupJsonSerializerDeserialize<T>(string response = null, T result = null)
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

        public void SetupHttpClientHandlerSendAsync(HttpStatusCode statusCode = HttpStatusCode.OK, string response = "{}")
        {
            var responseMessage = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(response)
            };

            SetupHttpClientHandlerSendAsync(responseMessage, ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        public void SetupHttpClientHandlerSendAsync(HttpResponseMessage response, params object[] arguments)
        {
            MockHttpClientHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", arguments)
                .ReturnsAsync(response);
        }

        public void VerifyHttpClientHandlerSendAsync(Times times)
        {
            VerifyHttpClientHandlerSendAsync(times, ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        public void VerifyHttpClientHandlerSendAsync(Times times, Uri requestUri)
        {
            VerifyHttpClientHandlerSendAsync(times, x => x.RequestUri == requestUri);
        }

        public void VerifyHttpClientHandlerSendAsync(Times times, Expression<Func<HttpRequestMessage, bool>> itExpr)
        {
            VerifyHttpClientHandlerSendAsync(times, ItExpr.Is(itExpr), ItExpr.IsAny<CancellationToken>());
        }

        public void VerifyHttpClientHandlerSendAsync(Times times, params object[] args)
        {
            MockHttpClientHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", times, args);
        }

        protected virtual void Dispose(bool disposing)
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
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
