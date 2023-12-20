using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.DeviceService;
using Application.Handlers.DeviceService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DeviceService
{
    public class CreateDeviceCommandHandlerTests
    {
        private readonly Mock<IDeviceRepository> _deviceRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateDeviceCommandHandler>> _logger;

        public CreateDeviceCommandHandlerTests()
        {
            _deviceRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateDeviceCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<Device>(request))
                .Returns(new Device()); 

            _deviceRepository
                .Setup(r => r.AddAsync(It.IsAny<Device>()))
                .ReturnsAsync(new Device { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateDeviceCommandHandler>>();
            var handler = new CreateDeviceCommandHandler(_deviceRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
