using AppleMusicAPI.NET.Clients;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
#pragma warning disable IDE1006 // Naming Styles
    public class iCloudMusicLibraryClientFixture : BaseClientFixture<iCloudMusicLibraryClient>
#pragma warning restore IDE1006 // Naming Styles
    {
        public iCloudMusicLibraryClientFixture()
        {
            Client = new iCloudMusicLibraryClient(HttpClient, MockJsonSerializer.Object, MockJwtProvider.Object);
        }
    }
}
