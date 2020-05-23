using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

// В данной программе использован ввод переменных при помощи случайных значений.
//  Вывод в файл выводит только результат LINQ.

//ЗАМЕЧАНИЕ: если запускать проект через нажатие Ctrl + f5, то строки при вызове деструктора будут выведены в консоль,
// а если через f5 или через кнопку старт то данных строк в косоли не будет.

namespace Lab14_Generics_Serialize
{
    [Serializable]
    public class CollectionType<T>
    {
        [NonSerialized]
        public List<T> someList;
        public int Capacity { get { return someList.Capacity; } }

        public CollectionType()
        {
            someList = new List<T>();
        }

        public CollectionType(int i)
        {
            someList = new List<T>(i);
        }

        public CollectionType(IEnumerable<T> collection)
        {
            someList = new List<T>(collection);
        }

        public void Add(T item)
        {
            someList.Add(item);
        }

        public void Remove(T item)
        {
            someList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            someList.RemoveAt(index);
        }

        public void Sort()
        {
            someList.Sort();
        }

        public T this[int i]
        {
            get
            {
                return someList[i];
            }
            set
            {
                someList[i] = value;
            }
        }

        public List<T> Get()
        {
            return someList;
        }

        public override string ToString()
        {
            string result = "CollectionType exemplar\n";
            for (int i = 0; i < this.Capacity; i++)
            {
                result += "  " + i + ") " + this[i] + "   ";
            }
            result += '\n';
            return result;
        }

        public static bool operator <(CollectionType<T> firstItem, CollectionType<T> secondItem)
        {
            return firstItem.Capacity < secondItem.Capacity;
        }

        public static bool operator >(CollectionType<T> firstItem, CollectionType<T> secondItem)
        {
            return firstItem.Capacity > secondItem.Capacity;
        }

        public static bool operator ==(CollectionType<T> firstItem, CollectionType<T> secondItem)
        {
            if (firstItem == secondItem)
                return true;
            else
                return false;
        }

        public static bool operator !=(CollectionType<T> firstItem, CollectionType<T> secondItem)
        {
            if (firstItem != secondItem)
                return true;
            else
                return false;
        }

        ~CollectionType()
        {
            Console.WriteLine("CollectionType object has been disposed.");
        }
    }

    class Lab14_Generics_Serialize
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            CollectionType<Vector> firstCollect = new CollectionType<Vector>(rand.Next(1, 5));                                     // Создано два экземпляра класса CollectionType<Vector> для демонстрации 2 задания, 
            firstCollect = Value_entering(firstCollect, rand);                                                                    // А так же демонстрация сортировки экземпляров vector по модулю вектора в коллекции CollectionType<Vector>
            firstCollect.Sort();

            Serialization(firstCollect);                                                                                            // Сериализация коллекции в XML Файл
                                                                                                                                    
            CollectionType<Vector> DesCollection = new CollectionType<Vector>();                                                    
            DesCollection = Deserialization();                                                                                      // Десериализация коллекции из XML Файла
            CollectionDisplaying(DesCollection);                                                                                    
            CollectionDisplaying(DesCollection);                                                                                    
                                                                                                                                    
            //CollectionType<Vector>[] collectionTypes = new CollectionType<Vector>[rand.Next(1,5)];                                  // Создание массива коллекций CollectionType<Vector>
            //collectionTypes = Value_entering(collectionTypes);                                                                      
            //LinqToArr(collectionTypes, rand);                                                                                       
            Console.Read();
        }

        static void Serialization(CollectionType<Vector> SCollection)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(CollectionType<Vector>));
            try
            {
                using (FileStream fs = new FileStream("Collection.xml", FileMode.Create))                                            //Serialize
                {
                    formatter.Serialize(fs, SCollection);

                    Console.WriteLine("Serialization succesful");
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Serialization Unsuccesful");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        static CollectionType<Vector> Deserialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(CollectionType<Vector>));
            try
            {
                CollectionType<Vector> SCollection = new CollectionType<Vector>();
                using (FileStream fs = new FileStream("Collection.xml", FileMode.OpenOrCreate))
                {

                    SCollection = (CollectionType<Vector>)formatter.Deserialize(fs);                                                   //Dezerialize
                    Console.WriteLine("Deserialization succesful");

                }
                return SCollection;

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Deserialization Unsuccesful");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return null;
            }
        }

        static double allVectorSub(CollectionType<Vector> CollOfVectors)
        {
            double sumOfAbs = 0;
            for (int i = 0; i < CollOfVectors.Capacity; i++)
            {
                sumOfAbs += CollOfVectors[i].Abs();
            }
            return sumOfAbs;
        }

        static void LinqToArr(CollectionType<Vector>[] collectionTypes, Random rand)
        {
            int tempCount = 0;
            Console.WriteLine("Source Array CollectionType<Vector>[] collectionTypes: ");
            foreach (var s in collectionTypes)
            {
                Console.WriteLine("[ " + tempCount + " ] " + s);
                tempCount++;
            }
            int randCapacity = rand.Next(1, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗначение randCapacity для сравнения в LINQ запросе: " + randCapacity + '\n');
            var firstquery = from item in collectionTypes                                                                           // В данном запросе будут включены в исходный массив те коллекции, у которых количество элементов больше 
                             where item.Capacity > randCapacity                                                                     // заданого в переменной randCapacity, а после чего будут упорядочены по значению суммы всех модулей векторов в коллекции
                             orderby allVectorSub(item)                                                                             // вычисляемые в функции allVectorSub().
                             select item;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("First LINQ Query:");
            Console.WriteLine("Length of this Array of CollectionType<Vector>: " + collectionTypes.Length + "\n");

            Console.ForegroundColor = ConsoleColor.Green;
            tempCount = 0;
            foreach (var s in firstquery)
            {
                Console.WriteLine("[ " + tempCount + " ] " + s);
                tempCount++;
            }
            Console.ResetColor();
            Console.WriteLine("================================================");
            Console.WriteLine("Количество коллекций в массиве длинной ({2}) размер которых больше чем {0}: {1}", randCapacity, tempCount, collectionTypes.Length);
            Console.WriteLine("================================================\n");

            CollectionType<double> max = new CollectionType<double>(collectionTypes.Length);                                        // Данный блок кода выполняет поиск максимальной коллекции в массиве
            for (int i = 0; i < collectionTypes.Length; i++)                                                                        // CollectionType<Vector>[] collectionTypes по такому принципу: 
            {                                                                                                                       // из каждой коллекции массива через LINQ запрос ищем МАКСИМАЛЬНОЕ значение
                max.Add(collectionTypes[i].Get().Max(a => a.Abs()));                                                                // модуля вектора в i-ой коллекции из массива.
            }                                                                                                                       // Создается коллекция CollectionType<double> max размерностью равной массиву collectionTypes и записываются в max[i] МАКСИМАЛЬНЫЕ значения collectionTypes[i]. 
            int indOfMax = max.someList.IndexOf(max.Get().Max());                                                                   // После в коллекции max отыскивается МАКСИМАЛЬНОЕ значение и его индекс, при помощи которого выводим collectionTypes[индекс]
            Console.WriteLine("Max of array: " + "\n[ " + indOfMax + " ] " + collectionTypes[indOfMax]);

            CollectionType<double> min = new CollectionType<double>(collectionTypes.Length);                                        //  Данный блок кода выполняет поиск максимальной коллекции в массиве
            for (int i = 0; i < collectionTypes.Length; i++)                                                                        //  CollectionType<Vector>[] collectionTypes по такому принципу: 
            {                                                                                                                       //  из каждой коллекции массива через LINQ запрос ищем МИНИМАЛЬНОЕ значение
                min.Add(collectionTypes[i].Get().Min(a => a.Abs()));                                                                //  модуля вектора в i-ой коллекции из массива.
            }                                                                                                                       //  Создается коллекция CollectionType<double> min размерностью равной массиву collectionTypes и записываются в min[i] МИНИМАЛЬНЫЕ значения collectionTypes[i]. 
            int indOfMin = min.someList.IndexOf(min.Get().Min());                                                                   //  После в коллекции min отыскивается МИНИМАЛЬНОЕ значение и его индекс, при помощи которого выводим collectionTypes[индекс]
            Console.WriteLine("Min of array: " + "\n[ " + indOfMin + " ] " + collectionTypes[indOfMin]);                            //  Как-то запутано получилось :)

            Value_outputTOFILE(firstquery, collectionTypes, indOfMax, indOfMin, randCapacity);
        }

        static CollectionType<Vector> Value_entering(CollectionType<Vector> collection, Random rand)                                // Ввод данных в демонстрационные экземпляры класса CollectionType<Vector>.
        {
            for (int i = 0; i < collection.Capacity; i++)
            {
                collection.Add(new Vector(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100)));
            }
            return collection;
        }

        static CollectionType<Vector>[] Value_entering(CollectionType<Vector>[] collectionTypes)                                    // Ввод данных в массив типа CollectionType<Vector>.
        {
            var rand = new Random();

            for (int i = 0; i < collectionTypes.Length; i++)
            {
                collectionTypes[i] = new CollectionType<Vector>(rand.Next(1, 5));                                                   //Размерность задается случайным числом от 1 до 5
                for (int j = 0; j < collectionTypes[i].Capacity; j++)
                {
                    collectionTypes[i].Add(new Vector(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100)));                    //Значение каждой координаты вектора задается случайным числом от 0 до 100
                }
            }
            return collectionTypes;
        }

        static void CollectionDisplaying(CollectionType<Vector> collection)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Collection from xml:");
                int cap = 0;
                foreach (var t in collection.someList)
                {
                    Console.Write(cap + ") " + t + ";  ");
                }
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        static void Value_outputTOFILE(IOrderedEnumerable<CollectionType<Vector>> firstquery, CollectionType<Vector>[] collectionTypes, int indOfMax, int indOfMin, int randCapacity)
        {
            try
            {
                using (StreamWriter fw = new StreamWriter("Outlet.out", false, System.Text.Encoding.Default))
                {
                    int tempCount = 0;
                    foreach (var s in firstquery)
                    {
                        tempCount++;
                    }
                    fw.WriteLine("FIRST LINQ запрос.");
                    fw.WriteLine("================================================");
                    fw.WriteLine(" Kоличество коллекций в массиве длинной ({2}) размер которых больше чем {0}: {1}", randCapacity, tempCount, collectionTypes.Length);
                    fw.WriteLine("================================================\n");
                    fw.WriteLine("SECOND LINQ запрос.");
                    fw.WriteLine("================================================\n");
                    fw.WriteLine("Max of array: " + "\n[ " + indOfMax + " ] " + collectionTypes[indOfMax]);
                    fw.WriteLine("Min of array: " + "\n[ " + indOfMin + " ] " + collectionTypes[indOfMin]);
                    fw.WriteLine("================================================\n");
                }
                Console.WriteLine("Successful writing.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
