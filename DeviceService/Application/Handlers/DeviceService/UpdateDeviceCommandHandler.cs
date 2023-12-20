using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.DeviceService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.DeviceService
{
    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDeviceCommandHandler> _logger;

        public UpdateDeviceCommandHandler(IDeviceRepository deviceRepository, IMapper mapper, ILogger<UpdateDeviceCommandHandler> logger)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var deviceToUpdate = await _deviceRepository.GetByIdAsync(request.Id);
            if (deviceToUpdate == null)
            {
                throw new DeviceNotFoundException(nameof(Device), request.Id);
            }

            _mapper.Map(request, deviceToUpdate, typeof(UpdateDeviceCommand), typeof(Device));
            await _deviceRepository.UpdateAsync(deviceToUpdate);
            _logger.LogInformation($"Device is successfully updated");
        }
    }
}
