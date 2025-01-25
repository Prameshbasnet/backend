namespace Common.Common.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message) { }
        public static ResourceNotFoundException Create<T>(Guid id)
        {
            return new ResourceNotFoundException($"{typeof(T).Name} with ID {id} not found.");
        }
        public static ResourceNotFoundException Create<T>(string field, string value)
        {
            return new ResourceNotFoundException($"{typeof(T).Name} {field} with {value} not found.");
        }
        public static ResourceNotFoundException Create(string value)
        {
            return new ResourceNotFoundException($"{value}");
        }

        public static ResourceNotFoundException Create<T>(string name)
        {
            return new ResourceNotFoundException($"{typeof(T).Name} with name {name} not found.");
        }
    }
}
