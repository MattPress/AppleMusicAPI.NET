using System;
using Xunit;

namespace AppleMusicAPI.NET.Tests.IntegrationTests
{
    [Trait("Category", "Integration Tests")]
    public class TestBase : IDisposable
    {
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
