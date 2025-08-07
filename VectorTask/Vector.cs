namespace VectorTask;

public class Vector
{
    private double[] _components;

    public int Size => _components.Length;


    public Vector(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException($"Размер вектора должен быть больше нуля. Размер вектора: {size}", nameof(size));
        }

        _components = new double[size];
    }

    public Vector(Vector vector)
    {
        ArgumentNullException.ThrowIfNull(vector);

        _components = new double[vector._components.Length];

        Array.Copy(vector._components, _components, _components.Length);
    }

    public Vector(double[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
        {
            throw new ArgumentException($"Длина массива не должна быть равна нулю. Длина массива: {array.Length}", nameof(array));
        }

        _components = new double[array.Length];

        Array.Copy(array, _components, array.Length);
    }

    public Vector(int size, double[] array)
    {
        if (size <= 0)
        {
            throw new ArgumentException($"Размер вектора должен быть больше нуля. Размер вектора: {size}", nameof(size));
        }

        ArgumentNullException.ThrowIfNull(array);

        _components = new double[size];

        Array.Copy(array, _components, Math.Min(array.Length, size));
    }

    public double this[int index]
    {
        get => _components[index];
        set => _components[index] = value;
    }

    public void Add(Vector vector)
    {
        if (_components.Length < vector._components.Length)
        {
            Array.Resize(ref _components, vector._components.Length);
        }

        for (int i = 0; i < vector._components.Length; i++)
        {
            _components[i] += vector._components[i];
        }
    }

    public void Subtract(Vector vector)
    {
        if (_components.Length < vector._components.Length)
        {
            Array.Resize(ref _components, vector._components.Length);
        }

        for (int i = 0; i < vector._components.Length; i++)
        {
            _components[i] -= vector._components[i];
        }
    }

    public void MultiplyByScalar(double scalar)
    {
        for (int i = 0; i < _components.Length; i++)
        {
            _components[i] *= scalar;
        }
    }

    public void Reverse()
    {
        MultiplyByScalar(-1);
    }

    public double GetLength()
    {
        double componentsSquaredSum = 0;

        foreach (double component in _components)
        {
            componentsSquaredSum += component * component;
        }

        return Math.Sqrt(componentsSquaredSum);
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        Vector sum = new Vector(vector1);
        sum.Add(vector2);

        return sum;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector difference = new Vector(vector1);
        difference.Subtract(vector2);

        return difference;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        int minVectorSize = Math.Min(vector1._components.Length, vector2._components.Length);
        double scalarProduct = 0;

        for (int i = 0; i < minVectorSize; i++)
        {
            scalarProduct += vector1._components[i] * vector2._components[i];
        }

        return scalarProduct;
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

        if (_components.Length != vector._components.Length)
        {
            return false;
        }

        for (int i = 0; i < _components.Length; i++)
        {
            if (_components[i] != vector._components[i])
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        const int prime = 17;
        int hash = 1;

        foreach (double component in _components)
        {
            hash = prime * hash + component.GetHashCode();
        }

        return hash;
    }

    public override string ToString()
    {
        return $"{{{string.Join(", ", _components)}}}";
    }
}