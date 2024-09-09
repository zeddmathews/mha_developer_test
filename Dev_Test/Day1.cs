using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Day1
{
    private static readonly Dictionary<string, string> wordToNumber = new Dictionary<string, string>
    {
        {"one", "1"}, {"two", "2"}, {"three", "3"}, {"four", "4"}, {"five", "5"},
        {"six", "6"}, {"seven", "7"}, {"eight", "8"}, {"nine", "9"}
    };

    public static void Solution()
    {
        string path = @"C:\Users\Zain\Documents\code stuffs\tech assessments\mha developer test\MHA_Dev_Test\Dev_Test\Day_1_input.txt";
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            int total = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string processedLine = ConvertWordsToNumbers(line);
                int sumLine = ExtractFirstLastDigit(processedLine);
                total += sumLine;
            }
            Console.WriteLine($"Day 1 total: {total}");
        }
    }

    private static string ConvertWordsToNumbers(string input)
    {
        foreach (var pair in wordToNumber)
        {
            input = input.Replace(pair.Key, pair.Key + pair.Value + pair.Key);
        }
        return input;
    }

    private static int ExtractFirstLastDigit(string line)
    {
        char? firstDigit = line.FirstOrDefault(c => char.IsDigit(c));
        char? lastDigit = line.LastOrDefault(c => char.IsDigit(c));

        if (firstDigit == null || lastDigit == null)
            return 0;

        string result = string.Concat(firstDigit, lastDigit);
        return int.Parse(result);
    }
}