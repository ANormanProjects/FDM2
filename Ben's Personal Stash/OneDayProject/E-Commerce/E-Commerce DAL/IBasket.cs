using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_DAL
{
    public interface IBasket
    {
        int basketId { get; set; }

        string basketName { get; set; }

        ICollection<Item> itemsInBasket { get; set; }
    }
}
