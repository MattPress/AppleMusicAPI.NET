using System;
using AppleMusicAPI.NET.Models.Enums;

namespace AppleMusicAPI.NET.Extensions
{
    public static class LibraryExtensions
    {
        public static string ToLibraryString(this Library library)
        {
            switch (library)
            {
                case Library.MusicVideos:
                    return "library-music-videos";
                case Library.Playlists:
                    return "library-playlists";
                case Library.Songs:
                    return "library-songs";
                default:
                    throw new NotImplementedException();

            }
        }
    }
}
