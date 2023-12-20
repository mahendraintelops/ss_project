namespace Application.Exceptions
{
    public class DeviceNotFoundException : ApplicationException
    {
        public DeviceNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
