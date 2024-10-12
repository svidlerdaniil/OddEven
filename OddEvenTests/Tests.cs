using Moq;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace OddEvenServer.Tests
{
    public class OddEvenControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public OddEvenControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetOddEven_ReturnsOkStatus()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/OddEven");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(2024, 10, 10, 12, 12, 12, "чет!")]
        [InlineData(2024, 10, 11, 13, 13, 13, "нечет!")]
        [InlineData(2023, 10, 10, 11, 12, 13, "равно!")]
        public async Task GetOddEven_ReturnsCorrectResult(int year, int month, int day, int hour, int minute, int second, string expectedMessage)
        {
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockDateTimeProvider.Setup(p => p.GetCurrentDateTime())
                .Returns(new DateTime(year, month, day, hour, minute, second));

            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton<IDateTimeProvider>(mockDateTimeProvider.Object);
                });
            }).CreateClient();
            var response = await client.GetAsync("/api/OddEven");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains(expectedMessage, content);
        }
    }
}
