using System;
using System.Collections.Generic;
using System.Linq;
using AppleMusicAPI.NET.Extensions;
using AppleMusicAPI.NET.Models.Enums;
using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;

namespace AppleMusicAPI.NET.Tests.UnitTests
{
    [Trait("Category","Unit Tests")]
    public abstract class TestBase : IDisposable
    {
        protected IFixture Fixture { get; private set; }

        protected TestBase()
        {
            Fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
        }

        public static IEnumerable<T> AllEnumsOfType<T>()
            where T : IConvertible
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .OrderBy(x => x.GetValue());
        }

        public static IEnumerable<object[]> AllEnumsMemberData<T>()
            where T : IConvertible
        {
            return new List<object[]>(
                AllEnumsOfType<T>()
                    .Select(x => new object[] { x })
                    .AsEnumerable()
            );
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Fixture = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
