using System;
using AppleMusicAPI.NET.Enums;

namespace AppleMusicAPI.NET.Extensions
{
    public static class RecommendationsTypeExtensions
    {
        public static string ToRecommendationsTypeString(this RecommendationsType recommendationsType)
        {
            switch (recommendationsType)
            {
                case RecommendationsType.Albums:
                    return "albums";
                case RecommendationsType.Playlists:
                    return "playlists";
                default:
                    throw new NotImplementedException();

            }
        }
    }
}