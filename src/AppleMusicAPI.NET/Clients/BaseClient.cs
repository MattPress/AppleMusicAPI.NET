using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Utilities;
using Microsoft.AspNetCore.WebUtilities;

namespace AppleMusicAPI.NET.Clients
{
    public abstract class BaseClient
    {
        private const string BaseUrl = "https://api.music.apple.com/v1/";

        private readonly IJsonSerializer _jsonSerializer;

        protected HttpClient Client { get; }

        protected string DefaultQueryStringParameters => $"?l={CultureInfo.CurrentCulture.Name}";

        protected BaseClient(HttpClient client, IJsonSerializer jsonSerializer)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));

            Client.BaseAddress = new Uri(BaseUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SetDeveloperTokenAuthorizationHeader(string developerToken)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", developerToken);
        }

        protected void SetUserTokenHeader(string userToken)
        {
            Client.DefaultRequestHeaders.Add("Music-User-Token", userToken);
        }

        protected async Task<TResponse> Get<TResponse>(string requestUri, Dictionary<string, string> queryStringParameters = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            requestUri = $"{requestUri}{DefaultQueryStringParameters}";

            if (pageOptions != null)
            {
                queryStringParameters = queryStringParameters ?? new Dictionary<string, string>();
                queryStringParameters.Add(nameof(PageOptions.Limit), pageOptions.Limit.ToString());
                queryStringParameters.Add(nameof(PageOptions.Offset), pageOptions.Offset.ToString());
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

        protected async Task<bool> Delete(string requestUri)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                throw new ArgumentNullException(nameof(requestUri));

            var response = await Client.DeleteAsync(requestUri)
                .ConfigureAwait(false);
            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
