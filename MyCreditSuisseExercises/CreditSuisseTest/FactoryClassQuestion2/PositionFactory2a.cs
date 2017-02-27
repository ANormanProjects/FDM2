using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryClassQuestion2
{
    public class PositionFactory2a
    {
        public Position CreateNewPosition(int id)
        {
            switch (id)
            {
                case 0: return new Manager();
                case 1: return new Clerk();
                case 2: return new Clerk();
                case 3: return new Programmer();
                default: throw new EntityNotFoundException();
            }            
        }
    }
}
