using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Задание(7 вариант):
//Дан текстовый файл Inlet.in, содержащий строковые величины S.В последней его строке находится
//целочисленная величина k.
//
//Определить количество слов этой величины длиной не меньшей, чем k. Если этого сделать нельзя, в ка-
//честве ответа выдать значение –1.

namespace Lab6_string_Var7
{
    class Lab6_string_Var7
    {
        static void EnteringMethodSelection(out char enteringMethod)
        {

            Console.WriteLine("What method of entering you waant? Command Line(0)/File(1)");
            enteringMethod = Convert.ToChar(Console.ReadLine());
        }

        static void Text_F_entering(out string[] tempLine, out int n, out int k)
        {
            try
            {
                using (StreamReader fr = new StreamReader(@"IO\Inlet.in"))
                {
                    
                    char[] lineSep = { '\n', '\r' };
                    tempLine = fr.ReadToEnd().Split(lineSep, System.StringSplitOptions.RemoveEmptyEntries);
                    n = tempLine.Length - 1;
                    k = Int32.Parse(tempLine[n]);
                    
                    
                    Console.WriteLine("Successful reading.");
                }
            }
            catch (Exception ex)
            {
                n = k = 0;
                tempLine = new string[n];
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Unsuccessful reading!");
            }
        }

        static void Text_F_output(int count)
        {
            try
            {
                using (StreamWriter fw = new StreamWriter(@"IO\Outlet.out"))
                {
                    fw.WriteLine(count);
                    Console.WriteLine("Succesful writing.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Unsuccesful writing!");
            }
        }
        
        static void Text_C_entering(out string[] tempLine, out int n, out int k)
        {
            try
            {
                int count = 0;
                string s;
                string[] tempLine_2; 
                Console.WriteLine("Enter value of word length:");
                k = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter strings:");
                tempLine = new string[count]; 

                do
                {
                    s = Console.ReadLine().Replace("  ", " ").Trim(' ');
                    if (s != "")
                    { 
                        count++;
                        tempLine_2 = new string[count];

                        for (int i = 0; i < tempLine_2.Length - 1; i++)
                        {
                            tempLine_2[i] = tempLine[i];
                        }

                        tempLine_2[count - 1] = s;
                        tempLine = tempLine_2;
                    }
                } while (s != "");
                n = tempLine.Length;
            }
            catch(Exception ex)
            {
                n = k = 0;
                tempLine = new string[n];
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine();
            }
        }

        static int WordCounter(string[] tempLine, int n, int k)
        {
            int count = 0;
            char[] wordSep = { ' ' };
            for(int i = 0; i < n; i++)
            {
                string[] i_word = tempLine[i].Split(wordSep, System.StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < i_word.Length; j++)
                {
                    int wordLength = 0;
                    foreach(char letter in i_word[j])
                    {
                        wordLength++;
                    }
                    if(wordLength >= k)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            EnteringMethodSelection(out char enteringMethod);
            if (enteringMethod == '0')
            {
                Text_C_entering(out string[] tempLine, out int n, out int k);
                int answer = WordCounter(tempLine, n, k);
                Console.WriteLine("Count of word: " + Convert.ToString(answer));
            }
            else if (enteringMethod == '1')
            {
                Text_F_entering(out string[] tempLine, out int n, out int k);
                int answer = WordCounter(tempLine, n, k);
                Text_F_output(answer);
            }
        }
    }
}
