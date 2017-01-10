using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OpenClosedDependencyInversion
{
    //public class TradeController // INEFFICENT VERSION, REQUIRES UPDATING AND ADDING NEW CLASSES EVERYTIME STOCK GETS A NEW CLASS
    //{
    //    public void TradeShares(Share share)
    //    {
    //        //Do Stuff
    //    }

    //    public void TradeBond(Bond bond)
    //    {
    //        //Do Stuff
    //    }

    //    public void TradeFex(ForeignEx fx)
    //    {
    //        //Do Stuff
    //    }
    //}

    public class DependencyInversionTradeController // NO NEED TO CHANGE ANYTHING IN TRADECONTROLLER WHEN ADDING NEW CLASSES FOR STOCK, SAVES TIME AND REDUCE CODE
    {
        public void Trade(Stock stock)
        {
            //Do Stuff
        }
    }
}
