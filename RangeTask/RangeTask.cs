namespace RangeTask
{
    internal class RangeTask
    {
        public static void Main()
        {
            Console.WriteLine("Введите начало первого диапазона:");
            double rangeStart1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец первого диапазона:");
            double rangeEnd1 = Convert.ToDouble(Console.ReadLine());

            Range range1 = new(rangeStart1, rangeEnd1);

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
            double rangeStart2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец второго диапазона:");
            double rangeEnd2 = Convert.ToDouble(Console.ReadLine());

            Range range2 = new(rangeStart2, rangeEnd2);
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

            foreach (Range rangesArray in union)
            {
                Console.WriteLine($"{rangesArray.From}, {rangesArray.To}");
            }

            Range[] difference = range1.GetDifference(range2);

            Console.WriteLine("Проверка разности:");

            foreach (Range rangesArray in difference)
            {
                Console.WriteLine($"{rangesArray.From}, {rangesArray.To}");
            }

            if (difference.Length == 0)
            {
                Console.WriteLine("Диапазон отсутствует");
            }
        }
    }
}