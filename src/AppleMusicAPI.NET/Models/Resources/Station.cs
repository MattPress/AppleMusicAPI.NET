using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// A Resource object that represents a station.
    /// https://developer.apple.com/documentation/applemusicapi/station
    /// </summary>
    /// <inheritdoc />
    public class Station : Resource<StationAttributes>
    {
        /// <summary>
        /// (Required) This value will always be stations.
        /// Value: stations
        /// </summary>
        public override string Type => Constants.Resources.Stations;
    }
}
