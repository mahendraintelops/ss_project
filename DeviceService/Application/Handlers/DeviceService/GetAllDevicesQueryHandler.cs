using AutoMapper;
using MediatR;
using Application.Queries.DeviceService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.DeviceService
{
    public class GetAllDevicesQueryHandler : IRequestHandler<GetAllDevicesQuery, List<DeviceResponse>>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        public GetAllDevicesQueryHandler(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }
        public async Task<List<DeviceResponse>> Handle(GetAllDevicesQuery request, CancellationToken cancellationToken)
        {
            var generatedDevice = await _deviceRepository.GetAllAsync();
            var deviceEntity = _mapper.Map<List<DeviceResponse>>(generatedDevice);
            return deviceEntity;
        }
    }
}
