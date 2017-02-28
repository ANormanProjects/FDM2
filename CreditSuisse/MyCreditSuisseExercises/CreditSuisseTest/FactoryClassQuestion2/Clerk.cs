using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryClassQuestion2
{
    public class Clerk : Position
    {
        public override string Title
        {
            get { return "Clerk"; }
        }
    }
}
