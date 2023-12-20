using AutoMapper;
using Moq;
using Application.Handlers.DeviceService;
using Application.Queries.DeviceService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DeviceService
{
    public class GetAllDevicesQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfDeviceResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Device, DeviceResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<Device> 
        {
            new Device { Id = 1 },
            new Device { Id = 2 }

        };

            var RepositoryMock = new Mock<IDeviceRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllDevicesQuery();
            var handler = new GetAllDevicesQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<DeviceResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
