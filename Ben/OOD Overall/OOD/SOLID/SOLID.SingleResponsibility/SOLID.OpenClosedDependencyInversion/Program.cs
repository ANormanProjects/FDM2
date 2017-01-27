using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OpenClosedDependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            //TradeController tradecontroller = new TradeController();
            //tradecontroller.TradeBond(new Bond());
            //tradecontroller.TradeShares(new Share());

            DependencyInversionTradeController dptc = new DependencyInversionTradeController(); //DEPENDENCY INVERSION LINKS TO TRADECONTROLLER TO CALL STOCK METHODS
            dptc.Trade(new Bond()); //Trade linkts to trade method in tradecontroller (new Bond) links to stock abstract class and subclasses methods
            dptc.Trade(new Share());
            dptc.Trade(new ForeignEx());
            dptc.Trade(new Exchange());


        }
    }
}
