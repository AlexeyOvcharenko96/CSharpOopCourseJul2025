namespace ArrayListHomeTask;

public class ArrayListHome
{
    public static List<string> ReadFileLines(string filePath)
    {
        List<string> fileLines = new List<string>();

        try
        {
            using StreamReader reader = new(filePath);
            string? currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                fileLines.Add(currentLine);
            }
        }

        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Файл не найден: {ex.Message}");
        }

        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Нет доступа к файлу: {ex.Message}");
        }

        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }

        return fileLines;
    }

    public static void RemoveEvenNumbers(List<int> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }
    }

    public static List<int> GetNumbersWithoutDuplicates(List<int> list)
    {
        List<int> numbersWithoutDuplicates = new List<int>(list.Capacity);

        foreach (int number in list)
        {
            if (!numbersWithoutDuplicates.Contains(number))
            {
                numbersWithoutDuplicates.Add(number);
            }
        }

        return numbersWithoutDuplicates;
    }
}