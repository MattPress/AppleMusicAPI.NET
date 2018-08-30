using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for an Apple curator object.
    /// https://developer.apple.com/documentation/applemusicapi/applecurator/relationships
    /// </summary>
    public class AppleCuratorRelationships : IRelationships
    {
        /// <summary>
        /// The playlists associated with this curator. By default, playlists includes identifiers only.
        /// Fetch limits: 10 default, 10 maximum
        /// </summary>
        public PlaylistRelationship Playlists { get; set; }
    }
}
