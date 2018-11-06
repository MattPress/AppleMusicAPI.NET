using System.IO;
using System.Linq;

namespace AppleMusicAPI.NET.Tests
{
    public class EmbeddedResourceProvider
    {
        public static string GetContent(string fileName)
        {
            var assembly = typeof(EmbeddedResourceProvider).Assembly;
            var path = assembly.GetManifestResourceNames()
                .FirstOrDefault(x => x.EndsWith(fileName));

            if (string.IsNullOrWhiteSpace(path))
                throw new FileNotFoundException($"Resource not found: {path}");

            using (var resource = assembly.GetManifestResourceStream(path))
            using (var stream = new StreamReader(resource))
            {
                return stream.ReadToEnd();
            }
        }
    }
}
