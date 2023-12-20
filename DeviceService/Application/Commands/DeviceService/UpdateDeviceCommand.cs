using MediatR;

namespace Application.Commands.DeviceService
{
    public class UpdateDeviceCommand : IRequest
    {
        public int Id  { get; set; }
    
        
        public string Name { get; set; }
        
    
    }
}
