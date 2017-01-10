using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public interface DatabaseWriter
    {
        void WriteDatabase(Book bookToAdd);
    }
}
