using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{
    public class InvalidPathException : FormatException
    {
        public InvalidPathException() : base() //Will use format exception
        {

        }

        public InvalidPathException(string message) : base (message)
        {

        }
    }
}
