using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.DeviceService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.DeviceService
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ILogger<DeleteDeviceCommandHandler> _logger;

        public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository, ILogger<DeleteDeviceCommandHandler> logger)
        {
            _deviceRepository = deviceRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            var deviceToDelete = await _deviceRepository.GetByIdAsync(request.Id);
            if (deviceToDelete == null)
            {
                throw new DeviceNotFoundException(nameof(Device), request.Id);
            }

            await _deviceRepository.DeleteAsync(deviceToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
