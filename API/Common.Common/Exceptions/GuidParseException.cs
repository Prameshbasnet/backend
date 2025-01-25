namespace Common.Common.Exceptions
{
    public class GuidParseException : Exception
    {
        public GuidParseException(string message) : base(message) { }
        public static GuidParseException Create(string field, string value)
        {
            return new GuidParseException($"{field} with value {value} is invalid");
        }
    }
}
