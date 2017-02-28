using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingDependencyQuestion4
{
    public class DependencyInjectionExample
    {
        public INotificationAction Action { get; set; }

        public DependencyInjectionExample(INotificationAction action)
        {
            this.Action = action;
        }

        public void Notify (string message)
        {
            Action.ActOnNotification(message);
        }
    }
}
