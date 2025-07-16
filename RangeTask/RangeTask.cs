namespace RangeTask
{
    internal class RangeTask
    {
        public static void Main()
        {
            Console.WriteLine("Введите начало и конец диапазона:");

            Range range1 = new(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));

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

            Console.WriteLine("Введите начало и конец второго диапазона:");

            Range range2 = new(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            Range intersection = range1.GetIntersection(range2);

            Console.WriteLine("Проверка пересечения:");

            if (intersection is not null)
            {
                Console.WriteLine($"{intersection.From}, {intersection.To}");
            }
            else
            {
                Console.WriteLine("Пересечения нет");
            }

            Range[][] unionsArray = { range1.GetUnion(range2) };

            Console.WriteLine("Проверка объединения:");

            foreach (Range[] testRangesArray in unionsArray)
            {
                if (testRangesArray.Length == 2)
                {
                    Console.WriteLine($"{testRangesArray[0].From}, {testRangesArray[0].To} и {testRangesArray[1].From}, {testRangesArray[1].To}");
                }
                else
                {
                    Console.WriteLine($"{testRangesArray[0].From}, {testRangesArray[0].To}");
                }
            }

            Range[][] differencesArray = { range1.GetDiffirence(range2) };

            Console.WriteLine("Проверка разности:");

            foreach (Range[] testRangesArray in differencesArray)
            {
                if (testRangesArray is null)
                {
                    Console.WriteLine("Диапазон отсутствует");
                }
                else if (testRangesArray.Length == 2)
                {
                    Console.WriteLine($"{testRangesArray[0].From}, {testRangesArray[0].To} и {testRangesArray[1].From}, {testRangesArray[1].To}");
                }
                else
                {
                    Console.WriteLine($"{testRangesArray[0].From}, {testRangesArray[0].To}");
                }
            }
        }
    }
}