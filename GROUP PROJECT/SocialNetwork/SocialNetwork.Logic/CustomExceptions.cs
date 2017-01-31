using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic
{
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
}
