using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.DeviceService;
using Application.Exceptions;
using Application.Handlers.DeviceService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DeviceService
{
    public class DeleteDeviceCommandHandlerTests
    {
        private readonly Mock<IDeviceRepository> _deviceRepository;
        private readonly Mock<ILogger<DeleteDeviceCommandHandler>> _logger;

        public DeleteDeviceCommandHandlerTests()
        {
            _deviceRepository = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ThrowsDeviceNotFoundExceptionWhenDeviceNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteDeviceCommand { Id = Id }; // Create a request object

            _deviceRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Device)null); // Mock the repository to return null

            var handler = new DeleteDeviceCommandHandler(_deviceRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<DeviceNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
