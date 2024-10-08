class Program
{

    public int[] GetMissingElements(int[] list)
    {
        List<int> missingNumbers = new List<int>();
        int min = list[0];
        int max = list[0];

        foreach (var num in list)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }

        for (int i = min; i <= max; i++)
        {
            if (Array.IndexOf(list, i) == -1)
            {
                missingNumbers.Add(i);
            }
        }

        int[] arrMissingNumbers = missingNumbers.ToArray();

        return arrMissingNumbers;
    }

    public int[] GetBoolArr(int[] list)
    {
        int[] boolArr = new int[list.Length];

        for (int i = 0; i < list.Length; i++)
        {
            boolArr[i] = list[i] % 2 == 1 ? 1 : 0;
        }

        return boolArr;
    }

    public static string ReplaceAndGetSubstring(string input, char find, char replace)
    {
        int index = input.IndexOf(find);

        if (index == -1)
        {
            return string.Empty; 
        }

        string modifiedString = input.Remove(index, 1).Insert(index, replace.ToString());
        return modifiedString.Substring(index);
    }

    static void Main()
    {
        Program program = new Program();

        int[] numbers = { 1, 2, 4, 5, 6, 8, 10 };

        int[] missingNumbers = program.GetMissingElements(numbers);
        Console.WriteLine("Пропущенные числа: " + string.Join(", ", missingNumbers));

        int[] boolArr = program.GetBoolArr(numbers);
        Console.WriteLine("Проверка на четность: " + string.Join(", ", boolArr));

        string s = "Hello morld!";
        char find = 'm';
        char replace = 'w';
        string result = ReplaceAndGetSubstring(s, find, replace);
        Console.WriteLine("Результат: " + result);
    }

}