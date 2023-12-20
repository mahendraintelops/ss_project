using MediatR;

namespace Application.Commands.DeviceService
{
    public class DeleteDeviceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
