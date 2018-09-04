using System.Collections.Generic;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Models.Core;
using AppleMusicAPI.NET.Models.Responses;

namespace AppleMusicAPI.NET.Clients.Interfaces
{
    public interface IStorefrontsClient : IBaseClient
    {
        Task<StorefrontResponse> GetStorefront(string id);
        Task<StorefrontResponse> GetStorefronts(IReadOnlyCollection<string> ids);
        Task<StorefrontResponse> GetAllStorefronts(PageOptions pageOptions = null);
        Task<StorefrontResponse> GetUsersStorefront(string userToken);
    }
}