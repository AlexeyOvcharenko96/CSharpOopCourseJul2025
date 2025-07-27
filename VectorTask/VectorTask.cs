namespace VectorTask
{
    public class VectorTask
    {
        static void Main(string[] args)
        {
            double[] array1 = { 3, 4, 5, 9 };
            double[] array2 = { 1, 1, 1 };
            double[] array3 = { 3, 4, 5, 9 };

            Vector vector1 = new Vector(array1);
            Vector vector2 = new Vector(array2);
            Vector vector3 = new Vector(5,array3);
            Vector vector4 = new Vector(array3);
            Vector vector5 = new Vector(vector3);

            Console.WriteLine("Проверка нестатических методов");
            Console.WriteLine();

            Console.WriteLine(vector1 + " Размерность = " + vector1.GetSize());
            Console.WriteLine(vector2 + " Размерность = " + vector2.GetSize());
            Console.WriteLine(vector3 + " Размерность = " + vector3.GetSize());
            Console.WriteLine(vector4 + " Размерность = " + vector4.GetSize());
            Console.WriteLine(vector5 + " Размерность = " + vector5.GetSize());
            Console.WriteLine();

            Console.WriteLine("К вектору 3 прибавить вектор 2:");
            vector3.AddVector(vector2);
            Console.WriteLine("Результат:" + vector3);
            Console.WriteLine();

            Console.WriteLine("От вектора 3 отнять вектор 2:");
            vector3.SubtractVector(vector2);
            Console.WriteLine("Результат:" + vector3);
            Console.WriteLine();

            Console.WriteLine("Умножение вектора 3 на скаляр 4");
            vector3.MultiplyVectorByScalar(4);
            Console.WriteLine("Результат:" + vector3);
            Console.WriteLine();

            Console.WriteLine("Разворот вектора 3");
            vector3.GetReverse();
            Console.WriteLine("Результат:" + vector3);
            Console.WriteLine();

            Console.WriteLine("Получение длины вектора 3: " + vector3.GetLength());
            Console.WriteLine();

            Console.WriteLine("Вектор 3:" + vector3);
            Console.WriteLine("Получение компоненты вектора 3 по индексу 2: " + vector3[2]);
            Console.WriteLine();

            Console.WriteLine("Установка компоненты вектора 3 по индексу 2: ");
            vector3[2] = 25;
            Console.WriteLine("Результат:" + vector3);
            Console.WriteLine();

            Console.WriteLine("Проверка метода Equals:");
            if (vector1.Equals(vector3))
            {
                Console.WriteLine("Векторы 1 и 3 равны");
            }
            else
            {
                Console.WriteLine("Векторы 1 и 3 не равны");
            }

            if (vector1.Equals(vector4))
            {
                Console.WriteLine("Векторы 1 и 4 равны");
            }
            else
            {
                Console.WriteLine("Векторы 1 и 4 не равны");
            }

            if (vector3.Equals(vector5))
            {
                Console.WriteLine("Векторы 3 и 5 равны");
            }
            else
            {
                Console.WriteLine("Векторы 3 и 5 не равны");
            }

            Console.WriteLine();

            Console.WriteLine("Проверка метода Хеш-функции:");
            if (vector1.GetHashCode() == vector5.GetHashCode())
            {
                Console.WriteLine("Хешкоды векторов 1 и 5 равны");
            }
            else
            {
                Console.WriteLine("Хешкоды векторов 1 и 5 не равны");
            }

            if (vector1.GetHashCode() == vector4.GetHashCode())
            {
                Console.WriteLine("Хешкоды векторов 1 и 4 равны");
            }
            else
            {
                Console.WriteLine("Хешкоды векторов 1 и 4 не равны");
            }

            Console.WriteLine();
            Console.WriteLine("Проверка статических методов");
            Console.WriteLine();

            Console.WriteLine(vector1);
            Console.WriteLine(vector3);
            Console.WriteLine("Скалярное произведение векторов 1 и 3: " + Vector.GetScalarMultiplication(vector1, vector3));
            Console.WriteLine();

            Console.WriteLine(vector1);
            Console.WriteLine(vector3);
            Console.WriteLine("Сумма векторов 1 и 3: " + Vector.GetSum(vector1, vector3));
            Console.WriteLine();

            Console.WriteLine(vector1);
            Console.WriteLine(vector3);
            Console.WriteLine("Разность векторов 1 и 3: " + Vector.GetDifference(vector1, vector3));
        }
    }
}