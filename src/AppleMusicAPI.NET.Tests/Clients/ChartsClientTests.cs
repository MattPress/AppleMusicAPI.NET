using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AppleMusicAPI.NET.Tests.Clients.Fixtures;
using Moq;
using Moq.Protected;
using Xunit;

namespace AppleMusicAPI.NET.Tests.Clients
{
    public class ChartsClientTests : IClassFixture<ChartsClientFixture>
    {
        protected ChartsClientFixture Fixture { get; }
        
        public ChartsClientTests(ChartsClientFixture fixture)
        {
            Fixture = fixture;
        }

        public class GetCatalogCharts : ChartsClientTests
        {
            public GetCatalogCharts(ChartsClientFixture fixture)
                : base(fixture)
            {
            }

            [Fact]
            public async Task WithNullStorefront_ShouldThrowArgumentNullException()
            {
                // Arrange

                // Act
                Task Task() => Fixture.Client.GetCatalogCharts(null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(Task);
            }

            [Fact]
            public async Task WithValidStorefront_ShouldCallHttpClientGetAsync()
            {
                // Arrange
                
                // Act
                await Fixture.Client.GetCatalogCharts("storefront");

                // Assert
                Fixture.VerifyHttpClientHandlerSendAsync(Times.Once());
            }
        }
    }
}
