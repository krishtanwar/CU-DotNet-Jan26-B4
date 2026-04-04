namespace Back_End.Middleware
{
    [Serializable]
    internal class InvalidRatingException : Exception
    {
        public InvalidRatingException()
        {
        }

        public InvalidRatingException(string? message) : base(message)
        {
        }

        public InvalidRatingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}