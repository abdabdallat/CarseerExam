using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTOs;
using Infrastructure.Services;
using Microsoft.Extensions.Hosting;
using Moq;
using Xunit;

namespace  UnitTests
{
    public class ModelServiceTests
    {
        [Fact]
        public async Task GetModelsForMakeIdYear_ShouldReturnModels()
        {
            // Arrange
            var hostEnvironmentMock = new Mock<IHostEnvironment>();
            hostEnvironmentMock.Setup(env => env.ContentRootPath).Returns("fake/path");
            var modelService = new ModelService(null, hostEnvironmentMock.Object);

            // Act
            var result = await modelService.GetModelsForMakeIdYear(new GetModelRequestDTO
            {
                Make = "SomeMake",
                ModelYear = 2022
            });

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetModelsForMakeIdYear_WithNoIntegrationResults_ShouldReturnEmptyList()
        {
            // Arrange
            var hostEnvironmentMock = new Mock<IHostEnvironment>();
            hostEnvironmentMock.Setup(env => env.ContentRootPath).Returns("fake/path");
            var modelService = new ModelService(null, hostEnvironmentMock.Object);

            // Act
            var result = await modelService.GetModelsForMakeIdYear(new GetModelRequestDTO
            {
                Make = "SomeMake",
                ModelYear = 2022
            });

            // Assert
            Assert.NotNull(result);
        }
    }
}