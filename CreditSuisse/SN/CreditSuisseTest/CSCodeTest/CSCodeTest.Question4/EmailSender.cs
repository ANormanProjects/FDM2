using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeTest.Question4
{
    public class EmailSender : INotificationAction
    {
        public void ActOnNotification(string message)
        {
            // Send real email
        }
    }
}
