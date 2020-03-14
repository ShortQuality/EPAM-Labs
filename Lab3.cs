using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

                        //Solution of 7 variant of I-cycles tasks.
namespace Lab3
{
    class Lab3
    {
        static void Values_Entering(out double a, out double b, out double accuracy)
        {
            try
            {
                Console.WriteLine("Enter values: ");
                string[] temp_arr = Console.ReadLine().Split(' ');
                a = Convert.ToDouble(temp_arr[0]);
                b = Convert.ToDouble(temp_arr[1]);
                accuracy = Convert.ToDouble(temp_arr[2]);
            }
            catch
            {
                a = b = accuracy = 0;
                Console.WriteLine("Incorrect enter");
                Values_Entering(out a, out b, out accuracy);
            }
        }

        static double f(double x)
        {
            return x + Math.Sqrt(x) + Math.Pow(x, 1d / 3) - 2.5;
        }

        static double f_FirstDeriv(double x)
        {
            return 1d + 1d / (2 * Math.Sqrt(x)) + 1 / (3 * Math.Pow(x * x, 1d / 3));
        }

        static double f_SecondDeriv(double x)
        {
            return -(1d / (4 * x * Math.Sqrt(x))) - 2d / (9 * x * Math.Pow(x * x, 1d / 3));
        }

        static double InitApprox(double a, double b)
        {
            return f(a) * f_SecondDeriv(a) > 0 ? a : b;
        }

        static void Solving (double a, double b, double accuracy)
        {
            double approx = InitApprox(a, b);
            while (Math.Abs(f(approx)) > accuracy)
            {
                approx -= f(approx) / f_FirstDeriv(InitApprox(a, b));
            }
            Console.Write(approx);
        }

        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Values_Entering(out double a, out double b, out double accuracy);
            Solving(a, b, accuracy);
        }
    }
}
