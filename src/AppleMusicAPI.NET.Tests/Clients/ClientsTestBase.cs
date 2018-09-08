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

namespace AppleMusicAPI.NET.Tests.Clients
{
    public abstract class ClientsTestBase<TClient> : TestBase
        where TClient : BaseClient
    {
        protected const string JwtToken = "JwtToken";
        protected const string RequestJson = "{}";

        protected Mock<HttpClientHandler> MockHttpClientHandler { get; private set; }
        protected Mock<IJsonSerializer> MockJsonSerializer { get; private set; }
        protected Mock<IJwtProvider> MockJwtProvider { get; private set; }
        protected HttpClient HttpClient { get; private set; }
        protected TClient Client { get; set; }

        protected ClientsTestBase()
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

        protected void SetupJwtProviderCreateJwt(string jwtToken = JwtToken)
        {
            MockJwtProvider
                .Setup(x => x.CreateJwt())
                .Returns(jwtToken);
        }

        protected void SetupJsonSerializerSerialize(object request = null, string result = RequestJson)
        {
            if (request == null)
                request = It.IsAny<object>();

            MockJsonSerializer
                .Setup(x => x.Serialize(request))
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
