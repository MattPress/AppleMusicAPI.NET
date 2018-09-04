using AppleMusicAPI.NET.Clients;
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
            services.AddSingleton(new JwtProviderConfiguration()
            {
                KeyId = keyId,
                TeamId = teamId,
                PrivateKeyPath = privateKeyPath
            });
            services.AddSingleton<IJwtProvider, JwtProvider>();
        }

        public static void AddAppleMusicApiHttpClient<TClient, TImplementation>(this IServiceCollection services)
            where TClient : class 
            where TImplementation : BaseClient, TClient
        {
            services.AddHttpClient<TClient, TImplementation>();
        }
    }
}
