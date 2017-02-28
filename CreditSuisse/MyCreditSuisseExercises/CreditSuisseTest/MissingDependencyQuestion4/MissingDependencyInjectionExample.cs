using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingDependencyQuestion4
{
    class MissingDependencyInjectionExample  // No Dependency Injection
    {
        public MissingDependencyInjectionExample()
        {

        }

        //Notify Per Email
        public void Notify(string message)
        {
            INotificationAction action; 

            if (Config.isdebug == true)
            {
                action = new EmailSenderMock();
            }
            else
            {
                action = new EmailSender();
            }
            action.ActOnNotification(message);
        }
    }

}
