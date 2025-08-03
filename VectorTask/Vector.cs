namespace VectorTask;

public class Vector
{
    private int _size;
    private double[] _components;

    public int GetSize
    {
        get { return _size; }
        set { _size = value; }
    }

    public Vector(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Аргумент size должен быть больше нуля", nameof(size));
        }

        _size = size;
        _components = new double[size];
    }

    public Vector(Vector? vector)
    {
        ArgumentNullException.ThrowIfNull(vector);

        _components = new double[vector._size];

        Array.Copy(vector._components, _components, _components.Length);

        _size = _components.Length;
    }

    public Vector(double[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        if (array.Length == 0)
        {
            throw new ArgumentException($"Длина массива не должа быть равна нулю", nameof(array));
        }

        _components = new double[array.Length];

        Array.Copy(array, _components, array.Length);

        _size = array.Length;
    }

    public Vector(int size, double[] array)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Аргумент size должен быть больше нуля", nameof(size));
        }

        ArgumentNullException.ThrowIfNull(array);

        _components = new double[size];

        Array.Copy(array, _components, Math.Min(array.Length, size));

        _size = size;
    }

    public double this[int index]
    {
        get { return _components[index]; }
        set { _components[index] = value; }
    }

    public void Add(Vector vector)
    {
        if (_components.Length < vector._size)
        {
            Array.Resize(ref _components, vector._size);
        }

        for (int i = 0; i < vector._size; i++)
        {
            _components[i] += vector._components[i];
        }

        _size = _components.Length;
    }

    public void Subtract(Vector vector)
    {
        if (_components.Length < vector._size)
        {
            Array.Resize(ref _components, vector._size);
        }

        for (int i = 0; i < vector._size; i++)
        {
            _components[i] -= vector._components[i];
        }

        _size = _components.Length;
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
        this.MultiplyByScalar(-1);
    }

    public double GetLength()
    {
        double sumSquaredComponents = 0;

        foreach (double component in _components)
        {
            sumSquaredComponents += component * component;
        }

        return Math.Sqrt(sumSquaredComponents);
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        Vector sum = new Vector(vector1);
        sum.Add(vector2);

        return sum;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector differense = new Vector(vector1);
        differense.Subtract(vector2);

        return differense;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        int minVectorSize = Math.Min(vector1._size, vector2._size);
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

        if (_size != vector._size)
        {
            return false;
        }

        for (int i = 0; i < _size; i++)
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
        hash = prime * hash + _size;

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