namespace VoteInRestaurant.exception
{
    public class PersonHasAlreadyVotedException : Exception
    {
        public PersonHasAlreadyVotedException() { }

        public PersonHasAlreadyVotedException(string message)
            : base(message) { }

        public PersonHasAlreadyVotedException(string message, Exception inner)
            : base(message, inner) { }
    }
}
