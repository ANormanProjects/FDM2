using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockBookShopv3
{
    public interface IDatabaseWriter
    {
        void WriteDatabase(Book bookToAdd);
    }
}
