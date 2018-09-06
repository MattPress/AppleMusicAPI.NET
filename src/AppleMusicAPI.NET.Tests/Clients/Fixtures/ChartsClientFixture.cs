using AppleMusicAPI.NET.Clients;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
    public class ChartsClientFixture : BaseClientFixture<ChartsClient>
    {
        public ChartsClientFixture()
        {
            Client = new ChartsClient(HttpClient, MockJsonSerializer.Object, MockJwtProvider.Object);
        }
    }
}
