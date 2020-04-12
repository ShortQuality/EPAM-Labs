using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_Vector
{
    internal class Vector
    {
        private double x, y, z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }

        public Vector()
        {
            this.x = 0d;
            this.y = 0d;
            this.z = 0d;

        }

        
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            Vector sum = new Vector
            {
                x = vector1.x + vector2.x,
                y = vector1.y + vector2.y,
                z = vector1.z + vector2.z
            };
            return sum;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            Vector sub = new Vector
            {
                x = vector1.x - vector2.x,
                y = vector1.y - vector2.y,
                z = vector1.z - vector2.z
            };
            return sub;
        }

        public static Vector operator*(Vector someVector, double a)
        {
            Vector mult = new Vector
            {
                x = someVector.x * a,
                y = someVector.y * a,
                z = someVector.z * a
            };
            return mult;
        }

        public static double operator *(Vector vector1, Vector vector2)
        {
            double temp = vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
            return temp;
        }

        public static Vector VMult(Vector vector1, Vector vector2)
        {
            Vector VMult = new Vector
            {
                x = vector1.y * vector2.z - vector1.z * vector2.y,
                y = vector1.z * vector2.x - vector1.x * vector2.z,
                z = vector1.x * vector2.y - vector1.y * vector2.x
            };
            return VMult;
        }

        public override string ToString()
        {
            return "(" + x +", " + y + ", " + z + ")";
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            if (Math.Abs(vector1.x) == Math.Abs(vector2.x) && Math.Abs(vector1.y) == Math.Abs(vector2.y) && Math.Abs(vector1.z) == Math.Abs(vector2.z))
                return true;
            else
                return false;
            
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            if (Math.Abs(vector1.x) != Math.Abs(vector2.x) || Math.Abs(vector1.y) != Math.Abs(vector2.y) || Math.Abs(vector1.z) != Math.Abs(vector2.z))
                return true;
            else
                return false;

        }


    }

    internal class Lab9_Vector
    {
        private static void Main(string[] args)
        {
            //Vector vector1 = new Vector(1, 2, 3);
            ////Vector vector2 = VectorEntering(2);
            Entering();
            //Console.WriteLine(vector1);
        }

        public static void Entering()
        {

            string[] temp;
            Vector vector1, vector2;

            char operation;
            double a = 0d;
            char[] sep = { ' ', '(', ',', ')' };
            Console.WriteLine("Enter: ");
            temp = Console.ReadLine().Replace(".", ",").Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
            if(temp.Length != 0 && temp.Length == 7)
            {
                vector1 = new Vector(Convert.ToDouble(temp[0]), Convert.ToDouble(temp[1]), Convert.ToDouble(temp[2]));
                operation = Convert.ToChar(temp[3]);
                vector2 = new Vector(Convert.ToDouble(temp[4]), Convert.ToDouble(temp[5]), Convert.ToDouble(temp[6]));
                Calculator(vector1, operation, vector2);
            }
            else if(temp.Length != 0 && temp.Length == 5 && temp[3] == "*")
            {
                vector1 = new Vector(Convert.ToDouble(temp[0]), Convert.ToDouble(temp[1]), Convert.ToDouble(temp[2]));
                operation = Convert.ToChar(temp[3]);
                a = Convert.ToDouble(temp[4]);
                Calculator(vector1, operation, a);
            }
            Console.Read();
        }

        public static void Calculator(Vector vector1, char operation, Vector vector2 )
        {
            //Console.WriteLine("Enter operation: ");
            //string[] operation = Console.ReadLine().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
           
            
                switch (operation)
                {

                    case '+':
                    Vector Sum = vector1 + vector2;
                    Console.WriteLine("Sum = " + Sum);
                        break;
                    case '-':
                    Vector Sub = vector1 - vector2;
                    Console.WriteLine("Subtraction = " + Sub);
                        break;
                    case '*':
                    double Mult = vector1 * vector2;
                    Console.WriteLine("Scalar Mult = " + Mult);
                        break;
                    case 'v':
                    Console.WriteLine("Vectors Mult = " + Vector.VMult(vector1, vector2));
                        break;
                    case '=':
                        if(vector1 == vector2)
                        {
                            Console.WriteLine("Equal");
                        }
                        else
                        {
                            Console.WriteLine("Not Equal");
                        }
                        break;
                }
           if(operation == '+' || operation == '-' || operation == '*' || operation == 'v' || operation == '=')
            {

            }
           else
            {
                Console.WriteLine("WRONG OPERATION!");
            }

        }

        public static void Calculator(Vector vector1, char operation, double a)
        {
            //Console.WriteLine("Enter operation: ");
            //string[] operation = Console.ReadLine().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);


            switch (operation)
            {

                
                case '*':
                    Vector Mult = vector1 * a;
                    Console.WriteLine("Mult = " + Mult);
                    break;
               
            }
            if (operation == '*')
            {

            }
            else
            {
                Console.WriteLine("WRONG OPERATION!");
            }

        }
    }


    
}
