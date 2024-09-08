using System;
using System.IO;

public class Day1
{
	public static void Solution()
	{
		string path = @"C:\Users\Zain\Documents\code stuffs\tech assessments\mha developer test\MHA_Dev_Test\Dev_Test\input.txt";

        using (StreamReader reader = new StreamReader(path))
		{
			string line;
			int total = 0;
			while ((line = reader.ReadLine()) != null)
			{
				int sumLine = 0;
				string str1 = "";
				string str2 = "";
				string concatStr = "";
				char? num1 = null;
				char? num2 = null;
                for (int i = 0; i < line.Length; i++)
				{
					if (char.IsDigit(line[i]))
					{
						if (num1 == null)
							num1 = line[i];
						num2 = line[i];
					}
				}
				str1 = num1.ToString();
				str2 = num2.ToString();
				concatStr = str1 + str2;
				sumLine = int.Parse(concatStr);
				total += sumLine;
			}
			Console.WriteLine($"Day 1 total {total}");
		}
	}
}
