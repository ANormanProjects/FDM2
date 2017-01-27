using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        //6)	Write a method that takes in a LinkedList and returns a LinkedList object 
        //      containing a copy of the first list, but in reverse order.

        static void Main(string[] args)
        {
            Console.WriteLine("LinkedList Reversed: ");
            LinkedList<int> linkedlist = new LinkedList<int>();
            linkedlist.AddLast(1);
            linkedlist.AddLast(2);
            linkedlist.AddLast(3);
            linkedlist.AddLast(4);
            linkedlist.AddLast(5);
            linkedlist.AddLast(6);

            foreach (int number in ReverseLinkedList(linkedlist))
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }

        private static LinkedList<int> ReverseLinkedList(LinkedList<int> list)
        {
            return new LinkedList<int>(list.Reverse());
        }

    }

            //    string[] ben = { "ben", "ben", "ben", "ben", "ben", "ben", "ben", "ben", "ben", "ben"};

            //foreach (string line in ben)
            //{
            //Console.WriteLine(line);
            //Console.ReadKey();
            //}
}
