using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview1
{
    public class Basket
    {
        public List<Item> SelectedItems { get; set; }

        public Customer customer { get; set; }

        public Store store { get; set; }
                
        public Basket(Customer cust, Store st) // CONSTRUCTOR
        {
            SelectedItems = new List<Item>();
            customer = cust;
            store = st;
        }

        public void addSelectedItem(Item i)  //CHECKING TO SEE IF ITEM EXISTS IN STORE
        {
            if (store.getItems().Contains(i) == true)
            {
                SelectedItems.Add(i);
            }

        }

        public List<Item> getAllSelectedItems()  //STORING SELECTED ITEMS FOR CALCULATION OF TOTALPRICE IN CHECKOUT
        {
            return SelectedItems;
        }

        public void removeSelectedItem(Item it)
        {
            SelectedItems.Remove(it);
        }

        
    }
}
