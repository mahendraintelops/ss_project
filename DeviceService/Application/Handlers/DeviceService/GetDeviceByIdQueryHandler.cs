using AutoMapper;
using MediatR;
using Application.Queries.DeviceService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.DeviceService
{
    public class GetDeviceByIdQueryHandler : IRequestHandler<GetDeviceByIdQuery, DeviceResponse>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        public GetDeviceByIdQueryHandler(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }
        public async Task<DeviceResponse> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedDevice = await _deviceRepository.GetByIdAsync(request.id);
            var deviceEntity = _mapper.Map<DeviceResponse>(generatedDevice);
            return deviceEntity;
        }
    }
}
