using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.DeviceService;
using Application.Queries.DeviceService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DeviceServiceController> _logger;
        public DeviceServiceController(IMediator mediator, ILogger<DeviceServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateDevice")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateDevice([FromBody] CreateDeviceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        
        [HttpGet(Name = "GetAllDevices")]
        [ProducesResponseType(typeof(IEnumerable<List<DeviceResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DeviceResponse>>> GetAllDevices(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllDevicesQuery(), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpGet("{id}", Name = "GetDeviceById")]
        [ProducesResponseType(typeof(DeviceResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DeviceResponse>> GetDeviceById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Device GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetDeviceByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpPut(Name = "UpdateDevice")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateDevice([FromBody] UpdateDeviceCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        

        
    }
}
