using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASYNCExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync();
            Console.ReadLine();

        }

        public async static void MainAsync() //Must be async to use await keyword to remove previous errors
        {
            string data = await AccessTheWeb();
            Console.WriteLine(data);
        }

        public async static Task<string> AccessTheWeb()
        {
            DoWork();
            await Task.Delay(5000); //delay for 5000ms
            string returnedData = "Done!";
            return returnedData;
        }

        public static void DoWork()
        {
            Console.WriteLine("Working...");
        }
    }
}
