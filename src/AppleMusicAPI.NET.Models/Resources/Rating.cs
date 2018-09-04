using AppleMusicAPI.NET.Models.Attributes;
using AppleMusicAPI.NET.Models.Core;

namespace AppleMusicAPI.NET.Models.Resources
{
    /// <summary>
    /// An object that represents a rating for a Resource.
    /// https://developer.apple.com/documentation/applemusicapi/rating
    /// </summary>
    public class Rating : Resource<RatingAttributes>
    {
        /// <summary>
        /// (Required) This value will always be ratings.
        /// Value: ratings
        /// </summary>
        public override string Type => Constants.Resources.Ratings;
    }
}
