using AutoMapper;
using Moq;
using Application.Handlers.DeviceService;
using Application.Queries.DeviceService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DeviceService
{
    public class GetDeviceByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsDeviceResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Device, DeviceResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new Device { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IDeviceRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetDeviceByIdQuery(Id);
            var handler = new GetDeviceByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DeviceResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
