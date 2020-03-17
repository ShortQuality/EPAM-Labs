using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                string[] temp_arr = Console.ReadLine().Replace(',','.').Split(' ');

                x = Convert.ToDouble(temp_arr[0]);
                accuracy = Convert.ToDouble(temp_arr[1]);
            }
            catch(Exception ex)
            {
                x = accuracy = 0;
                //MessageBox.Show(ex.Message);
                Console.WriteLine("Incorrect enter");
                Console.WriteLine(ex.Message);
                Values_Entering(out x, out accuracy);
            }
        }

        static double Solving(double x, double accuracy)
        {
            double sum = 0;
            int n = 0;
            double temp = 1;
            double curr = 1;
            while (Math.Abs(curr) > accuracy)
            {
                if (n == 0)
                {
                    temp = 1;
                }
                else
                {
                    temp *= ((2 * n) * (2 * n - 1));
                }
                curr = Math.Pow(x, 2 * n) / temp;
                if (curr < accuracy) break;
                sum += Math.Pow(x, 2 * n) / temp;
                n++;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Values_Entering(out double x, out double accuracy);
            Console.Write(Solving(x, accuracy));
        }
    }
}
