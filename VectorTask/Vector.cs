namespace VectorTask;

public class Vector
{
    public double[] VectorComponents { get; set; }

    public Vector(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException("Аргумент должен быть больше нуля", nameof(n));
        }

        VectorComponents = new double[n];

        for (int i = 0; i < n; i++)
        {
            VectorComponents[i] = 0;
        }
    }

    public Vector(Vector vector)
    {
        double[] array = new double[vector.GetSize()];

        Array.Copy(vector.VectorComponents, array, array.Length);

        VectorComponents = array;
    }

    public Vector(double[] array)
    {
        if (array is null)
        {
            throw new ArgumentException("Аргумент не должен быть равен null", nameof(array));
        }

        int length = array.Length;
        double[] vectorArray = new double[length];

        Array.Copy(array, vectorArray, length);

        VectorComponents = vectorArray;
    }

    public Vector(int n, double[] array)
    {
        if (n <= 0)
        {
            throw new ArgumentException("Аргумент должен быть больше нуля", nameof(n));
        }

        if (array is null)
        {
            throw new ArgumentNullException(nameof(array), "Аргумент не должен быть равен null");
        }

        VectorComponents = new double[n];

        for (int i = 0; i < array.Length; i++)
        {
            if (i >= n)
            {
                VectorComponents[i] = 0;
                continue;
            }

            VectorComponents[i] = array[i];
        }
    }

    public int GetSize()
    {
        return VectorComponents.Length;
    }

    public double this[int index]
    {
        get { return VectorComponents[index]; }
        set { VectorComponents[index] = value; }
    }

    public void AddVector(Vector vector)
    {
        int arrayLength1 = this.GetSize();
        int arrayLength2 = vector.GetSize();

        int arraysLengthMax = Math.Max(arrayLength1, arrayLength2);
        int arraysLengthMin = Math.Min(arrayLength1, arrayLength2);
        double[] array = new double[arraysLengthMax];

        for (int i = 0; i < arraysLengthMin; i++)
        {
            array[i] = this[i] + vector.VectorComponents[i];
        }

        for (int i = arraysLengthMin; i < arraysLengthMax; i++)
        {
            if (arraysLengthMax == arrayLength1)
            {
                array[i] = this[i];
            }

            if (arraysLengthMax == arrayLength2)
            {
                array[i] = vector[i];
            }

            this.VectorComponents = array;
        }
    }

    public void SubtractVector(Vector vector)
    {
        int arrayLength1 = this.GetSize();
        int arrayLength2 = vector.GetSize();


        int arraysLengthMax = Math.Max(arrayLength1, arrayLength2);
        int arraysLengthMin = Math.Min(arrayLength1, arrayLength2);
        double[] array = new double[arraysLengthMax];

        for (int i = 0; i < arraysLengthMin; i++)
        {
            array[i] = this[i] - vector.VectorComponents[i];
        }

        for (int i = arraysLengthMin; i < arraysLengthMax; i++)
        {
            if (arraysLengthMax == arrayLength1)
            {
                array[i] = this[i];
            }

            if (arraysLengthMax == arrayLength2)
            {
                array[i] = (-1) * vector.VectorComponents[i];
            }

            this.VectorComponents = array;
        }
    }

    public void MultiplyVectorByScalar(double scalar)
    {
        for (int i = 0; i < this.GetSize(); i++)
        {
            this[i] = VectorComponents[i] * scalar;
        }
    }

    public void GetReverse()
    {
        this.MultiplyVectorByScalar(-1);
    }

    public double GetLength()
    {
        double vectorLength = 0;

        foreach (double component in VectorComponents)
        {
            vectorLength += component * component;
        }

        return Math.Sqrt(vectorLength);
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        Vector vector3 = new Vector(vector1);
        vector3.AddVector(vector2);

        return vector3;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector vector3 = new Vector(vector1);
        vector3.SubtractVector(vector2);

        return vector3;
    }

    public static double GetScalarMultiplication(Vector vector1, Vector vector2)
    {
        int arraysLengthMin = Math.Min(vector1.GetSize(), vector2.GetSize());
        double scalarMultiplication = 0;

        for (int i = 0; i < arraysLengthMin; i++)
        {
            scalarMultiplication += vector1.VectorComponents[i] * vector2.VectorComponents[i];
        }

        return scalarMultiplication;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, this))
        {
            return true;
        }
        if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
        {
            return false;
        }

        Vector vector = (Vector)obj;

        if (this.GetSize() == vector.GetSize())
        {
            for (int i = 0; i < this.GetSize(); i++)
            {
                if (VectorComponents[i] != vector.VectorComponents[i])
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        int prime = 25;
        int hash = 1;
        for (int i = 0; i < VectorComponents.Length; i++)
        {
            hash += prime * hash + VectorComponents[i].GetHashCode();
        }

        return hash;

    }

    public override string ToString()
    {
        return "{ " + string.Join(", ", VectorComponents) + " }";
    }
}