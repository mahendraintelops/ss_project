using MediatR;
using Application.Responses;

namespace Application.Queries.DeviceService
{
    public class GetDeviceByIdQuery : IRequest<DeviceResponse>
    {
        public int id { get; set; }

        public GetDeviceByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
