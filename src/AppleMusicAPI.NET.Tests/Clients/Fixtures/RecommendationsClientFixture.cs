using AppleMusicAPI.NET.Clients;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
    public class RecommendationsClientFixture : BaseClientFixture<RecommendationsClient>
    {
        public RecommendationsClientFixture()
        {
            Client = new RecommendationsClient(HttpClient, MockJsonSerializer.Object, MockJwtProvider.Object);
        }
    }
}
