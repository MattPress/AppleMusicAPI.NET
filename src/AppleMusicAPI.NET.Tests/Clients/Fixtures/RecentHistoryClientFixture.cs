using AppleMusicAPI.NET.Clients;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
    public class RecentHistoryClientFixture : BaseClientFixture<RecentHistoryClient>
    {
        public RecentHistoryClientFixture()
        {
            Client = new RecentHistoryClient(HttpClient, MockJsonSerializer.Object, MockJwtProvider.Object);
        }
    }
}
