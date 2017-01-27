using FourPillars.Inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars.Inheritance
{
    interface DatabaseConnection
    {
        bool OpenConnectionToDatabase(string url);
    }

    public class MicrosoftDbConnection : DatabaseConnection
    {
        public bool OpenConnectionToDatabase(string url)
        {
            return true;
        }
    }
    class OracleDbConnection : DatabaseConnection
    {
        public bool OpenConnectionToDatabase(string url)
        {
            return false;
        }
    }
}
