namespace ShapesTask
{
    internal class ShapesTask
    {
        public static IShape GetMaxAreaShape(IShape[] shapesArray)
        {
            Array.Sort(shapesArray, new AreaComparer());

            return shapesArray[0];
        }

        public static IShape GetSecondLargestPerimeterShape(IShape[] shapesArray)
        {
            Array.Sort(shapesArray, new PerimeterComparer());

            return shapesArray[1];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину стороны первого квадрата:");
            double square1Side = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите ширину первого прямоугольника:");
            double rectangle1Width = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите высоту первого прямоугольника:");
            double rectangle1Height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите радиус первой окружности:");
            double circle1Radius = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите длину стороны второго квадрата:");
            double square2Side = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите ширину второго прямоугольника:");
            double rectangle2Width = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите высоту второго прямоугольника:");
            double rectangle2Height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите радиус второй окружности:");
            double circle2Radius = Convert.ToDouble(Console.ReadLine());

            IShape[] shapesArray =
            {
                new Square(square1Side),
                new Square(circle2Radius),
                new Rectangle(rectangle1Width, rectangle1Height),
                new Rectangle(rectangle2Width, rectangle2Height),
                new Circle(circle1Radius),
                new Circle(circle2Radius),
                new Triangle(1,1,10,1,5,12),
                new Triangle(2,5,4,4,7,9)
            };

            double[] shapesArrayAreaCheck =
            {
                new Square(square1Side).GetArea(),
                new Square(circle2Radius).GetArea(),
                new Rectangle(rectangle1Width, rectangle1Height).GetArea(),
                new Rectangle(rectangle2Width, rectangle2Height).GetArea(),
                new Circle(circle1Radius).GetArea(),
                new Circle(circle2Radius).GetArea(),
                new Triangle(1,1,10,1,5,12).GetArea(),
                new Triangle(2,5,4,4,7,9).GetArea()
            };

            double[] shapesArrayPerimeterCheck =
            {
                new Square(square1Side).GetPerimeter(),
                new Square(circle2Radius).GetPerimeter(),
                new Rectangle(rectangle1Width, rectangle1Height).GetPerimeter(),
                new Rectangle(rectangle2Width, rectangle2Height).GetPerimeter(),
                new Circle(circle1Radius).GetPerimeter(),
                new Circle(circle2Radius).GetPerimeter(),
                new Triangle(1,1,10,1,5,12).GetPerimeter(),
                new Triangle(2,5,4,4,7,9).GetPerimeter()
            };

            IShape maxAreaShape = GetMaxAreaShape(shapesArray);

            Console.WriteLine("Фигура с наибольшей площадью:");
            Console.WriteLine($"Форма: {maxAreaShape.ToString()}");
            Console.WriteLine($"Ширина: {maxAreaShape.GetWidth()}");
            Console.WriteLine($"Высота: {maxAreaShape.GetHeight()}");
            Console.WriteLine($"Площадь: {maxAreaShape.GetArea()}");
            Console.WriteLine($"Периметр: {maxAreaShape.GetPerimeter()}");

            IShape secondLargestAreaShape = GetSecondLargestPerimeterShape(shapesArray);

            Console.WriteLine("Фигура со вторым по величине периметром:");
            Console.WriteLine($"Форма: {secondLargestAreaShape.ToString()}");
            Console.WriteLine($"Ширина: {secondLargestAreaShape.GetWidth()}");
            Console.WriteLine($"Высота: {secondLargestAreaShape.GetHeight()}");
            Console.WriteLine($"Площадь: {secondLargestAreaShape.GetArea()}");
            Console.WriteLine($"Периметр: {secondLargestAreaShape.GetPerimeter()}");
        }
    }
}