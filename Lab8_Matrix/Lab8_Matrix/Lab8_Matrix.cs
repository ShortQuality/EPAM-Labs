using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab8_Matrix
{
    class Lab8_Matrix : MyIO
    {
        static void Main(string[] args)
        {
            EnteringMethodSelection(out char enteringMethod);
            if (enteringMethod == '0')
            {
                Entering(enteringMethod);
            }
            else if (enteringMethod == '1')
            {
                Entering(enteringMethod);
            }
            else
            {
                Console.WriteLine("Incorrect Method!");
            }
        }

        static void EnteringMethodSelection(out char enteringMethod) //Выбор метода ввода, либо при помощи консоли, либо при помощи файла.
        {
            try
            {
                InformationOut("\nWhat method of entering you want? Command Line(0)/File(1)", "green");
                enteringMethod = Convert.ToChar(Console.ReadLine());
                Console.Clear();
            }
            catch
            {
                enteringMethod = Convert.ToChar(2);
            }

        }
        static void MatrixOperation( Matrix matrix1, Matrix matrix2, int m1, int n1, int m2, int n2) //Метод получает две матрицы и их размеры, выплняет операции сложения или вычитания, или умножения двух матриц.
        {
            string[] operation;
            string[] priority;
            try
            {
                InformationOut("\nEnter operation between matrices: + , - , * ", "DarkMagenta");
                operation = Console.ReadLine().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                if (operation.Length != 0)
                {
                    switch (operation[0])
                    {

                        case "+":

                            InformationOut("\nPlease select the priority matrix in the operation: First matrix(1) or Second matrix(2)/n", "DarkRed");
                            priority = Console.ReadLine().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                            if (priority[0] == "1")
                            {
                                Matrix Sum = new Matrix(m1, n1);
                                Sum = matrix1 + matrix2;
                                InformationOut("Sum of matrix: ", Sum);
                            }
                            else if (priority[0] == "2")
                            {
                                Matrix Sum = new Matrix(m2, n2);
                                Sum = matrix2 + matrix1;
                                InformationOut("Sum of matrix: ", Sum);
                            }
                            else
                            {
                                MyException ex1 = new MyException("Wrong number of priority!");
                                throw ex1;
                            }
                            break;
                        case "-":

                            InformationOut("\nPlease select the priority matrix in the operation: First matrix(1) or Second matrix(2)/n", "DarkRed");
                            priority = Console.ReadLine().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                            if (priority[0] == "1")
                            {
                                Matrix Subtr = new Matrix(m1, n1);
                                Subtr = matrix1 - matrix2;
                                InformationOut("Subtraction of matrix: ", Subtr);
                            }
                            else if (priority[0] == "2")
                            {
                                Matrix Subtr = new Matrix(m2, n2);
                                Subtr = matrix2 - matrix1;
                                InformationOut("Subtraction of matrix: ", Subtr);
                            }
                            else
                            {
                                MyException ex2 = new MyException("Wrong number of priority!");
                                throw ex2;
                            }
                            break;
                        case "*":

                            InformationOut("\nPlease select the priority matrix in the operation: First matrix(1) or Second matrix(2)/n", "DarkRed");
                            priority = Console.ReadLine().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                            if (priority[0] == "1")
                            {
                                Matrix Mult = new Matrix(m1, n2);
                                Mult = matrix1 * matrix2;
                                InformationOut("Multiplication of matrix: ", Mult);
                            }
                            else if (priority[0] == "2")
                            {
                                Matrix Mult = new Matrix(m2, n1);
                                Mult = matrix2 * matrix1;
                                InformationOut("Multiplication of matrix: ", Mult);
                            }
                            else
                            {
                                MyException ex3 = new MyException("ERROR:Wrong number of priority!");
                                throw ex3;
                            }
                            break;
                        default:
                            MyException default_ex = new MyException("ERROR: This operation doesn't exist in this program!");
                            throw default_ex;
                    }
                }
                else
                {
                    MyException ex = new MyException("Incorrect operation!");
                    throw ex;
                }

            }
            catch (MyException ex)
            {
                InformationOut(ex.Message, "Red");
            }

        }
        static void Entering(char inputSource)
        {
            if(inputSource == '0')
            {
                
                InformationOut("\nEnter matrices \n====================\n", "green");
                InformationOut("\nFirst matrix:\n===================\n", "green");
                InformationIn_CommandLine(out Matrix matrix1, out int m1, out int n1);
                InformationOut("\nSecond Matrix:\n==================\n", "green");
                InformationIn_CommandLine(out Matrix matrix2, out int m2, out int n2);

                MatrixOperation(matrix1, matrix2, m1, n1, m2, n2);
            }
            else
            {
                InformationOut("\nRead matrices from a file\n==================\n", "green");
                InformationIn_file(out Matrix matrix1, out Matrix matrix2, out int m1, out int n1, out int m2, out int n2);
                InformationOut("\nFirst matrix:\n===================\n", "green");
                InformationOut(matrix1);
                InformationOut("\nSecond Matrix:\n==================\n", "green");
            
                InformationOut(matrix2);
                MatrixOperation(matrix1, matrix2, m1, n1, m2, n2);
            }
        }
       
    }

    [Serializable]
    public class MyException : ApplicationException  //Класс для исключений.
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception ex) : base(message) { }

        protected MyException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext contex)
        : base(info, contex) { }
    }

    public abstract class MyIO //Класс для ввода двух матриц и вывода информации на экран.
    {
        internal static void InformationOut(string outputString, string color) //Метод в который передается текст для вывода в консоль и цвет данного текста.
        {
            switch(color.ToUpper())
            {
                case "RED":
                Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "GREEN":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "DARKMAGENTA":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "DARKRED":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            Console.WriteLine(outputString);
            Console.ResetColor();
        }

        internal static void InformationOut(string outputString) //Метод в который преедается строка для вывода без указания цвета.
        {
            Console.ResetColor();
            Console.WriteLine(outputString);
        }

        internal static void InformationOut(Matrix matrix)
        {
            int n_Dimension = matrix.Length;
            int m_Dimension = matrix.Height;
            Console.WriteLine("Matrix elements:\n");
            for (int m = 0; m < m_Dimension; m++)
            {
                for (int n = 0; n < n_Dimension; n++)
                {
                    Console.Write("  ");
                    Console.Write(matrix[m, n]);
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal static void InformationOut(string outputString, Matrix matrix)
        {
            int m_Dimension = matrix.Length;
            int n_Dimension = matrix.Height;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + outputString + "\n=======================\n");
            Console.ResetColor();
            for (int m = 0; m < m_Dimension; m++)
            {
                for (int n = 0; n < n_Dimension; n++)
                {
                    Console.Write("  ");
                    Console.Write(matrix[m, n]);
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal static void InformationIn_file(out Matrix matrix1, out Matrix matrix2, out int m1, out int n1, out int m2, out int n2) //Метод считывает с файла две матрицы разделенные пустой строкой,
        {                                                                                                                               // возвращает число строк и столбцов каждой матрицы, возвращает 
                                                                                                                                        //  два заполненных экземплера класса Matrix
            try
            {
                using (StreamReader fr = new StreamReader("Inlet.txt"))
                {
                    string[] matrix1_T;
                    string[] matrix2_T;
                    string[] matrixText;
                    string[] DimensionText1;
                    string[] DimensionText2;

                    char[] lineSep = { '\n', '\r' };
                    matrixText = fr.ReadToEnd().Split(lineSep, System.StringSplitOptions.RemoveEmptyEntries); // Считывание всего файла и построчная запись в массив строк matrixText

                    DimensionText1 = matrixText[0].Split(' ');                  // Считывание размеров первой матрицы c первой строки файла.
                    m1 = Convert.ToInt32(DimensionText1[0]);                    // Число строк первой мтарицы.
                    n1 = Convert.ToInt32(DimensionText1[1]);                    // Число столбцов первой матрицы.

                    DimensionText2 = matrixText[m1 + 1].Split(' ');             // Считывание размеров второй матрицы со строки после первой матрицы.
                    m2 = Convert.ToInt32(DimensionText2[0]);                    // Число строк второй мтарицы.
                    n2 = Convert.ToInt32(DimensionText2[1]);                    // Число столбцов второй матрицы.

                    matrix1 = new Matrix(m1, n1);                               // Создание двухз матриц типа Matrix
                    matrix2 = new Matrix(m2, n2);                               //

                    matrix1_T = new string[m1];                                 // Запись строк первой матрицы 
                    for (int i = 0; i < m1; i++)                                 // в массив строк
                    {                                                           // для последующей записи в экземпляр класса Matrix
                        matrix1_T[i] = matrixText[i + 1];                       // поэлементно.
                    }                                                           //

                    matrix2_T = new string[m2];                                 // Запись строк второй матрицы 
                    for (int k = 0, j = m1 + 2; k < m2; k++, j++)                // в массив строк
                    {                                                           // для последующей записи в экземпляр класса Matrix
                        matrix2_T[k] = matrixText[j];                           // поэлементно.
                    }                                                           // 

                    for (int i = 0; i < m1; i++)                                 //
                    {                                                           //
                        for (int j = 0; j < n1; j++)                             //
                        {                                                       //
                            string[] temp = new string[n1];                     //
                            temp = matrix1_T[i].Split(' ');                     // Разделение строки на отдельные элементы,
                            matrix1[i, j] = Convert.ToDouble(temp[j]);          // конвертация в double и запись в первую матрицу.
                                                                                //
                        }                                                       //
                    }                                                           //

                    for (int i = 0; i < m2; i++)                                //
                    {                                                           //
                        for (int j = 0; j < n2; j++)                            //
                        {                                                       //
                            string[] temp = new string[n1];                     // Разделение строки на отдельные элементы,
                            temp = matrix2_T[i].Split(' ');                     // конвертация в double и запись во вторую матрицу.
                            matrix2[i, j] = Convert.ToDouble(temp[j]);          //
                                                                                //
                        }                                                       //
                    }                                                           //

                    fr.Close();
                    Console.WriteLine("Successful reading.");
                }
            }
            catch (Exception ex)
            {
                n1 = m1 = n2 = m2 = 0;
                matrix1 = new Matrix(m1, n1);
                matrix2 = new Matrix(m2, n2);
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Unsuccessful reading!");
                //fr.Close();

            }

        }

        internal static void InformationIn_CommandLine(out Matrix matrix, out int m, out int n)  //Ввод матрицы при помощи консоли.
        {
            try
            {
                
                string[] dimensions = new string[1];
                string[] temp;
                Console.WriteLine("Enter Dimensions of matrix: \n");
                dimensions[0] = Console.ReadLine();
                temp = dimensions[0].Split(' ');
                m = Convert.ToInt32(temp[0]);
                n = Convert.ToInt32(temp[1]);

                Console.WriteLine("\nEnter elements of matrix: \n");
                matrix = new Matrix(m, n);
                for(int i = 0; i < m; i++)
                {
                    string[] matrixLine;
                    matrixLine = Console.ReadLine().Replace(".", ",").Split((char[])null ,System.StringSplitOptions.RemoveEmptyEntries);
                    if(matrixLine.Length > n)
                    {
                        MyException ex = new MyException("Incorrect length of input string!");
                        throw ex;
                    }
                    else
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = Convert.ToDouble(matrixLine[j]);
                        }
                    }
                   
                }
                Console.WriteLine();

            }
            catch(MyException ex)
            {
                m = n = 0;
                matrix = new Matrix(1, 1);
                matrix.GetEmpty();
                InformationOut(ex.Message + "\n");

            }
            catch(Exception exc)
            {
                m = n = 0;
                matrix = new Matrix(1, 1);
                matrix.GetEmpty();
                Console.ForegroundColor = ConsoleColor.Red;
                InformationOut(exc.Message + "\n");
                Console.ResetColor();
            }
        }
    }

    public class Matrix : MyIO
    {
        private double[,] matrix;
        public int m_line;
        public int n_columns;
        
        public Matrix(int lines = 0, int columns = 0)
        {
            try
            {
                if(lines < 1 || columns < 1)
                {
                    MyException ex = new MyException("Dimensions of the matrix must be greater then 0!");
                    m_line = lines;
                    n_columns = columns;
                    matrix = new double[lines, columns];
                    throw ex;
                }
                else
                {
                    m_line = lines;
                    n_columns = columns;
                    matrix = new double[lines, columns];
                }

            }
            catch(MyException ex)
            {
                InformationOut("\nMatrix creation ERROR!!!\n========================\n", "red");
                InformationOut(ex.Message + "\n", "green");
                
            }
          
        }

        public double this[int m, int n]
        {
            get
            {
                return matrix[m, n];
            }
            set
            {
                matrix[m, n] = value;
            }
        }

        public int Length{  get { return matrix.GetLength(1); } }
        public int Height { get { return matrix.GetLength(0); } }

        public Matrix GetEmpty()
        {
            Matrix temp = new Matrix(m_line,n_columns);
            for (int m = 0; m < m_line; m++)
            {
                for (int n = 0; n < n_columns; n++)
                {
                   temp.matrix[m, n] = 0;
                }
            }
            return temp;
        }
        
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)   //Перегрузка оператора сложения для матриц.
        {
            int m1_Dimension = matrix1.Length;
            int n1_Dimension = matrix1.Height;
            int m2_Dimension = matrix2.Length;
            int n2_Dimension = matrix2.Height;
            try
            {
                if ((m1_Dimension == m2_Dimension) && (n1_Dimension == n2_Dimension))
                {
                    Matrix resMatr = new Matrix(m1_Dimension, n1_Dimension);
                    for (int m = 0; m < m1_Dimension; m++)
                    {
                        for (int n = 0; n < n1_Dimension; n++)
                        {
                           resMatr[m, n] = matrix1[m, n] + matrix2[m, n];
                        }
                    }
                    return resMatr;
                }
                else
                {
                    MyException ex = new MyException(
                         "The dimensions of first matrix is not equal to the dimensions of second matrix!!!\n" +
                         "Dimensions of first matrix: " + m1_Dimension + " " + n1_Dimension + "  \n" +
                         "Dimensions of second matrix: " + m2_Dimension + " " + n2_Dimension);
                    throw ex;
                }
            }
            catch (MyException ex)
            {

                InformationOut("\nAddition ERROR!\n========================\n", "red");
                InformationOut(ex.Message + "\n", "green");

                Matrix result_Matrix = new Matrix(1, 1);
                return result_Matrix.GetEmpty();
            }
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)   //Перегрузка оператора вычитания для матриц.
        {
            int m1_Dimension = matrix1.Height;
            int n1_Dimension = matrix1.Length;
            int m2_Dimension = matrix2.Height;
            int n2_Dimension = matrix2.Length;

            try
            {

                if ((m1_Dimension == m2_Dimension) && (n1_Dimension == n2_Dimension))
                {
                    Matrix resMatr = new Matrix(m1_Dimension, n1_Dimension);
                    for (int m = 0; m < m1_Dimension; m++)
                    {
                        for (int n = 0; n < n1_Dimension; n++)
                        {
                            resMatr[m, n] = matrix1[m, n] - matrix2[m, n];
                        }
                    }
                    return resMatr;
                }
                else
                {
                    MyException ex = new MyException(
                        "The dimensions of first matrix is not equal to the dimensions of second matrix!!!\n" + 
                        "Dimensions of first matrix: " + m1_Dimension + " " + n1_Dimension + "  \n" + 
                        "Dimensions of second matrix: " + m2_Dimension + " " + n2_Dimension);
                    throw ex;
                }
            }
            catch (MyException ex)
            {

                InformationOut("\nSubtraction ERROR!\n========================\n", "red");
                InformationOut(ex.Message + "\n", "green");
                
                Matrix result_Matrix = new Matrix(1, 1);
                return result_Matrix.GetEmpty();
            }
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            int m1_Dimension = matrix1.Height;
            int n1_Dimension = matrix1.Length;
            int m2_Dimension = matrix2.Height;
            int n2_Dimension = matrix2.Length;

            try
            {
                if (n1_Dimension == m2_Dimension)
                {
                    Matrix result_Matr = new Matrix(m1_Dimension, n2_Dimension);
                    for(int m = 0; m < m1_Dimension; m++)
                    {
                        for(int n = 0; n < n2_Dimension; n++)
                        {
                            for(int k = 0; k < n1_Dimension; k++)
                            {
                                result_Matr[m, n] += matrix1[m, k] * matrix2[k, n];
                            }
                        }
                    }
                    return result_Matr;
                }
                else
                {
                    
                    MyException ex = new MyException("\nThe height of first matrix is not equal to the width of the second matrix!!!\n");
                    ex = new MyException("Dimensions of first matrix: " + m1_Dimension + " " + n1_Dimension + "  \n");
                    ex = new MyException("Dimensions of second matrix: " + m2_Dimension + " " + n2_Dimension + "  \n");
                    //Matrix result_Matrix = new Matrix(m1_Dimension, n2_Dimension);
                    //return result_Matrix.GetEmpty();
                    throw ex;
                }

            }
            catch (MyException ex)
            {

                InformationOut("\nMultiplication ERROR!\n========================\n", "red");
                InformationOut(ex.Message + "\n", "green");

                Matrix result_Matrix = new Matrix(1, 1);
                return result_Matrix.GetEmpty();
            }
        }
    }

}
