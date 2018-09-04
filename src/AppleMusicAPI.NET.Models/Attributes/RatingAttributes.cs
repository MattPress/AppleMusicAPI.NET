using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Attributes
{
    /// <summary>
    /// The attributes for a rating object.
    /// https://developer.apple.com/documentation/applemusicapi/rating/attributes
    /// </summary>
    public class RatingAttributes : IAttributes
    {
        // TODO - MJP - See if we can add an enumeration and serialize as int
        /// <summary>
        /// (Required) The value for the resource's rating. The possible values for the value key are 1 and -1.
        /// Possible values: 1, -1
        /// </summary>
        public int Value { get; set; }
    }
}
