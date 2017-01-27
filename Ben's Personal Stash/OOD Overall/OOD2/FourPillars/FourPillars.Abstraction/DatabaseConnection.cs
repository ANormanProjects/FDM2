using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars.Abstraction
{
    abstract class DatabaseConnection
    {
        public abstract void ConnectToDatabase(string databaseAddress);
    }

    class OracleDatabaseConnection : DatabaseConnection
    {
        public override void ConnectToDatabase(string databaseAddress)
        {
            Console.WriteLine("Opening connection to Oracle Database");
        }
    }

    class MicrosoftDatabaseConnection : DatabaseConnection
    {
        public override void ConnectToDatabase(string databaseAddress)
        {
            Console.WriteLine("Opening connection to Microsoft Database");
        }
    }
}
