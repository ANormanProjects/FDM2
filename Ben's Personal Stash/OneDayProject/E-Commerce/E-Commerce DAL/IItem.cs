using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_DAL
{
    public interface IItem
    {
        int id { get; set; }

        string name { get; set; }
    }
}
