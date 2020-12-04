using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Advent_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1Part1();
            //Day1Part2();
            //Day2Part1();
            //Day2Part2();
            Day3Part1();
            Console.ReadLine();

            static void Day1Part1()
            {
                StreamReader sr = new StreamReader(@"D:\My Stuff\programming\Advent of Code\input1\input.txt");
                string line = "";
                List<int> numberList = new List<int>();
                int number1 = 0;
                int number2 = 0;
                int sum = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    numberList.Add(int.Parse(line));
                }
                foreach (int x in numberList)
                {
                    foreach (int y in numberList)
                    {
                        if (y != x)
                        {
                            if (x + y == 2020)
                            {
                                number1 = x;
                                number2 = y;
                                sum = number1 * number2;
                            }
                        }
                    }
                }
                Console.WriteLine(sum);
            }
            static void Day1Part2()
            {
                StreamReader sr = new StreamReader(@"D:\My Stuff\programming\Advent of Code\input1\input.txt");
                string line = "";
                List<int> numberList = new List<int>();
                int number1 = 0;
                int number2 = 0;
                int number3 = 0;
                int sum = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    numberList.Add(int.Parse(line));
                }
                foreach (int x in numberList)
                {
                    foreach (int y in numberList)
                    {
                        if (y != x)
                        {
                            foreach (int z in numberList)
                            {
                                if (z != x && z != y)
                                {
                                    if (z + x + y == 2020)
                                    {
                                        number1 = x;
                                        number2 = y;
                                        number3 = z;
                                        sum = number1 * number2 * number3;
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine(sum);
            }
            static void Day2Part1()
            {
                StreamReader sr = new StreamReader(@"D:\My Stuff\programming\Advent of Code\input2\input.txt");
                string line = "";
                int countCorrect = 0;
                int countAll = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line) != true)
                    {
                        Console.WriteLine($"The text: {line}");
                        //index variable
                        int y = 0;
                        string tempMin = "";
                        while (line[y] != '-')
                        {
                            tempMin += line[y];
                            y++;
                        }
                        y += 1;
                        string tempMax = "";
                        while (char.IsWhiteSpace(line[y]) != true)
                        {
                            tempMax += line[y];
                            y++;
                        }
                        int min = int.Parse(tempMin);
                        int max = int.Parse(tempMax);
                        //increment y to count for the spacebar after the max number
                        y += 1;
                        char letter = line[y];
                        //add 3 spaces to get to the password itself
                        y += 3;
                        string password = line[y..];
                        List<char> passwordCharList = password.ToCharArray().ToList();

                        int letterCount = passwordCharList.Count(x => x == letter);
                        if (letterCount >= min && letterCount <= max)
                        {
                            countCorrect++;
                        }
                        countAll++;
                    }
                }
                Console.WriteLine($"The count of all passwords: {countAll}");
                Console.WriteLine($"The count of possible passwords: {countCorrect}");
            }
            static void Day2Part2()
            {
                StreamReader sr = new StreamReader(@"D:\My Stuff\programming\Advent of Code\input2\input.txt");
                string line = "";
                int countCorrect = 0;
                int countAll = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line) != true)
                    {
                        Console.WriteLine($"The text: {line}");
                        //index variable
                        int y = 0;
                        string tempPos1 = "";
                        while (line[y] != '-')
                        {
                            tempPos1 += line[y];
                            y++;
                        }
                        y += 1;
                        string tempPos2 = "";
                        while (char.IsWhiteSpace(line[y]) != true)
                        {
                            tempPos2 += line[y];
                            y++;
                        }
                        int Pos1 = int.Parse(tempPos1);
                        Pos1 -= 1;
                        int Pos2 = int.Parse(tempPos2);
                        Pos2 -= 1;
                        //increment y to count for the spacebar after the max number
                        y += 1;
                        char letter = line[y];
                        //add 3 spaces to get to the password itself
                        y += 3;
                        string password = line[y..];
                        List<char> passwordCharList = password.ToCharArray().ToList();

                        if ((passwordCharList[Pos1] == letter && passwordCharList[Pos2] != letter) || (passwordCharList[Pos2] == letter && passwordCharList[Pos1] != letter))
                        {
                            countCorrect++;
                        }
                        countAll++;
                        Console.WriteLine($"The count of all passwords: {countAll}");
                        Console.WriteLine($"The count of possible passwords: {countCorrect}");
                    }
                }
            }
            static void Day3Part1()
            {
                StreamReader sr = new StreamReader(@"D:\My Stuff\programming\Advent of Code\input3\input.txt");
                string line = "";
                //1. Calculate how big the grid has to be on x, based on y=x/3
                //2. Find the pattern on each x line and repeat it until it reaches the x
                //3. Convert the grid into node system
                //4. Check the node on each y+1 and x+3 and assign them to a value
                //5. Return the value
            }
        }
    }

    public class Day3_Node
    {
        int x { get; set; }
        int y { get; set; }
        char value { get; set; }

        public Day3_Node(int _x, int _y, char _value)
        {
            x = _x;
            y = _y;
            value = _value;
        }
    }
}

