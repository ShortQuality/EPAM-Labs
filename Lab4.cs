using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

                                //Solution of 7 variant of KMV-cycles tasks.
namespace Lab4
{
    class Lab4
    {
        static void Values_Entering(out double x, out double accuracy)
        {
            try
            {
                Console.WriteLine("Enter values: ");
                string[] temp_arr = Console.ReadLine().Split(' ');
                x = Convert.ToDouble(temp_arr[0]);
                accuracy = Convert.ToDouble(temp_arr[1]);
            }
            catch
            {
                x = accuracy = 0;
                Console.WriteLine("Incorrect enter");
                Values_Entering(out x, out accuracy);
            }
        }

        static double Solving(double x, double accuracy)
        {
            double sum = 0;
            int n = 0;
            while ( Math.Abs(Math.Pow(x, 2 * n) / Fact(2 * n)) > accuracy)
            {
                sum += Math.Pow(x, 2 * n) / Fact(2 * n);
                n++;
            }
            return sum;
        }

        static Double Fact(Double Digit)
        {
            Double temp = Digit;
            if (Digit == 0) return 1;
            else
            {
                for (int i = 1; i < Digit; i++)
                {
                    temp *= i;
                }
                return temp;
            }
        }

        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Values_Entering(out double x, out double accuracy);
            Console.Write(Solving(x, accuracy));
        }
    }
}
