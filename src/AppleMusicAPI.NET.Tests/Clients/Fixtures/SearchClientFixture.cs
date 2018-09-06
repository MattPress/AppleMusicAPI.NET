using AppleMusicAPI.NET.Clients;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
    public class SearchClientFixture : BaseClientFixture<SearchClient>
    {
        public SearchClientFixture()
        {
            Client = new SearchClient(HttpClient, MockJsonSerializer.Object, MockJwtProvider.Object);
        }
    }
}
