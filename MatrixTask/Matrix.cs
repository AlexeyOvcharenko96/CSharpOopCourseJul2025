using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] _rows;

    public int RowsCount => _rows.Length;

    public int ColumnsCount => _rows[0].Size;

    public Matrix(int rowsCount, int columnsCount)
    {
        if (rowsCount <= 0)
        {
            throw new ArgumentException($"Количество строк должно быть больше нуля. Количество строк: {rowsCount}", nameof(rowsCount));
        }

        if (columnsCount <= 0)
        {
            throw new ArgumentException($"Количество столбцов должно быть больше нуля. Количество строк: {columnsCount}", nameof(columnsCount));
        }

        _rows = new Vector[rowsCount];

        for (int i = 0; i < rowsCount; i++)
        {
            _rows[i] = new Vector(columnsCount);
        }
    }


    public Matrix(Matrix matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);

        _rows = new Vector[matrix._rows.Length];

        Array.Copy(matrix._rows, _rows, _rows.Length);
    }

    public Matrix(double[,] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
        {
            throw new ArgumentException($"Длина массива не должна быть равна нулю. Длина массива: {array.Length}", nameof(array));
        }

        int rowsCount = array.GetLength(0);
        int columnsCount = array.GetLength(1);

        _rows = new Vector[rowsCount];

        double[][] matrix = new double[rowsCount][];

        for (int i = 0; i < rowsCount; i++)
        {
            matrix[i] = new double[columnsCount];

            for (int j = 0; j < columnsCount; j++)
            {
                matrix[i][j] = array[i, j];
            }
        }

        for (int i = 0; i < rowsCount; i++)
        {
            _rows[i] = new Vector(matrix[i]);
        }
    }

    public Matrix(Vector[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
        {
            throw new ArgumentException($"Длина массива не должна быть равна нулю. Длина массива: {array.Length}", nameof(array));
        }

        _rows = new Vector[array.GetLength(0)];

        Array.Copy(array, _rows, array.Length);
    }

    public Vector this[int index]
    {
        get => _rows[index];
        set
        {
            if (index < 0 || index >= RowsCount)
            {
                throw new ArgumentException($"Индекс строки должен быть >= 0 и < {RowsCount}. Индекс: {index}", nameof(index));
            }

            if (value.Size != ColumnsCount)
            {
                throw new ArgumentException($"Размер вектора должен быть = {ColumnsCount}. Размер верктора: {value.Size}", nameof(value));
            }

            _rows[index] = value;
        }
    }

    public Vector GetColumn(int index)
    {
        if (index < 0 || index >= ColumnsCount)
        {
            throw new ArgumentOutOfRangeException($"Индекс столбца должен быть >= 0 и < {ColumnsCount}. Индекс: {index}", nameof(index));
        }

        double[] column = new double[RowsCount];

        for (int i = 0; i < RowsCount; i++)
        {
            column[i] = _rows[i][index];
        }

        return new Vector(column);
    }

    public void Transpose()
    {
        Vector[] vectorsArray = new Vector[ColumnsCount];

        for (int i = 0; i < ColumnsCount; i++)
        {
            vectorsArray[i] = GetColumn(i);
        }

        _rows = vectorsArray;
    }

    public void MultiplyByScalar(double scalar)
    {
        foreach (Vector row in _rows)
        {
            row.MultiplyByScalar(scalar);
        }
    }

    private Matrix GetAdditionalMinor(int rowToRemove, int columnToRemove)
    {
        int smallerMatrixSize = RowsCount - 1;
        double[,] smallerMatrix = new double[smallerMatrixSize, smallerMatrixSize];

        for (int i = 0, j = 0; i < RowsCount; i++)
        {
            if (i == rowToRemove)
            {
                continue;
            }

            for (int m = 0, n = 0; m < RowsCount; m++)
            {
                if (m == columnToRemove)
                {
                    continue;
                }

                smallerMatrix[j, n] = _rows[i][m];
                n++;
            }

            j++;
        }

        return new Matrix(smallerMatrix);
    }

    public double GetDeterminant()
    {
        if (ColumnsCount != RowsCount)
        {
            throw new ArgumentException($"Количество строк {RowsCount} и количество столбцов {ColumnsCount} должны быть равны");
        }

        if (RowsCount == 1)
        {
            return _rows[0][0];
        }

        if (RowsCount == 2)
        {
            return _rows[0][0] * _rows[1][1] - _rows[0][1] * _rows[1][0];
        }

        double determinant = 0;

        for (int i = 0; i < RowsCount; i++)
        {
            determinant += Math.Pow(-1, 2 + i) * _rows[0][i] * GetAdditionalMinor(0, i).GetDeterminant();
        }

        return determinant;
    }

    public Vector MultiplyByColumnVector(Vector column)
    {
        if (column.Size != RowsCount)
        {
            throw new ArgumentException($"Размер вектора-столбца должен совпадать с количеством строк матрицы. Количество строк: {RowsCount}, размер вектора: {column.Size}", nameof(column));
        }

        double[] array = new double[RowsCount];

        for (int i = 0; i < RowsCount; i++)
        {
            array[i] = Vector.GetScalarProduct(_rows[i], column);
        }

        return new Vector(array);
    }

    public Matrix MultiplyByRowVector(Vector row)
    {
        if (ColumnsCount != 1)
        {
            throw new ArgumentException($"Количество столбцов матрицы должно быть = 1, Количество столбцов: {ColumnsCount}");
        }

        if (row.Size != RowsCount)
        {
            throw new ArgumentException($"Размер вектора-строки должен совпадать с количеством строк матрицы. Количество строк: {RowsCount}, размер вектора: {row.Size}", nameof(row));
        }

        double[,] array = new double[RowsCount, RowsCount];

        for (int i = 0; i < RowsCount; i++)
        {
            for (int j = 0; j < RowsCount; j++)
            {
                array[i,j] += _rows[i][0] * row[j];
            }
        }

        return new Matrix(array);
    }

    public void Add(Matrix matrix)
    {
        if (ColumnsCount != matrix.ColumnsCount || RowsCount != matrix.RowsCount)
        {
            throw new ArgumentException($"Размер матриц должен совпадать. Размерность первой матрицы: {RowsCount} x {ColumnsCount}; " + $"Размерность второй матрицы: {matrix.RowsCount} x {matrix.ColumnsCount}", nameof(matrix));
        }

        for (int i = 0; i < RowsCount; i++)
        {
            _rows[i].Add(matrix._rows[i]);
        }
    }

    public void Subtract(Matrix matrix)
    {
        if (ColumnsCount != matrix.ColumnsCount || RowsCount != matrix.RowsCount)
        {
            throw new ArgumentException($"Размер матриц должен совпадать. Размерность первой матрицы: {RowsCount} x {ColumnsCount}; " + $"Размерность второй матрицы: {matrix.RowsCount} x {matrix.ColumnsCount}", nameof(matrix));
        }

        for (int i = 0; i < RowsCount; i++)
        {
            _rows[i].Subtract(matrix._rows[i]);
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsCount != matrix2.ColumnsCount || matrix1.RowsCount != matrix2.RowsCount)
        {
            throw new ArgumentException($"Размер матриц должен совпадать. Размерность первой матрицы: {matrix1.RowsCount} x {matrix1.ColumnsCount}; " + $"Размерность второй матрицы: {matrix2.RowsCount} x {matrix2.ColumnsCount}");
        }

        Matrix matrix = new(matrix1);

        matrix.Add(matrix2);

        return matrix;
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsCount != matrix2.ColumnsCount || matrix1.RowsCount != matrix2.RowsCount)
        {
            throw new ArgumentException($"Размер матриц должен совпадать. Размерность первой матрицы: {matrix1.RowsCount} x {matrix1.ColumnsCount}; " + $"Размерность второй матрицы: {matrix2.RowsCount} x {matrix2.ColumnsCount}");
        }

        Matrix matrix = new(matrix1);

        matrix.Subtract(matrix2);

        return matrix;
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.ColumnsCount != matrix2.RowsCount)
        {
            throw new ArgumentException($"Количество столбцов первой матрицы ({matrix1.ColumnsCount}) должно совпадать с количеством строк второй матрицы ({matrix2.RowsCount})");
        }

        double[,] array = new double[matrix1.RowsCount, matrix2.ColumnsCount];

        for (int i = 0; i < matrix1.RowsCount; i++)
        {
            for (int j = 0; j < matrix2.ColumnsCount; j++)
            {
                double value = 0;

                for (int k = 0; k < matrix1.ColumnsCount; k++)
                {
                    value += matrix1._rows[i][k] * matrix2._rows[k][j];
                }

                array[i, j] = value;
            }
        }

        return new Matrix(array);
    }

    public override string ToString()
    {
        string result = "{";

        for (int i = 0; i < RowsCount; i++)
        {
            result += _rows[i].ToString();

            if (i < RowsCount - 1)
            {
                result += ", ";
            }
        }

        result += "}";
        return result;
    }
}