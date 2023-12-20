using MediatR;

namespace Application.Commands.DeviceService
{
    public class CreateDeviceCommand : IRequest<int>
    {
        public int Id  { get; set; }
    
        
        public string Name { get; set; }
        
    
    }
}
