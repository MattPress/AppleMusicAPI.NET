using System;
using System.Collections.Generic;
using System.Text;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Relationships
{
    /// <summary>
    /// The relationships for an activity object.
    /// https://developer.apple.com/documentation/applemusicapi/activity/relationships
    /// </summary>
    public class ActivityRelationships : IRelationships
    {
        /// <summary>
        /// The playlists associated with this activity. By default, playlists includes identifiers only. Fetch limits: 10 default, 10 maximum
        /// </summary>
        public PlaylistRelationship Playlists { get; set; }
    }
}
