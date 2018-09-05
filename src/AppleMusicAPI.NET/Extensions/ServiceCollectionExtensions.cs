using System;
using System.Net.Http;
using AppleMusicAPI.NET.Clients;
using AppleMusicAPI.NET.Clients.Interfaces;
using AppleMusicAPI.NET.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppleMusicAPI.NET.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppleMusicApi(this IServiceCollection services, string keyId, string teamId, string privateKeyPath)
        {
            services.AddSingleton<IJsonSerializer, JsonSerializer>();
            services.AddSingleton(new JwtProviderConfiguration
            {
                KeyId = keyId,
                TeamId = teamId,
                PrivateKeyPath = privateKeyPath
            });
            services.AddSingleton<IJwtProvider, JwtProvider>();
        }

        public static IHttpClientBuilder AddAppleMusicApiHttpClient<TClient, TImplementation>(this IServiceCollection services)
            where TClient : class 
            where TImplementation : BaseClient, TClient
        {
            return services.AddHttpClient<TClient, TImplementation>();
        }

        public static IHttpClientBuilder AddAppleMusicApiHttpClient<TClient, TImplementation>(this IServiceCollection services, Action<HttpClient> configureClients)
            where TClient : class
            where TImplementation : BaseClient, TClient
        {
            return services.AddHttpClient<TClient, TImplementation>();
        }

        public static void AddAppleMusicApiHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<IChartsClient, ChartsClient>();
            services.AddHttpClient<IiCloudMusicLibraryClient, iCloudMusicLibraryClient>();
            services.AddHttpClient<ILibraryPlaylistsClient, LibraryPlaylistsClient>();
            services.AddHttpClient<IRatingsClient, RatingsClient>();
            services.AddHttpClient<IRecentHistoryClient, RecentHistoryClient>();
            services.AddHttpClient<IRecommendationsClient, RecommendationsClient>();
            services.AddHttpClient<IResourceDataClient, ResourceDataClient>();
            services.AddHttpClient<ISearchClient, SearchClient>();
            services.AddHttpClient<IStorefrontsClient, StorefrontsClient>();
        }

        public static void AddAppleMusicApiHttpClients(this IServiceCollection services, Action<HttpClient> configureClients)
        {
            services.AddHttpClient<IChartsClient, ChartsClient>(configureClients);
            services.AddHttpClient<IiCloudMusicLibraryClient, iCloudMusicLibraryClient>(configureClients);
            services.AddHttpClient<ILibraryPlaylistsClient, LibraryPlaylistsClient>(configureClients);
            services.AddHttpClient<IRatingsClient, RatingsClient>(configureClients);
            services.AddHttpClient<IRecentHistoryClient, RecentHistoryClient>(configureClients);
            services.AddHttpClient<IRecommendationsClient, RecommendationsClient>(configureClients);
            services.AddHttpClient<IResourceDataClient, ResourceDataClient>(configureClients);
            services.AddHttpClient<ISearchClient, SearchClient>(configureClients);
            services.AddHttpClient<IStorefrontsClient, StorefrontsClient>(configureClients);
        }
    }
}
