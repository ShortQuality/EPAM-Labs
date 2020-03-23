using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vectors
{
    class Lab5_Vectors_Var7
    {
        static void Value_Fentering(out int[] array, out int n)
        {
            try
            {
                using (StreamReader fr = new StreamReader(@"IO\Inlet.in"))
                {
                    string[] temp1;
                    string temp2;
                    temp1 = fr.ReadLine().Split(' ');
                    n = Convert.ToInt32(temp1[0]);
                    array = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        temp2 = fr.ReadLine();
                        array[i] = Int32.Parse(temp2);
                    }
                }
                Console.WriteLine("Successful reading.");
            }
            catch (Exception ex)
            {
                n = 0;
                array = new int[n];
                Console.WriteLine(ex.Message);

            }
        }

        static void Value_Foutput(int odd_amount)
        {
            try
            {
                using (StreamWriter fw = new StreamWriter(@"IO\Outlet.out", false, System.Text.Encoding.Default))
                {
                    string output_string = "";
                    output_string += odd_amount;
                    fw.Write(output_string);
                }
                Console.WriteLine("Successful writing.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Value_Centering(out int[] array, out int n)
        {
            try
            {
                Console.WriteLine("Enter value \"N\" of array");
                n = Convert.ToInt32(Console.ReadLine());
                
                     Console.WriteLine("Enter array:");
                     string[] tempArray = Console.ReadLine().Replace("  ", " ").Split(' ');

                     array = new int[n];

                     for(int i = 0; i < n; i++)
                     {
                         array[i] = Convert.ToInt32(tempArray[i]);
                     }
            }
            catch (Exception ex)
            {
                n = 0;
                array = new int[n];
                Console.WriteLine(ex.Message);
            }
        }


        static void EnteringMethodSelection(out char enteringMethod)
        {
           
            Console.WriteLine("What method of entering you waant? F/C");
            enteringMethod = Convert.ToChar(Console.ReadLine());
        }

        static int CalculateOf_Odd(int[] array)
        {
            int odd_amount = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] % 2 != 0)
                {
                    odd_amount++;
                }
            }
            return odd_amount;
        }

        static void Main(string[] args)
        {
            EnteringMethodSelection(out char enteringMethod);
            if(enteringMethod == 'F'|| enteringMethod == 'f')
            {
                Value_Fentering(out int[] array, out int n);
                Value_Foutput(CalculateOf_Odd(array));

            }
            else if(enteringMethod == 'C' || enteringMethod == 'c')
            {
                Value_Centering(out int[] array, out int n);
                Console.WriteLine("Amount Of Odd numbers: " + CalculateOf_Odd(array));
            }
        }
    }
}
