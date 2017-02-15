using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace E_Commerce_DAL
{
    public class BasketRepository : IBasketRepository
    {
        private static readonly ILog logger = LogManager.GetLogger("BasketRepository.cs");

        E_CommerceDataModel context;

        public BasketRepository(E_CommerceDataModel _context)
        {
            context = _context;
        }

        public BasketRepository()
        {

        }

        public virtual List<Basket> GetAllBaskets()
        {
            return context.baskets.ToList();
        }

        public virtual void addNewBasket(Basket newBasket)
        {
            context.baskets.Add(newBasket);
            context.SaveChanges();
        }

        public virtual void Save()
        {
            context.SaveChanges();
            //logger.info("Changes saved to Database.");
        }
    }
}
