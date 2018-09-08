using System;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests
{
    [Trait("Category","Unit Tests")]
    public abstract class TestBase : IDisposable
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
