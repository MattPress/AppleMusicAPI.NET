using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Utilities;
using Microsoft.AspNetCore.WebUtilities;

namespace AppleMusicAPI.NET.Clients
{
    /// <summary>
    /// Base client.
    /// </summary>
    public abstract class BaseClient
    {
        private const string BaseUrl = "https://api.music.apple.com/v1/";
        private const string JsonMediaType = "application/json";
        private const string AuthenticationHeaderSchema = "bearer";
        private const string UserTokenHeaderName = "Music-User-Token";
        private const string LimitQueryStringKey = "limit";
        private const string OffsetQueryStringKey = "offset";
        private const string LocaleQueryStringKey = "l";

        private readonly IJsonSerializer _jsonSerializer;
        private readonly IJwtProvider _jwtProvider;

        protected HttpClient Client { get; }

        protected BaseClient(HttpClient client, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
            _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));

            Client.BaseAddress = new Uri(BaseUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationHeaderSchema, _jwtProvider.CreateJwt());
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));
        }

        protected void SetUserTokenHeader(string userToken)
        {
            Client.DefaultRequestHeaders.Add(UserTokenHeaderName, userToken);
        }

        /// <summary>
        /// Send a GET request to the api.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="queryStringParameters"></param>
        /// <param name="pageOptions"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        protected async Task<TResponse> Get<TResponse>(string requestUri, IDictionary<string, string> queryStringParameters = null, PageOptions pageOptions = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            queryStringParameters = queryStringParameters ?? new Dictionary<string, string>();

            if (pageOptions?.Limit != null)
                queryStringParameters.Add(LimitQueryStringKey, pageOptions.Limit.Value.ToString());

            if (pageOptions?.Offset != null)
                queryStringParameters.Add(OffsetQueryStringKey, pageOptions.Offset.Value.ToString());

            if (locale != null)
                queryStringParameters.Add(LocaleQueryStringKey, locale);

            if (queryStringParameters.Any())
            {
                requestUri = QueryHelpers.AddQueryString(requestUri, queryStringParameters);
            }

            var response = await Client.GetAsync(requestUri)
                .ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            return _jsonSerializer.Deserialize<TResponse>(content);
        }

        /// <summary>
        /// Send a PUT request to the api.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        protected async Task<TResponse> Put<TResponse, TRequest>(string requestUri, TRequest request)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var json = _jsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, JsonMediaType);
            var response = await Client.PutAsync(requestUri, content)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return _jsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Send a POST request with no body to the api.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="queryStringParameters"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        protected async Task<TResponse> Post<TResponse>(string requestUri, IDictionary<string, string> queryStringParameters = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            queryStringParameters = queryStringParameters ?? new Dictionary<string, string>();

            if (locale != null)
                queryStringParameters.Add(LocaleQueryStringKey, locale);

            if (queryStringParameters.Any())
                requestUri = QueryHelpers.AddQueryString(requestUri, queryStringParameters);

            var response = await Client.PostAsync(requestUri, null)
                .ConfigureAwait(false);

            return _jsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Send a POST request to the api.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="request"></param>
        /// <param name="queryStringParameters"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        protected async Task<TResponse> Post<TResponse, TRequest>(string requestUri, TRequest request, IDictionary<string, string> queryStringParameters = null, string locale = null)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            queryStringParameters = queryStringParameters ?? new Dictionary<string, string>();

            if (locale != null)
                queryStringParameters.Add(LocaleQueryStringKey, locale);

            if (queryStringParameters.Any())
                requestUri = QueryHelpers.AddQueryString(requestUri, queryStringParameters);

            var json = _jsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, JsonMediaType);
            var response = await Client.PostAsync(requestUri, content)
                .ConfigureAwait(false);

            return _jsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Send a DELETE request to the api.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        protected async Task<ResponseRoot> Delete(string requestUri)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            var response = await Client.DeleteAsync(requestUri)
                .ConfigureAwait(false);

            return _jsonSerializer.Deserialize<ResponseRoot>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
    }
}
