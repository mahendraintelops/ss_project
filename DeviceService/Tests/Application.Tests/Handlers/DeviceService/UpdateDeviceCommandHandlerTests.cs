using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.DeviceService;
using Application.Exceptions;
using Application.Handlers.DeviceService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DeviceService
{
    public class UpdateDeviceCommandHandlerTests
    {
        private readonly Mock<IDeviceRepository> _deviceRepository;
        private readonly Mock<ILogger<UpdateDeviceCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateDeviceCommandHandlerTests()
        {
            _deviceRepository = new();
            _logger = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_ThrowsDeviceNotFoundExceptionWhenDeviceNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateDeviceCommand { Id = Id }; // Create a request object

            _deviceRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Device)null); // Mock the repository to return null

            var handler = new UpdateDeviceCommandHandler(_deviceRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<DeviceNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
