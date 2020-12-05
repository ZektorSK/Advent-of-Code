using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

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
            //Day3Part1();
            //Day3Part2();
            //Day4Part1();
            Day4Part2();
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
                int collumn = 0;
                int sizeX = 0;
                string grid = "";
                List<string> gridX = new List<string>();
                List<Day3_Node> gridList = new List<Day3_Node>();

                Console.WriteLine("Calculating the grid...");
                //1. Calculate how big the grid has to be on x, based on y=x/3
                while((line = sr.ReadLine()) != null)
                {
                    gridX.Add(line);
                    collumn++;
                }
                sizeX = collumn * 3;
                Console.WriteLine("Calculated the grid!");

                //2. Find the pattern on each x line and repeat it until it reaches the x
                Console.WriteLine("Calculating the pattern...");
                for (int x = 0; x < gridX.Count; x++)
                {
                    while(gridX[x].Length <= sizeX)
                    {
                        gridX[x] += gridX[x];
                    }
                }
                Console.WriteLine("Calculated the pattern!");

                //3. Convert the grid into node system
                Console.WriteLine("Converting into matrix grid...");
                int row = 0;
                foreach (string s in gridX)
                {
                    for (int col = 0; col < s.Length; col++)
                    {
                        Day3_Node node = new Day3_Node(col, row, s[col]);
                        gridList.Add(node);
                    }
                    row++;
                }
                Console.WriteLine("Converted!");

                //4. Check the node on each y+1 and x+3 and assign them to a value
                Console.WriteLine("Calculating the amount of trees...");
                int fx = 0;
                int fy = 0;
                int count = 0;
                while(gridList.Find(x => x.col == fx && x.row == fy) != null)
                {
                    if (gridList.Find(x => x.col == fx && x.row == fy).value == '#')
                    {
                        Console.WriteLine($"Calculated [{fx},{fy}]");
                        fx += 3;
                        fy += 1;
                        count++;
                    }
                    else
                    {
                        fx += 3;
                        fy += 1;
                    }
                }

                //5. Return the value
                Console.WriteLine($"Calculated the trees! == {count}");
            }
            static void Day3Part2()
            {
                int answer1 = 0;
                int answer2 = 0;
                int answer3 = 0;
                int answer4 = 0;
                int answer5 = 0;

                for (int x = 1; x <= 5; x++)
                {
                    StreamReader sr = new StreamReader(@"D:\My Stuff\programming\Advent of Code\input3\input.txt");
                    string line = "";
                    int collumn = 0;
                    int sizeX = 0;
                    string grid = "";
                    List<string> gridX = new List<string>();
                    List<Day3_Node> gridList = new List<Day3_Node>();

                    //1. Calculate how big the grid has to be on x, based on y=x/3
                    while ((line = sr.ReadLine()) != null)
                    {
                        gridX.Add(line);
                        collumn++;
                    }
                    sizeX = Day3Part2FunctionPattern(collumn, x);
                    Console.WriteLine($"sizeX in function[{x}]: {sizeX}");

                    //2. Find the pattern on each x line and repeat it until it reaches the x
                    for (int z = 0; z < gridX.Count; z++)
                    {
                        while (gridX[z].Length <= sizeX)
                        {
                            gridX[z] += gridX[z];
                        }
                    }

                    //3. Convert the grid into node system
                    int row = 0;
                    foreach (string s in gridX)
                    {
                        for (int col = 0; col < s.Length; col++)
                        {
                            Day3_Node node = new Day3_Node(col, row, s[col]);
                            gridList.Add(node);
                        }
                        row++;
                    }
                    switch (x)
                    {
                        case 1:
                            answer1 += Day3Part2FunctionFunction(1, 1, gridList);
                            Console.WriteLine($"Function 1: {answer1}");
                            break;
                        case 2:
                            answer2 += Day3Part2FunctionFunction(3, 1, gridList);
                            Console.WriteLine($"Function 2: {answer2}");
                            break;
                        case 3:
                            answer3 += Day3Part2FunctionFunction(5, 1, gridList);
                            Console.WriteLine($"Function 3: {answer3}");
                            break;
                        case 4:
                            answer4 += Day3Part2FunctionFunction(7, 1, gridList);
                            Console.WriteLine($"Function 4: {answer4}");
                            break;
                        case 5:
                            answer5 += Day3Part2FunctionFunction(1, 2, gridList);
                            Console.WriteLine($"Function 5: {answer5}");
                            break;
                    }
                }
                BigInteger answer = new BigInteger(answer1) * answer2 * answer3 * answer4 * answer5;

                //4. do five functions and return value
                Console.WriteLine($"Calculated the trees! == {answer}");
            }
            static void Day4Part1()
            {
                StreamReader sr = new StreamReader(@"D:\My Stuff\programming\Advent of Code\input4\input.txt");
                string input = "";
                int count = 0;
                List<string> subInput = new List<string>();

                //1. Assign the input to a string
                while ((input = sr.ReadLine()) != null)
                {
                    string temp = "";
                    while (true)
                    {
                        if (string.IsNullOrEmpty(input) == true)
                        {
                            break;
                        }
                        else
                        {
                            temp += $"{input} ";
                            input = sr.ReadLine();
                        }
                    }
                    subInput.Add(temp);
                }

                //2 Create substrings based on empty lines
                ///thanks to stackexchange!
                for (int x = 0; x < subInput.Count; x++)
                {
                    Console.WriteLine(subInput[x]);
                    Console.WriteLine("");
                }
                int countx = subInput.Count();
                Console.WriteLine(countx);

                for(int x = 0; x < subInput.Count; x++)
                {
                    if(subInput[x].Contains("byr:") && subInput[x].Contains("iyr:") && subInput[x].Contains("eyr:") && subInput[x].Contains("hgt:") &&
                       subInput[x].Contains("hcl:") && subInput[x].Contains("ecl:") && subInput[x].Contains("pid"))
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
            }
            static void Day4Part2()
            {
                StreamReader sr = new StreamReader(@"D:\My Stuff\programming\Advent of Code\input4\input.txt");
                string input = "";
                int count = 0;
                List<Day4_Passport> PassportList = new List<Day4_Passport>();
                List<string> subInput = new List<string>();

                //1. Assign the input to a string
                while ((input = sr.ReadLine()) != null)
                {
                    string temp = "";
                    while (true)
                    {
                        if(string.IsNullOrEmpty(input) == true)
                        {
                            break;
                        }
                        else
                        {
                            temp +=$"{input} ";
                            input = sr.ReadLine();
                        }
                    }
                    subInput.Add(temp);
                }

                //2 Create substrings based on empty lines
                ///thanks to stackexchange!
                for (int x = 0; x < subInput.Count; x++)
                {
                    Console.WriteLine(subInput[x]);
                    Console.WriteLine("");
                }
                int countx = subInput.Count();
                Console.WriteLine(countx);

                //3. check for all the text and create an object
                for(int x = 0; x < subInput.Count; x++)
                {
                    string tempLine = subInput[x];
                    int _byr = int.Parse(Day4Part1FunctionField("byr:", tempLine));
                    Console.WriteLine(_byr);
                    int _iyr = int.Parse(Day4Part1FunctionField("iyr:", tempLine));
                    Console.WriteLine(_iyr);
                    int _eyr = int.Parse(Day4Part1FunctionField("eyr:", tempLine));
                    Console.WriteLine(_eyr);
                    int _hgt = int.Parse(Day4Part1FunctionField("hgt:", tempLine).Remove(Day4Part1FunctionField("hgt:", tempLine).IndexOf("c")));
                    Console.WriteLine(_hgt);
                    string _hcl = Day4Part1FunctionField("hcl:", tempLine);
                    Console.WriteLine(_hcl);
                    string _ecl = Day4Part1FunctionField("ecl:", tempLine);
                    Console.WriteLine(_ecl);
                    float _pid = float.Parse(Day4Part1FunctionField("pid:", tempLine));
                    Console.WriteLine(_pid);
                    int _cid = int.Parse(Day4Part1FunctionField("cid:", tempLine));
                    Console.WriteLine(_cid);
                    bool _isValid = false;
                    if (_byr != 0 && _iyr != 0 && _eyr != 0 && _hgt != 0 && _hcl != "0" && _ecl != "0" && _pid != 0)
                    {
                        _isValid = true;
                    }
                    Console.WriteLine(_isValid);
                    Day4_Passport passport = new Day4_Passport(_byr, _iyr, _eyr, _hgt, _hcl, _ecl, _pid, _cid, _isValid);
                    PassportList.Add(passport);
                    Console.WriteLine($"[{x}]\nbirth year: {passport.byr}, issue year: {passport.iyr}, expiration year: {passport.eyr}, " +
                    $"height: {passport.hgt}, hair color: {passport.hcl}, eye color: {passport.ecl}, country id: {passport.cid}, is valid: {passport.isValid}\n");
                }

                //2. iterate over each object and check which ones have isValid = true, count them


                //3. return value

            }

            static int Day3Part2FunctionFunction(int f1, int f2, List<Day3_Node> gList)
            {
                int fx1 = 0;
                int fy1 = 0;
                int count = 0;
                while (gList.Find(x => x.col == fx1 && x.row == fy1) != null)
                {
                    if (gList.Find(x => x.col == fx1 && x.row == fy1).value == '#')
                    {
                        fx1 += f1;
                        fy1 += f2;
                        count++;
                    }
                    else
                    {
                        fx1 += f1;
                        fy1 += f2;
                    }
                }
                return count;
            }
            static int Day3Part2FunctionPattern(int c, int x)
            {
                switch (x)
                {
                    case 1:
                        return c;
                    case 2:
                        return c * 10;
                    case 3:
                        return c * 10;
                    case 4:
                        return c * 10;
                    case 5:
                        return c * 10;
                    default:
                        return 0;
                }
            }
            static string Day4Part1FunctionField(string par, string line)
            {
                string back = "";
                int parINT = line.IndexOf(par);
                if(parINT == -1)
                {
                    return "0";
                }
                else
                {
                    while (line[parINT] != ':')
                    {
                        parINT += 1;
                    }
                    parINT += 1;
                    while (char.IsWhiteSpace(line[parINT]) != true)
                    {
                        back += line[parINT];
                        parINT++;
                    }
                    return back;
                }
            }
        }
    }

    public class Day3_Node
    {
        public int col { get; set; }
        public int row { get; set; }
        public char value { get; set; }

        public Day3_Node(int _col, int _row, char _value)
        {
            col = _col;
            row = _row;
            value = _value;
        }
    }
    public class Day4_Passport
    {
        //birth year
        public int byr { get; set; }
        //issue year
        public int iyr { get; set; }
        //expiration year
        public int eyr { get; set; }
        //height
        public int hgt { get; set; }
        //hair color
        public string hcl { get; set; }
        //eye color
        public string ecl { get; set; }
        //passport ID (long number)
        public float pid { get; set; }
        //country ID (optional)
        public int cid { get; set; }
        //boolean value to determnite if the passport is valid
        public bool isValid { get; set; }

        public Day4_Passport(int _byr, int _iyr, int _eyr, int _hgt, string _hcl, string _ecl, float _pid, int _cid, bool _isValid)
        {
            byr = _byr;
            iyr = _iyr;
            eyr = _eyr;
            hgt = _hgt;
            hcl = _hcl;
            ecl = _ecl;
            pid = _pid;
        }
    }
}

