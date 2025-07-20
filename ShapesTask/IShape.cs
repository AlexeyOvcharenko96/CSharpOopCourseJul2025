namespace ShapesTask
{
    public interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
    }

    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape? shape1, IShape? shape2)
        {
            if (shape1 is null || shape2 is null)
            {
                throw new ArgumentNullException("Параметр не должен быть равен нулю");
            }

            return (int)shape2.GetArea() - (int)shape1.GetArea();
        }
    }

    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape? shape1, IShape? shape2)
        {
            if (shape1 is null || shape2 is null)
            {
                throw new ArgumentNullException("Параметр не должен быть равен нулю");
            }

            return (int)shape2.GetPerimeter() - (int)shape1.GetPerimeter();
        }
    }

    public class Square : IShape
    {
        public double SideLength { get; set; }

        public override string ToString()
        {
            return $"Квадрат с длиной стороны {SideLength}";
        }

        public override int GetHashCode()
        {
            return (int)SideLength;
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

            Square square = (Square)obj;
            return SideLength == square.SideLength;
        }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetPerimeter()
        {
            return SideLength * 4;
        }
    }

    public class Triangle : IShape
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }

        public override string ToString()
        {
            return $"Треугольник с координатами (x1 = {X1}, y1 = {Y1}, x2 = {X2}, y2 = {Y2}, x3 = {X3}, y3 = {Y3})";
        }

        public override int GetHashCode()
        {
            return (int)(X1 + Y1 + X2 + Y2 + X3 + Y3);
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

            Triangle t = (Triangle)obj;
            return X1 == t.X1 && X2 == t.X2 && X3 == t.X3 && Y1 == t.Y1 && Y2 == t.Y2 && Y3 == t.Y3;
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            double maxX = Math.Max(X1, X2);
            maxX = Math.Max(maxX, X3);

            double minX = Math.Min(X1, X2);
            minX = Math.Min(minX, X3);

            return maxX - minX;
        }

        public double GetHeight()
        {
            double maxY = Math.Max(Y1, Y2);
            maxY = Math.Max(maxY, Y3);

            double minY = Math.Min(Y1, Y2);
            minY = Math.Min(minY, Y3);

            return maxY - minY;
        }

        public double GetArea()
        {
            return Math.Abs(X1 * (Y2 - Y3) + X2 * (Y3 - Y1) + X3 * (Y1 - Y2)) / 2;
        }

        public double GetPerimeter()
        {
            double sideA = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            double sideB = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            double sideC = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));

            return sideA + sideB + sideC;
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override string ToString()
        {
            return $"Прямоугольник с длинами сторон {Width} и {Height}";
        }

        public override int GetHashCode()
        {
            return (int)(Width + Height);
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

            Rectangle rectangle = (Rectangle)obj;
            return Width == rectangle.Width && Height == rectangle.Height;
        }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return Width * 2 + Height * 2;
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public override string ToString()
        {
            return $"Окружность с радиусом {Radius}";
        }

        public override int GetHashCode()
        {
            return (int)Radius;
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
    }
}