using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    /// <summary>
    /// iCloud music library client contract.
    /// </summary>
    public interface IiCloudMusicLibraryClient : IBaseClient
    {
        /// <summary>
        /// Add a catalog resource to a user’s iCloud Music Library.
        /// https://developer.apple.com/documentation/applemusicapi/add_a_resource_to_a_library
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<ResponseRoot> AddResourceToLibrary(string userToken, IReadOnlyDictionary<iCloudMusicLibraryType, List<string>> ids);
    }
}