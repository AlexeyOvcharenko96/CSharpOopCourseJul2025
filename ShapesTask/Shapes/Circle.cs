namespace ShapesTask.Shapes;

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetWidth()
    {
        return Radius * 2;
    }

    public double GetHeight()
    {
        return Radius * 2;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override string ToString()
    {
        return $"Окружность с радиусом {Radius}";
    }

    public override int GetHashCode()
    {
        const int prime = 17;

        int hash = 1;
        hash = prime * hash + Radius.GetHashCode();

        return hash;
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

        Circle circle = (Circle)obj;
        return Radius == circle.Radius;
    }
}