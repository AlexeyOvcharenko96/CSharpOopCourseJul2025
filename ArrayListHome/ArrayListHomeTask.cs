using System.Linq;

namespace ArrayListHomeTask;

internal class ArrayListHomeTask
{
    static void Main(string[] args)
    {
        using StreamReader reader = new StreamReader("..\\..\\..\\input.txt");

        List<string> fileLines = new List<string>();

        string currentLine;

        while ((currentLine = reader.ReadLine()) != null)
        {
            fileLines.Add(currentLine);
        }

        Console.WriteLine("Проверка первого пункта задачи:");
        Console.WriteLine(string.Join(", ", fileLines));
        Console.WriteLine();

        List<int> integers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        for (int i = 0; i < integers.Count; i++)
        {
            if (integers[i] % 2 == 0)
            {
                integers.RemoveAt(i);
            }
        }

        Console.WriteLine("Проверка второго пункта задачи:");
        Console.WriteLine(string.Join(", ", integers));
        Console.WriteLine();

        List<int> duplicateIntegers = new List<int> { 10, 2, 3, 4, 5, 7, 7, 9, 101, 10, 101, 13, 4, 164, 15, 164 };

        List<int> integersWithoutDuplicates = new List<int>();

        for (int i = 0; i < duplicateIntegers.Count; i++)
        {
            if (!integersWithoutDuplicates.Contains(duplicateIntegers[i]))
            {
                integersWithoutDuplicates.Add(duplicateIntegers[i]);
            }
        }

        Console.WriteLine("Проверка третьего пункта задачи:");
        Console.WriteLine("Список с повторяющимися целыми числами: " + string.Join(", ", duplicateIntegers));
        Console.WriteLine("Список с целыми числами без повторений: " + string.Join(", ", integersWithoutDuplicates));
        Console.WriteLine();

    }
}