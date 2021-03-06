﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

                                  //Solution of 7 variant of A-cycles tasks.
namespace Lab2
{
    class Lab2
    {
        static void Enter_of_values(out double n, out double x)
        {
                string[] arr;
            try
            {
                arr = Console.ReadLine().Replace(',', '.').Split(' ');
                n = Convert.ToInt32(arr[0]);
                x = Convert.ToDouble(arr[1]);
            }
            catch
            {
                x = n = 0;
                Console.WriteLine("Incorrect enter");
            }
        }

        static double Summary(double n, double x)
        {
            double sum = 0;
            double temp = 1;
            for(int i = 0; i <= n; i++)
            {
                if(i == 0)
                {
                    temp = 1;
                }
                else
                {
                    temp *= i;
                }
                sum += ((2*i + 1) * Math.Pow(x, 2*i)) / temp;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Enter_of_values(out double n, out double x);
            Console.WriteLine(Summary(n, x));
        }
    }
}