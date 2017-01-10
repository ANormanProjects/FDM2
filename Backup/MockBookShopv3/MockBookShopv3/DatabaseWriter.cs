using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockBookShopv3
{
    public interface DatabaseWriter
    {
        void WriteDatabase(Book bookToAdd);
    }
}
