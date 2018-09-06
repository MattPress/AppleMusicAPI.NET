using AppleMusicAPI.NET.Clients;

namespace AppleMusicAPI.NET.Tests.Clients.Fixtures
{
    public class LibraryPlaylistsClientFixture : BaseClientFixture<LibraryPlaylistsClient>
    {
        public LibraryPlaylistsClientFixture()
        {
            Client = new LibraryPlaylistsClient(HttpClient, MockJsonSerializer.Object, MockJwtProvider.Object);
        }
    }
}
