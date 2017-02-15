using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Logic
{
    public interface IBasketLogic
    {
        void getAllItemsInBasket();
        void addItemToBasket();        
    }
}
