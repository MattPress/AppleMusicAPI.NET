using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class RecommendationsClient : BaseClient
    {
        private const string BaseRequestUri = "me/recommendations";

        public RecommendationsClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider) 
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        public async Task<RecommendationResponse> GetRecommendation(string userToken, string id, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            SetUserTokenHeader(userToken);

            return await Get<RecommendationResponse>($"{BaseRequestUri}/{id}", pageOptions: pageOptions)
                .ConfigureAwait(false);
        }

        public async Task<RecommendationResponse> GetMultipleRecommendations(string userToken, IReadOnlyCollection<string> ids, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>
            {
                { "ids", string.Join(",", ids) }
            };

            return await Get<RecommendationResponse>(BaseRequestUri, queryString)
                .ConfigureAwait(false);
        }

        public async Task<RecommendationResponse> GetDefaultRecommendations(string userToken, RecommendationsType? recommendationsType = null, PageOptions pageOptions = null)
        {
            if (string.IsNullOrWhiteSpace(userToken))
                throw new ArgumentNullException(nameof(userToken));

            SetUserTokenHeader(userToken);

            var queryString = new Dictionary<string, string>();

            if (recommendationsType.HasValue)
            {
                queryString.Add("type", recommendationsType.Value.ToRecommendationsTypeString());
            };

            return await Get<RecommendationResponse>(BaseRequestUri, queryString)
                .ConfigureAwait(false);
        }
    }
}
