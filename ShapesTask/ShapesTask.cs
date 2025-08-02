using ShapesTask.Shapes;
using ShapesTask.Comparators;

namespace ShapesTask;

internal class ShapesTask
{
    public static IShape GetMaxAreaShape(IShape[] shapesArray)
    {
        Array.Sort(shapesArray, new ShapeAreaComparer());

        return shapesArray[^1];
    }

    public static IShape GetSecondMaxPerimeterShape(IShape[] shapesArray)
    {
        Array.Sort(shapesArray, new ShapePerimeterComparer());

        return shapesArray[^2];
    }

    static void Main(string[] args)
    {
        IShape[] shapesArray =
        {
            new Square(5),
            new Square(6.5),
            new Rectangle(3, 5),
            new Rectangle(4, 6),
            new Circle(7.5),
            new Circle(5),
            new Triangle(1, 1, 10, 1, 5, 12),
            new Triangle(2, 5, 4, 4, 7, 9)
        };

        IShape maxAreaShape = GetMaxAreaShape(shapesArray);

        Console.WriteLine($"Фигура с наибольшей площадью: {maxAreaShape}");
        Console.WriteLine($"Ширина: {maxAreaShape.GetWidth()}");
        Console.WriteLine($"Высота: {maxAreaShape.GetHeight()}");
        Console.WriteLine($"Площадь: {maxAreaShape.GetArea()}");
        Console.WriteLine($"Периметр: {maxAreaShape.GetPerimeter()}");
        Console.WriteLine();

        IShape secondMaxPerimeterShape = GetSecondMaxPerimeterShape(shapesArray);

        Console.WriteLine($"Фигура со вторым по величине периметром: {secondMaxPerimeterShape}");
        Console.WriteLine($"Ширина: {secondMaxPerimeterShape.GetWidth()}");
        Console.WriteLine($"Высота: {secondMaxPerimeterShape.GetHeight()}");
        Console.WriteLine($"Площадь: {secondMaxPerimeterShape.GetArea()}");
        Console.WriteLine($"Периметр: {secondMaxPerimeterShape.GetPerimeter()}");
    }
}