using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab11_Interface
{
    interface IConvertible
    {
        string ConvertToCSharp(string text);
        string ConvertToVB(string text);
    }

    public interface ICodeChecker
    {
        bool ChekCodeSyntax(string codeLine, string codeLang);
    }

    public class ProgrammHelper : ProgramConverter, ICodeChecker
    {
        private string[] VBExampleIn()
        {
            string[] VBLines;
            using (StreamReader fr = new StreamReader(@"text\VB_Example.txt"))
            {
                char[] sep = { '\r', '\n' };
                VBLines = fr.ReadToEnd().Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
                return VBLines;
            }
        }

        private string[] CShExampleIn()
        {
            string[] CShLines;
            using (StreamReader fr = new StreamReader(@"text\CSharp_Example.txt"))
            {
                char[] sep = { '\r', '\n' };
                CShLines = fr.ReadToEnd().Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
                return CShLines;
            }
        }

        ////private void Lines_In()
        ////{

        ////}

        //public string ConvertToCSharp(string text)
        //{
        //    string[] CSharpLines = CShExampleIn();
        //    string[] VBLines = VBExampleIn();
        //    bool VBFlag = false;
        //    bool CShFlag = false;
        //    int indx = 0;
        //    for (int i = 0; i < CSharpLines.Length; i++)
        //    {
        //        if (text == CSharpLines[i])
        //        {
        //            CShFlag = true;
        //            indx = i;
        //        }
        //        else if (text == VBLines[i])
        //        {
        //            VBFlag = true;
        //            indx = i;
        //        }
        //        else
        //        {
        //            CShFlag = VBFlag = false;
        //            indx = -1;
        //        }
        //    }

        //    if (CShFlag)
        //    {

        //        return text;
        //    }
        //    else if (VBFlag)
        //    {
        //        return text = CSharpLines[indx]; ;
        //    }

        //    return "";
        //}

        //public string ConvertToVB(string text)
        //{
        //    string[] CSharpLines = CShExampleIn();
        //    string[] VBLines = VBExampleIn();
        //    bool VBFlag = false;
        //    bool CShFlag = false;
        //    int indx = 0;
        //    for (int i = 0; i < CSharpLines.Length; i++)
        //    {
        //        if (text == CSharpLines[i])
        //        {
        //            CShFlag = true;
        //            indx = i;
        //        }
        //        else if(text == VBLines[i])
        //        {
        //            VBFlag = true;
        //            indx = i;
        //        }
        //        else
        //        {
        //            CShFlag = VBFlag = false;
        //            indx = -1;
        //        }
        //    }

        //    if(CShFlag)
        //    {
        //        text = VBLines[indx];
        //        return text;
        //    }
        //    else if(VBFlag)
        //    {
        //        return text;
        //    }

        //    return "";
        //}

        public bool ChekCodeSyntax(string codeLine, string codeLang)
        {
            string[] CSharpLines = CShExampleIn();
            string[] VBLines = VBExampleIn();
            bool VBFlag = false;
            bool CShFlag = false;
            for (int i = 0; i < CSharpLines.Length; i++)
            {
                if (codeLine == CSharpLines[i] && (codeLang == "CSHARP" || codeLang == "CS" || codeLang == "C#"))
                {
                    CShFlag = true;
                    break;
                }
                else if (codeLine == VBLines[i] && (codeLang == "VISUALBASIC" || codeLang == "VB"))
                {
                    VBFlag = true;
                    break;
                }
                //else
                //{
                //    CShFlag = VBFlag = false;
                //}
            }

            if (CShFlag)
            {
                return CShFlag;
            }
            else if (VBFlag)
            {
                return VBFlag;
            }
            return false;
        }
    }

    class Lab11_Interface
    {
        static void Main(string[] args)
        {
            ProgramConverter[] a = { new ProgramConverter(), new ProgramConverter(), new ProgrammHelper(), new ProgrammHelper() };
            
            
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] is ICodeChecker)
                {
                    ICodeChecker temp =  a[i] as ICodeChecker;
                    Console.WriteLine("\nInterface ICodeChecker implemented");
                    if (temp.ChekCodeSyntax("Dim x As Integer", "VB"))
                    {
                        Console.WriteLine("Translate VB code \"Dim x As Integer\" to c#: ");
                        Console.WriteLine(a[i].ConvertToCSharp("Dim x As Integer"));
                    }

                    
                }
                
                else
                {
                    Console.WriteLine("\nInterface ICodeChecker not implemented");
                    Console.WriteLine("ConvertToCSharp: " + "Dim x As Integer");
                    Console.WriteLine(a[i].ConvertToCSharp("Dim x As Integer"));
                   
                    Console.WriteLine("ConvertToVB: double y = 4.0; ");
                    Console.WriteLine(a[i].ConvertToVB("double y = 4.0;"));
                }
            }
        }
    }
}
