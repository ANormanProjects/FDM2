using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_DAL
{
    public class Basket : IBasket
    {
        private int _basketId;

        public int basketId
        {
            get { return _basketId; }
            set { _basketId = value; }
        }

        private string _basketName;

        public string basketName
        {
            get { return _basketName; }
            set { _basketName = value; }
        }

        //private List<Item> _itemsInBasket;

        //public List<Item> itemsInBasket
        //{
        //    get { return _itemsInBasket; }
        //    set { _itemsInBasket = value; }
        //}

        //private ICollection<Item> _itemsInBasket;

        //public ICollection<Item> itemsInBasket
        //{
        //    get { return _itemsInBasket; }
        //    set { _itemsInBasket = value; }
        //}
        
        
    }
}
