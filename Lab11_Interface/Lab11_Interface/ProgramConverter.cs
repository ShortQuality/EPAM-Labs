using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab11_Interface
{
    public class ProgramConverter : IConvertible
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
        
        public string ConvertToCSharp(string text)
        {
            string[] CSharpLines = CShExampleIn();
            string[] VBLines = VBExampleIn();
            bool VBFlag = false;
            bool CShFlag = false;
            int indx = 0;
            for (int i = 0; i < CSharpLines.Length; i++)
            {
                if (text == CSharpLines[i])
                {
                    CShFlag = true;
                    indx = i;
                    break;
                }
                else if (text == VBLines[i])
                {
                    VBFlag = true;
                    indx = i;
                    break;
                }
                //else
                //{
                //    CShFlag = VBFlag = false;
                //    indx = -1;
                //}
            }

            if (CShFlag)
            {

                return text;
            }
            else if (VBFlag)
            {
                return text = CSharpLines[indx]; ;
            }

            return "";
        }

        public string ConvertToVB(string text)
        {
            string[] CSharpLines = CShExampleIn();
            string[] VBLines = VBExampleIn();
            bool VBFlag = false;
            bool CShFlag = false;
            int indx = 0;
            for (int i = 0; i < CSharpLines.Length; i++)
            {
                if (text == CSharpLines[i])
                {
                    CShFlag = true;
                    indx = i;
                    break;
                }
                else if (text == VBLines[i])
                {
                    VBFlag = true;
                    indx = i;
                    break;
                }
                //else
                //{
                //    CShFlag = VBFlag = false;
                //    indx = -1;

                //}
            }

            if (CShFlag)
            {
                text = VBLines[indx];
                return text;
            }
            else if (VBFlag)
            {
                return text;
            }

            return "";
        }
    }
}
