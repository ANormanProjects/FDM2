using EntityFrameworkDemo.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //THIS IS FOR DATABASEFIRST

            //EFDatabaseFirstEntities context = new EFDatabaseFirstEntities();

            //foreach (Broker broker in context.Brokers)
            //{
            //    Console.WriteLine(broker.name);
            //}
            //Console.ReadLine();

            //THIS IS FOR CODEFIRST

            CodeFirstModel context = new CodeFirstModel();


            //Add
            //Broker newBroker = new Broker() { name = "Bishan", companyId = 1 };
            //context.brokers.Add(newBroker);


            //Update
            //Broker brokerToUpdate = context.brokers.Find(1);
            //brokerToUpdate.name = "Ben";


            //Remove
            //foreach (Broker broker in context.brokers)
            //{
            //    if (broker.id == 3)
            //    {
            //        context.brokers.Remove(broker);
            //    }
            //}


            //context.SaveChanges();

            //foreach (Broker broker in context.brokers)
            //{
            //    Console.WriteLine(broker.name, broker.companyId);
            //}


            //LINQ SQL
            var query = from b in context.brokers
                        where b.companyId == 1
                        select b;

            foreach (var broker in query)
            {
                Console.WriteLine(broker.name + " " + broker.companyId);
            }


            Console.ReadLine();

        }
    }
}
