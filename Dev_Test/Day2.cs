using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Day2
{
    public static void Solution()
    {
        const int redLimit = 12, greenLimit = 13, blueLimit = 14;
        int sumOfValidGames = 0;
        string path = @"C:\Users\Zain\Documents\code stuffs\tech assessments\mha developer test\MHA_Dev_Test\Dev_Test\Day_2_input.txt";
        using (StreamReader reader = new StreamReader(path))
        {
            string game;
            while ((game = reader.ReadLine()) != null)
            {
                string[] pieces = game.Split(":");
                int gameId = int.Parse(pieces[0].Replace("Game ", "").Trim());

                string[] pulledData = pieces[1].Split(';');

                bool validGame = true;
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
                    if (redCount > redLimit || greenCount > greenLimit || blueCount > blueLimit)
                    { 
                        validGame = false;
                        break ;
                    }
                }
                if (validGame == true)
                    sumOfValidGames += gameId;
            }
            Console.WriteLine($"Day 2 total {sumOfValidGames}");
        }
    }
}