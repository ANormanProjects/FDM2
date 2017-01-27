using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
using System;
namespace Factory
    {

     /// The 'Product' interface

     public interface IFactory
     {
     void Drive(int miles);
     }
 

     /// A 'ConcreteProduct' class

     public class Scooter : IFactory
     {
     public void Drive(int miles)
     {
     Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
     }
     }
 

     /// A 'ConcreteProduct' class

     public class Bike : IFactory
     {
     public void Drive(int miles)
     {
     Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
     }
     }
 

     /// The Creator Abstract Class

     public abstract class VehicleFactory
     {
     public abstract IFactory GetVehicle(string Vehicle);
 
     }
 

     /// A 'ConcreteCreator' class

     public class ConcreteVehicleFactory : VehicleFactory
     {
         public override IFactory GetVehicle(string Vehicle)
         {
             switch (Vehicle)
             {
                 case "Scooter":
                     return new Scooter();
                 case "Bike":
                     return new Bike();
                 default:
                     throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
             }
         }
     }
     }
}
