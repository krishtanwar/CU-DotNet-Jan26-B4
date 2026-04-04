namespace Back_End.Middleware
{
    [Serializable]
    internal class DestinationNotFound : Exception
    {
        public DestinationNotFound()
        {
        }

        public DestinationNotFound(string? message) : base(message)
        {
        }

        public DestinationNotFound(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}