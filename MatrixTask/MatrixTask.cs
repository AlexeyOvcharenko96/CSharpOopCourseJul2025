using VectorTask;

namespace MatrixTask;

internal class MatrixTask
{
    static void Main(string[] args)
    {
        double[,] array1 =
        {
            { 11, 12, 13, 14 },
            { 55, -2, 77, 88 },
            { 36, 72, 65, 22 },
            { 15, 16, 17, 18 },
        };

        double[,] array2 =
        {
            { 11 },
            { 31 },
            { 5 },
            { 3 }
        };

        double[] vector1 = { 1, 2, 3, 4 };
        double[] vector2 = { -1, -2, -3, -4 };
        double[] vector3 = { 5, 6, 7, 8 }; ;
        double[] vector4 = { 51, 61, 71, 81 }; ;

        Vector[] vectorsArray1 =
        {
            new(vector1),
            new(vector2),
            new(vector3),
            new(vector4)
        };

        Matrix matrix1 = new Matrix(3, 3);
        Matrix matrix2 = new Matrix(array1);
        Matrix matrix3 = new Matrix(matrix2);
        Matrix matrix4 = new Matrix(array2);
        Matrix matrix5 = new Matrix(vectorsArray1);;

        Console.WriteLine("Проверка нестатических методов:");
        Console.WriteLine(matrix1 + ", Размерность = " + matrix1.RowsCount + "x" + matrix1.ColumnsCount);
        Console.WriteLine(matrix2 + ", Размерность = " + matrix2.RowsCount + "x" + matrix2.ColumnsCount);
        Console.WriteLine(matrix3 + ", Размерность = " + matrix3.RowsCount + "x" + matrix3.ColumnsCount);
        Console.WriteLine(matrix4 + ", Размерность = " + matrix4.RowsCount + "x" + matrix4.ColumnsCount);
        Console.WriteLine(matrix5 + ", Размерность = " + matrix5.RowsCount + "x" + matrix5.ColumnsCount);
        Console.WriteLine();

        Console.WriteLine("Матрица 2: " + matrix2);
        Console.WriteLine("Получение вектора-строки матрицы 2 по индексу 3: " + matrix2[3]);
        Console.WriteLine();

        Console.WriteLine("Задание вектора-строки матрицы 2 по индексу 3");
        matrix2[3] = vectorsArray1[3];
        Console.WriteLine("Результат: " + matrix2);
        Console.WriteLine();

        Console.WriteLine("Матрица 2: " + matrix2);
        Console.WriteLine("Получение вектора-столбца матрицы 2 по индексу 3: " + matrix2.GetColumn(3));
        Console.WriteLine();

        Console.WriteLine("Транспонирование матрицы 5");
        matrix5.Transpose();
        Console.WriteLine("Результат: " + matrix5);
        Console.WriteLine();

        Console.WriteLine("Умножение матрицы матрицы 4 на скаляр 2");
        matrix4.MultiplyByScalar(2);
        Console.WriteLine("Результат: " + matrix4);
        Console.WriteLine();

        Console.WriteLine("Вычисление определителя матрицы 2: " + matrix2.GetDeterminant());
        Console.WriteLine();

        Console.WriteLine($"Умножение матрицы 2 {matrix2} на вектор 3 {vectorsArray1[3]}:");
        Console.WriteLine("Результат: " + matrix2.MultiplyByColumnVector(vectorsArray1[3]));
        Console.WriteLine();

        Console.WriteLine($"Умножение матрицы 4 {matrix4} на вектор 3 {vectorsArray1[3]}:");
        Console.WriteLine("Результат: " + matrix4.MultiplyByRowVector(vectorsArray1[3]));
        Console.WriteLine();

        Console.WriteLine("Сложение матриц 2 и 5:");
        matrix2.Add(matrix5);
        Console.WriteLine("Результат: " + matrix2);
        Console.WriteLine();

        Console.WriteLine("Вычитание матриц 5 и 2:");
        matrix5.Subtract(matrix2);
        Console.WriteLine("Результат: " + matrix5);
        Console.WriteLine();

        Console.WriteLine("Проверка статических методов:");

        Console.WriteLine("Сложение матриц 3 и 5:");
        Console.WriteLine("Результат: " + Matrix.GetSum(matrix3, matrix5));
        Console.WriteLine();

        Console.WriteLine("Вычитание матриц 3 и 5:");
        Console.WriteLine("Результат: " + Matrix.GetDifference(matrix3, matrix5));
        Console.WriteLine();

        Console.WriteLine("Умножение матриц 2 и 5:");
        Console.WriteLine("Результат: " + Matrix.GetProduct(matrix2, matrix5));
        Console.WriteLine();
    }
}