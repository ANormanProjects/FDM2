using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator 
    {
        public int Add(string number)
        {
            if (number == "") // TASK 2
            {
                return 0; // TASK 1
            }
            else if (number.Contains(','))
            {
                string[] numbers = number.Split(',');
                int num1 = Convert.ToInt32(numbers[0]);
                int num2 = Convert.ToInt32(numbers[1]);
                return num1 + num2;
            }
            else
            {
                return Convert.ToInt32(number); //Task 3
            }
        }
    }
}
