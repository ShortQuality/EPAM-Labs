using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_Generics_Serialize
{
    [Serializable]
    public class Vector : IComparable<Vector>
    {
        public double x, y, z;
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

        public static Vector operator *(Vector someVector, double a)
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

        public double Abs()
        {
            return Math.Abs(x * x + y * y + z * z);
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }

        public int CompareTo(Vector obj) //////////////////////////////////////////////////////////////////////// CompareTO \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        {
            if (this > obj)
                return 1;
            if (this < obj)
                return -1;
            else
                return 0;
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

        public static bool operator <(Vector firstV, Vector secondV)
        {
            return (firstV.Abs() < secondV.Abs());
        }

        public static bool operator >(Vector firstV, Vector secondV)
        {
            return (firstV.Abs() > secondV.Abs());
        }
    }
}
