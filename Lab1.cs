using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

                            //7 variant of tasks.
namespace ThirdLesson
{
    class Lab1
    {
        static double Compose(double a, double b)
        {
            return a * b; ;
        }

        static void Enter_of_values(out double a, out double b)
        {
            try
            {
            string[] arr;
            arr = Console.ReadLine().Split(' ');
            a = Convert.ToDouble(arr[0]);
            b = Convert.ToDouble(arr[1]);
            }
            catch
            {
                a = b = 0;
                Console.WriteLine("Incorrect enter");
            }            
        }

        
        static void Main(string[] args)
        {
             Enter_of_values(out double a, out double b);
             Console.WriteLine(Compose(a, b));
        }
    }
}