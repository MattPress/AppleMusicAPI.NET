using AppleMusicAPI.NET.Clients;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
    public class StorefrontsClientFixture : BaseClientFixture<StorefrontsClient>
    {
        public StorefrontsClientFixture()
        {
            Client = new StorefrontsClient(HttpClient, MockJsonSerializer.Object, MockJwtProvider.Object);
        }
    }
}
