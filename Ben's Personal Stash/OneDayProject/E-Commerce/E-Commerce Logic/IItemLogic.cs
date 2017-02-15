using E_Commerce_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Logic
{
    public interface IItemLogic
    {
        List<Item> GetAllItems();
        
    }
}
