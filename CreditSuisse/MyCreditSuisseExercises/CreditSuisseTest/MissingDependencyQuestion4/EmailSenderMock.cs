using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingDependencyQuestion4
{
    class EmailSenderMock : INotificationAction
    {
        public void ActOnNotification(string message)
        {
            Console.WriteLine("Email was sent!");
        }
    }
}
