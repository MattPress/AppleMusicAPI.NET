using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Enums;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    public interface IiCloudMusicLibraryClient
    {
        Task<ResponseRoot> AddResourceToLibrary(string userToken, IReadOnlyDictionary<iCloudMusicLibraryType, List<string>> ids);
    }
}