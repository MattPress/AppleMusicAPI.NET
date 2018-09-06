using AppleMusicAPI.NET.Clients;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
    public class RatingsClientFixture : BaseClientFixture<RatingsClient>
    {
        public RatingsClientFixture()
        {
            Client = new RatingsClient(HttpClient, MockJsonSerializer.Object, MockJwtProvider.Object);
        }
    }
}
