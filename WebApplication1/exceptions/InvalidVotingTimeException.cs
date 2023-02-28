namespace VoteInRestaurant.exception
{
    public class InvalidVotingTimeException : Exception
    {
        public InvalidVotingTimeException() { }

        public InvalidVotingTimeException(string message)
            : base(message) { }

        public InvalidVotingTimeException(string message, Exception inner)
            : base(message, inner) { }
    }
}
