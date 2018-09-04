using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Enums;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Responses;
using AppleMusicAPI.NET.Utilities;

namespace AppleMusicAPI.NET.Clients
{
    public class ResourceDataClient : BaseClient
    {
        private const string BaseRequestUri = "catalog";

        public ResourceDataClient(HttpClient httpClient, IJsonSerializer jsonSerializer, IJwtProvider jwtProvider)
            : base(httpClient, jsonSerializer, jwtProvider)
        {
        }

        public async Task<AlbumResponse> GetCatalogAlbum(string id, string storefront, IReadOnlyCollection<Relationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogItem<AlbumResponse>(Catalog.Albums, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        public async Task<MusicVideoResponse> GetCatalogMusicVideo(string id, string storefront, IReadOnlyCollection<Relationship> relationshipsToInclude = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetCatalogItem<MusicVideoResponse>(Catalog.MusicVideos, id, storefront, relationshipsToInclude)
                .ConfigureAwait(false);
        }

        public async Task<AlbumResponse> GetCatalogAlbumRelationship(string id, string storefront, string relationship, int? limit = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            if (string.IsNullOrWhiteSpace(relationship))
                throw new ArgumentNullException(nameof(relationship));

            return await GetCatalogItemRelationship<AlbumResponse>(Catalog.Albums, id, storefront, relationship, limit)
                .ConfigureAwait(false);
        }

        public async Task<AlbumResponse> GetMultipleCatalogAlbums(IReadOnlyCollection<string> ids, string storefront, IReadOnlyCollection<Relationship> include = null)
        {
            if (ids == null || !ids.Any())
                throw new ArgumentNullException(nameof(ids));

            if (string.IsNullOrWhiteSpace(storefront))
                throw new ArgumentNullException(nameof(storefront));

            return await GetMultipleCatalogItems<AlbumResponse>(Catalog.Albums, ids, storefront, include)
                .ConfigureAwait(false);
        }

        private async Task<TResponse> GetCatalogItem<TResponse>(Catalog catalog, string id, string storefront, IReadOnlyCollection<Relationship> relationshipsToInclude = null)
        {
            var queryString = new Dictionary<string, string>();
            if (relationshipsToInclude != null && relationshipsToInclude.Any())
                queryString.Add("include", string.Join(",", relationshipsToInclude.Select(x => x.ToRelationshipString())));

            return await Get<TResponse>($"{BaseRequestUri}/{storefront}/{catalog.ToCatalogString()}/{id}", queryString)
                .ConfigureAwait(false);
        }

        private async Task<TResponse> GetCatalogItemRelationship<TResponse>(Catalog catalog, string id, string storefront, string relationship, int? limit = null)
        {
            var queryString = new Dictionary<string, string>();
            if (limit.HasValue)
                queryString.Add("limit", limit.Value.ToString());

            return await Get<TResponse>($"{BaseRequestUri}/{storefront}/{catalog.ToCatalogString()}/{id}/{relationship}", queryString)
                .ConfigureAwait(false);
        }

        private async Task<TResponse> GetMultipleCatalogItems<TResponse>(Catalog catalog, IEnumerable<string> ids, string storefront, IReadOnlyCollection<Relationship> include = null)
        {
            var queryString = new Dictionary<string, string>
            {
                { "ids", string.Join(",", ids) }
            };

            if (include != null && include.Any())
                queryString.Add("include", string.Join(",", include.Select(x => x.ToRelationshipString())));

            return await Get<TResponse>($"{BaseRequestUri}/{storefront}/{catalog.ToCatalogString()}", queryString)
                .ConfigureAwait(false);
        }
    }
}
