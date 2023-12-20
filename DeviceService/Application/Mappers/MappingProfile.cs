using AutoMapper;

using Application.Commands.DeviceService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Device, DeviceResponse>().ReverseMap();
            CreateMap<Device, CreateDeviceCommand>().ReverseMap();
            CreateMap<Device, UpdateDeviceCommand>().ReverseMap();
          
        }
    }
}
