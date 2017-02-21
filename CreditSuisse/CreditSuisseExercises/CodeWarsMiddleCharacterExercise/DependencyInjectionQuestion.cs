using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseExercises
{
    internal static class Config
    {
        static public bool isdebug = true;
    }

    public interface INofificationAction
    {
        void ActOnNotification(string message);
    }

    public class EmailSender : INofificationAction
    {
        public virtual void ActOnNotification(string message)
        {
            // Actual code to send a real email
        }
    }

    public class EmailSenderMock : INofificationAction
    {
        public virtual void ActOnNotification(string message)
        {
            Console.WriteLine("Email was sent!");
        }
    }

    // -------------  NO Dependency injection

    public class MissingDependencyInjectionExample
    {
        INofificationAction action;

        public MissingDependencyInjectionExample(INofificationAction action)
        {
            this.action = action; 
        }

        // Notify per email
        public void Notify(string message)
        {
            action.ActOnNotification(message);
        }
    }

}
