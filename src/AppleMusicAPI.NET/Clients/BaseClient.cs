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

        private readonly IJsonSerializer _jsonSerializer;
        private readonly IJwtProvider _jwtProvider;

        protected HttpClient Client { get; }

        // TODO - MJP - This was a misunderstanding, needs to be added to all requests as a nullable parameter.
        protected string DefaultQueryStringParameters => $"?l={CultureInfo.CurrentCulture.Name}";

        protected BaseClient(HttpClient client, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
            _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));

            Client.BaseAddress = new Uri(BaseUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _jwtProvider.CreateJwt());
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected void SetUserTokenHeader(string userToken)
        {
            Client.DefaultRequestHeaders.Add("Music-User-Token", userToken);
        }

        /// <summary>
        /// Send a GET request to the api.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="queryStringParameters"></param>
        /// <param name="pageOptions"></param>
        /// <returns></returns>
        protected async Task<TResponse> Get<TResponse>(string requestUri, IDictionary<string, string> queryStringParameters = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            //requestUri = $"{requestUri}{DefaultQueryStringParameters}";

            if (pageOptions != null)
            {
                queryStringParameters = queryStringParameters ?? new Dictionary<string, string>();
                queryStringParameters.Add("limit", pageOptions.Limit.ToString());
                queryStringParameters.Add("offset", pageOptions.Offset.ToString());
            }

            if (queryStringParameters != null && queryStringParameters.Any())
            {
                requestUri = QueryHelpers.AddQueryString(requestUri, queryStringParameters);
            }

            var response = await Client.GetAsync(requestUri)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return _jsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
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
            var content = new StringContent(json, Encoding.UTF8, "application/json");
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
        /// <returns></returns>
        protected async Task<TResponse> Post<TResponse>(string requestUri, IDictionary<string, string> queryStringParameters = null)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            if (queryStringParameters != null && queryStringParameters.Any())
            {
                requestUri = QueryHelpers.AddQueryString(requestUri, queryStringParameters);
            }

            var response = await Client.PostAsync(requestUri, null)
                .ConfigureAwait(false);

            return _jsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Send a POST request to the api.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="queryStringParameters"></param>
        /// <returns></returns>
        protected async Task<TResponse> Post<TResponse, TRequest>(string requestUri, TRequest request, IDictionary<string, string> queryStringParameters = null)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            if (queryStringParameters != null && queryStringParameters.Any())
            {
                requestUri = QueryHelpers.AddQueryString(requestUri, queryStringParameters);
            }

            var json = _jsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
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
