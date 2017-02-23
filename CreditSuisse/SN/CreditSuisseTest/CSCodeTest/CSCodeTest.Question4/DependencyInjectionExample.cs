using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeTest.Question4
{
    public class DependencyInjectionExample
    {
        /// <summary>
        /// Action to take
        /// </summary>
        public INotificationAction Action { get; set; }

        public DependencyInjectionExample(INotificationAction action)
        {
            this.Action = action;
        }

        public void Notify(string message)
        {
            Action.ActOnNotification(message);
        }
    }
}
