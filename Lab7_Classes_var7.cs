using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Разработать класс геометрической фигуры РОМБ, заданной на плоскости линейными размерами.

namespace Lab7_Classes_var7
{
    class Rhomb
    {
        private readonly double angle;
        private readonly double sideLength;

        public double Square { get; private set; }

        public double Perimetr { get; private set; }

        public Rhomb(double angle, double sideLength)
        {
            this.angle = angle * Math.PI / 180;
            this.sideLength = sideLength;
        }

        public void SquareFinding()
        {
            Square = sideLength * sideLength * Math.Sin(angle); // S = a^2 * sin(α), где а - длина стороны ромба, α - величина угла.
        }

        public void PerimetrFinding()
        {
            Perimetr = 4 * sideLength; // P = 4 * a, где а - длина стороны ромба.
        }
        
    }

    class Lab7_Classes_var7
    {
        static void Entering(out double angle, out double sideLength)
        {
            try
            {
                Console.WriteLine("Enter angle: ");
                angle = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Length of Side: ");
                sideLength = Convert.ToDouble(Console.ReadLine());
            }
            catch(Exception ex)
            {
                angle = sideLength = 0;
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Incorrect enter.");
            }
        }

        static void Main(string[] args)
        {
            Entering(out double angle, out double sideLength);

            if((angle == 0 || angle > 90 || angle < 0) && (sideLength == 0 || sideLength < 0))
            {
                Console.WriteLine("Incorrect size of angle and side.");
                return;
            }
            if(angle == 0 || angle > 90 || angle < 0)
            {
                Console.WriteLine("Incorrect size of angle.");
                return;
            }
            if (sideLength == 0 || sideLength < 0)
            {
                Console.WriteLine("Incorrect size of side.");
                return;
            }

            Rhomb myRhomb = new Rhomb(angle, sideLength);

            myRhomb.PerimetrFinding();
            myRhomb.SquareFinding();

            Console.WriteLine("Square: " + Convert.ToString(myRhomb.Square));
            Console.WriteLine("Perimetr: " + Convert.ToString(myRhomb.Perimetr));
        }
    }
}
