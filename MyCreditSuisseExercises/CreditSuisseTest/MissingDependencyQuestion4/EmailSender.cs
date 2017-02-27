
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingDependencyQuestion4
{
    class EmailSender : INotificationAction
    {
        public void ActOnNotification(string message)
        {
            //Actual Code To Send A Real Email
        }
    }
}
