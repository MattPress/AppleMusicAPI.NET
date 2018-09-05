using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Requests;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    /// <summary>
    /// Library playlists client contract
    /// </summary>
    public interface ILibraryPlaylistsClient : IBaseClient
    {
        /// <summary>
        /// Create a new playlist in a user’s library.
        /// https://developer.apple.com/documentation/applemusicapi/create_a_new_library_playlist
        /// </summary>
        /// <param name="request"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<LibraryPlaylistResponse> CreateLibraryPlaylist(LibraryPlaylistCreationRequest request, IReadOnlyCollection<LibraryPlaylistRelationship> include = null);
    }
}