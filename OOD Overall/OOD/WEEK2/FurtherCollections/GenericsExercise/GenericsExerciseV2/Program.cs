using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExerciseV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop<Axe> axe = new Shop<Axe>();
            Axe axe1 = new Axe();

            axe1.id = 1;
            axe1.name = "Cleaver";
            axe1.blades = 2;

            axe.AddWeapon(axe1);

            Console.WriteLine(axe.FindWeapon(1).blades + " " + axe.FindWeapon(1).name);
            Console.ReadKey();


            
        }
    }
}
