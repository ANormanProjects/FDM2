using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillars.Abstraction // Hides COMPLEXITY 
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection dbConnection = new OracleDatabaseConnection();
            dbConnection.ConnectToDatabase("DatabaseAddress");

            Console.ReadLine();
        }
        
    }

}
