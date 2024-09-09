using System;
using System.IO;

public class Day2P2
{
    public static void Solution()
    {
        string path = @"C:\Users\Zain\Documents\code stuffs\tech assessments\mha developer test\MHA_Dev_Test\Dev_Test\Day_2_input.txt";
        int totalPowerSum = 0;

        using (StreamReader reader = new StreamReader(path))
        {
            string game;
            while ((game = reader.ReadLine()) != null)
            {
                string[] pieces = game.Split(':');
                int gameId = int.Parse(pieces[0].Replace("Game ", "").Trim());

                string[] pulledData = pieces[1].Split(';');

                int maxRed = 0, maxGreen = 0, maxBlue = 0;

                foreach (var pull in pulledData)
                {
                    var colours = pull.Split(',');
                    int redCount = 0, greenCount = 0, blueCount = 0;
                    foreach (var colour in colours)
                    {
                        var reduced = colour.Trim();
                        var numCol = reduced.Split(' ');

                        int cubeTotal = int.Parse(numCol[0]);
                        string colourType = numCol[1];
                        if (colourType == "red")
                            redCount += cubeTotal;
                        else if (colourType == "green")
                            greenCount += cubeTotal;
                        else if (colourType == "blue")
                            blueCount += cubeTotal;
                    }
                    if (redCount > maxRed) maxRed = redCount;
                    if (greenCount > maxGreen) maxGreen = greenCount;
                    if (blueCount > maxBlue) maxBlue = blueCount;
                }
                int power = maxRed * maxGreen * maxBlue;
                totalPowerSum += power;
            }

            Console.WriteLine($"Day 2 Part 2 total power sum: {totalPowerSum}");
        }
    }
}
