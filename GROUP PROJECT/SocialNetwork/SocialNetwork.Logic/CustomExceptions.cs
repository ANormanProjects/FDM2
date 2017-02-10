using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
    public class SameEntityException : Exception
    {
        public SameEntityException() : base("Entities are the same")
        {

        }
    }
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("Entity is not in database")
        {

        }
    }

    public class IntegerMustBeGreaterThanZeroException : Exception
    {
        public IntegerMustBeGreaterThanZeroException() : base("Input number needs to be greater than 0")
        {

        }
    }

    public class InputExceedsSpecifiedLimitException : Exception 
    {
        public InputExceedsSpecifiedLimitException() : base("Input has exceeded the specified limit") 
        {
        
        }
    }

    public class EmptyInputException : Exception 
    {
        public EmptyInputException() : base("Input cannot be empty") 
        {
        
        }
        
    }

    public class StringNotCorrectLengthException : Exception
    {
        public StringNotCorrectLengthException(): base("Input empty or too long")
        {

        }
    }

    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException() : base("Entity already exists in database")
        {

        }
    }

    public class UserIsNotYourFriendException : Exception
    {
        public UserIsNotYourFriendException() : base("User isn't your friend")
        {

        }
    }

}
