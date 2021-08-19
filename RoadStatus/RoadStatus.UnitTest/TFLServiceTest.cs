using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using TFL.Config;
using TFL.Config.Interface;
using TFL.Domain;
using TFL.Service;
using TFL.Service.Interface;
using Xunit;

namespace RoadStatus.UnitTest
{
    /// <summary>
    /// This class used for initialize config setting from Appsettings.json
    /// </summary>
    public class AppSettingsFixture : IDisposable
    {
        public IConfigurationRoot Configuration { get; private set; }
        public AppSettingsFixture()
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false).Build();
        }
        public void Dispose()
        {
            Configuration = null;
        }
    }

    public class TFLServiceTest : IClassFixture<AppSettingsFixture>
    {
        public Mock<ITFLService> mock = new Mock<ITFLService>();
        private readonly AppSettingsFixture _appsettingsFixture;
        IOptions<TFLEndPoint> tflEndPointoptions;

        public TFLServiceTest(AppSettingsFixture appSettingsFixture)
        {
            _appsettingsFixture = appSettingsFixture;
            tflEndPointoptions = Options.Create(_appsettingsFixture.Configuration.GetSection("TFLEndPoint").Get<TFLEndPoint>());
        }

        [Fact]
        public async Task TFLService_Valid_RoadType_A21()
        {
            // Arrange
            TFLResponse tFLResponse = new TFLResponse() { ResponseCode = 0, ResponseMessage = "The status of the a21 is as follows \r\n\tRoad DisplayName is A21 \r\n\tRoad Status is Good \r\n\tRoad Status Description is No Exceptional Delays \r\n" };
            
            ITFLEndPoint tFLEndPoint = new ConfigDetails(tflEndPointoptions);
            mock.Setup(p => p.InvokeTFLApi("a21")).ReturnsAsync(tFLResponse);

            // Act
            TFLService tFLService = new TFLService(tFLEndPoint);
            var result = await tFLService.InvokeTFLApi("a21");

            // Assert
            Assert.Equal(tFLResponse.ResponseCode, result.ResponseCode);
            Assert.Equal(tFLResponse.ResponseMessage, result.ResponseMessage);
        }

        [Fact]
        public async Task TFLService_Valid_RoadType_A2()
        {
            // Arrange
            TFLResponse tFLResponse = new TFLResponse() { ResponseCode = 0, ResponseMessage = "The status of the A2 is as follows \r\n\tRoad DisplayName is A2 \r\n\tRoad Status is Good \r\n\tRoad Status Description is No Exceptional Delays \r\n" };

            ITFLEndPoint tFLEndPoint = new ConfigDetails(tflEndPointoptions);
            mock.Setup(p => p.InvokeTFLApi("A2")).ReturnsAsync(tFLResponse);

            // Act
            TFLService tFLService = new TFLService(tFLEndPoint);
            var result = await tFLService.InvokeTFLApi("A2");

            // Assert
            Assert.Equal(tFLResponse.ResponseCode, result.ResponseCode);
            Assert.Equal(tFLResponse.ResponseMessage, result.ResponseMessage);
        }

        [Theory(DisplayName ="This Test method to validate invalid Road Type Api response")]
        [InlineData("a231")]
        public async Task TFLService_Invalid_RoadType_A221(string roadCode)
        {
            // Arrange
            TFLResponse tFLResponse = new TFLResponse() { ResponseCode = 1, ResponseMessage = $"{roadCode} is not a valid road" };

            ITFLEndPoint tFLEndPoint = new ConfigDetails(tflEndPointoptions);
            mock.Setup(p => p.InvokeTFLApi(roadCode)).ReturnsAsync(tFLResponse);

            // Act
            TFLService tFLService = new TFLService(tFLEndPoint);
            var result = await tFLService.InvokeTFLApi(roadCode);

            // Assert
            Assert.Equal(tFLResponse.ResponseCode, result.ResponseCode);
            Assert.Equal(tFLResponse.ResponseMessage, result.ResponseMessage);
        }
    }
}
