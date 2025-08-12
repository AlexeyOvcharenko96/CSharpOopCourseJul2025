namespace ArrayListHomeTask;

public class ArrayListHomeTask
{
    static void Main(string[] args)
    {
        Console.WriteLine("Проверка первого пункта задачи:");
        Console.WriteLine(string.Join(", ", ArrayListHome.ReadFileLines("..\\..\\..\\input.txt")));
        Console.WriteLine();

        List<int> numbers = new List<int> { 1, 2, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 15, 16, 16};

        Console.WriteLine("Проверка второго пункта задачи:");
        Console.WriteLine("Список до удалений: " + string.Join(", ", numbers));

        ArrayListHome.RemoveEvenNumbers(numbers);

        Console.WriteLine("Список после удалений: " + string.Join(", ", numbers));
        Console.WriteLine();

        List<int> duplicateNumbers = new List<int> { 10, 2, 3, 4, 5, 7, 7, 9, 101, 10, 101, 13, 4, 164, 15, 164 };

        Console.WriteLine("Проверка третьего пункта задачи:");
        Console.WriteLine("Список с повторяющимися целыми числами: " + string.Join(", ", duplicateNumbers));
        Console.WriteLine("Список с целыми числами без повторений: " + string.Join(", ", ArrayListHome.GetNumbersWithoutDuplicates(duplicateNumbers)));
    }
}