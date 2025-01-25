namespace Common.Common.Exceptions
{
    public class UniqueConstraintViolationException : Exception
    {
        public UniqueConstraintViolationException(string message) : base(message) { }
        public static UniqueConstraintViolationException Create(string field, string value)
        {
            return new UniqueConstraintViolationException($"{field} with value {value} already exists.");
        }
    }
}
