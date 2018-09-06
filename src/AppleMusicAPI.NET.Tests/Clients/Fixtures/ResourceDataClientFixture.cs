using AppleMusicAPI.NET.Clients;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
    public class ResourceDataClientFixture : BaseClientFixture<ResourceDataClient>
    {
        public ResourceDataClientFixture()
        {
            Client = new ResourceDataClient(HttpClient, MockJsonSerializer.Object, MockJwtProvider.Object);
        }
    }
}
