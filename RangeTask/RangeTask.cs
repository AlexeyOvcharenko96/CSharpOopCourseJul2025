namespace RangeTask
{
    internal class RangeTask
    {
        public static void Main()
        {
            Console.WriteLine("Введите начало первого диапазона:");
            double rangeFrom1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец первого диапазона:");
            double rangeTo1 = Convert.ToDouble(Console.ReadLine());

            Range range1 = new(rangeFrom1, rangeTo1);

            Console.WriteLine("Длина диапазона = " + range1.GetLength());

            Console.WriteLine("Введите число для проверки нахождения числа в данном диапазоне:");
            double number = Convert.ToDouble(Console.ReadLine());

            if (range1.IsInside(number))
            {
                Console.WriteLine("Число внутри диапазона!");
            }
            else
            {
                Console.WriteLine("Число не принадлежит диапазону!");
            }

            Console.WriteLine("Введите начало второго диапазона:");
            double rangeFrom2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец второго диапазона:");
            double rangeTo2 = Convert.ToDouble(Console.ReadLine());

            Range range2 = new(rangeFrom2, rangeTo2);
            Range? intersection = range1.GetIntersection(range2);

            Console.WriteLine("Проверка пересечения:");

            if (intersection is not null)
            {
                Console.WriteLine($"{intersection.From}, {intersection.To}");
            }
            else
            {
                Console.WriteLine("Пересечения нет");
            }

            Range[] union = range1.GetUnion(range2);

            Console.WriteLine("Проверка объединения:");

            foreach (Range range in union)
            {
                Console.WriteLine($"{range.From}, {range.To}");
            }

            Range[] difference = range1.GetDifference(range2);

            Console.WriteLine("Проверка разности:");

            if (difference.Length == 0)
            {
                Console.WriteLine("Пустой результат");
            }
            else
            {
                foreach (Range range in difference)
                {
                    Console.WriteLine($"{range.From}, {range.To}");
                }
            }
        }
    }
}