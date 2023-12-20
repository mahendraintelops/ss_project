using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.DeviceService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.DeviceService
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, int>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateDeviceCommandHandler> _logger;

        public CreateDeviceCommandHandler(IDeviceRepository deviceRepository, IMapper mapper, ILogger<CreateDeviceCommandHandler> logger)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var deviceEntity = _mapper.Map<Device>(request);

            /*****************************************************************************/
            var generatedDevice = await _deviceRepository.AddAsync(deviceEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedDevice} successfully created.");
            return generatedDevice.Id;
        }
    }
}
