using AppleMusicAPI.NET.Utilities;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests.DeserializationTests
{
    [Trait("Category", "Deserialization")]
    public abstract class DeserializationTestBase : TestBase
    {
        protected string JsonResponse { get; set; }
        protected IJsonSerializer JsonSerializer { get; set; }

        protected DeserializationTestBase(string fileName)
        {
            JsonResponse = EmbeddedResourceProvider.GetContent(fileName);
            JsonSerializer = new JsonSerializer();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                JsonResponse = null;
                JsonSerializer = null;
            }

            base.Dispose(disposing);
        }
    }
}
