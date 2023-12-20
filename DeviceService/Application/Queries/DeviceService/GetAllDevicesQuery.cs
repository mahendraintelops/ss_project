using MediatR;
using Application.Responses;

namespace Application.Queries.DeviceService
{
    public class GetAllDevicesQuery : IRequest<List<DeviceResponse>>
    {

    }
}
