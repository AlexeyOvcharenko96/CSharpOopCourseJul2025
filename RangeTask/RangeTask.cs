namespace RangeTask
{
    internal class RangeTask
    {
        public static void Main()
        {
            Range range = new(3.14, 14.7);

            Console.WriteLine("Длина диапазона = " + range.GetLength());

            Console.WriteLine("Измените диапазон, введите начало диапазона:");
            range.From = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Измените диапазон, введите конец диапазона:");
            range.To = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Длина диапазона = " + range.GetLength());

            Console.WriteLine("Введите число для проверки нахождения числа в данном диапазоне:");
            double number = Convert.ToDouble(Console.ReadLine());

            if (range.IsInside(number))
            {
                Console.WriteLine("Число внутри диапазона");
            }
            else
            {
                Console.WriteLine("Число не принадлежит диапазону");
            }
        }
    }
}