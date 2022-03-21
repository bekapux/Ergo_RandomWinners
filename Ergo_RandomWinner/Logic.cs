using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ergo_RandomWinner
{
    public class Logic
    {
        public static int GetNumberOfWinners()
        {
            Console.WriteLine("How many winners?");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int NumberOfWinners);
            if (isValidNumber == false)
            {
                Console.WriteLine("Invalid Number");
                throw new Exception();
            }
            return NumberOfWinners;
        }

        public static string GetFilePath()
        {
            string CurrentDirPath = Directory.GetCurrentDirectory() + "/Here";
            string Result = "";
            try
            {
                Result = Directory.GetFiles(CurrentDirPath)?.FirstOrDefault(x => x.Contains(".txt"));
            }
            catch
            {
                return "";
            }

            if (!string.IsNullOrWhiteSpace(Result))
            {
                Console.WriteLine($"Scanning {Result}\n\n");
            }

            return Result;
        }

        public static List<string> PopulateContenderList(string FilePath)
        {
            List<string> AddressList = new List<string>();

            if (String.IsNullOrWhiteSpace(FilePath))
            {
                throw new Exception();
            }
            foreach (var Line in File.ReadLines(FilePath))
            {
                var TrimmedLine = Line.Trim();
                if (string.IsNullOrWhiteSpace(TrimmedLine) || TrimmedLine.Length != 51 || TrimmedLine[0] != '9')
                {
                    continue;
                }
                AddressList.Add(TrimmedLine);
            }
            return AddressList;
        }

        public static List<string> PickRandom(List<string> List, int NumberOfPicks = 1)
        {
            List<string> SelectedNumbers = new List<string>();

            while (SelectedNumbers.Count < NumberOfPicks)
            {
                var Random = new Random();
                int RandomIndex = Random.Next(List.Count);
                SelectedNumbers.Add(List[RandomIndex]);
                List.RemoveAt(RandomIndex);
            }

            return SelectedNumbers;
        }

        public class Validator
        {
            public static bool ValidateNumberOfWinners(int NumberOfWinners, int AllContendersCount)
            {
                if (NumberOfWinners <= 0)
                {
                    Console.WriteLine("Invalid number of winners");
                    return false;
                }
                else if (AllContendersCount <= NumberOfWinners)
                {
                    Console.WriteLine($"Number Of winners must be less than Number of All contenders ({AllContendersCount})\n\n");
                    return false;
                }
                return true;
            }

            public static bool ValidateContenderList(List<string> ContenderList)
            {
                if (ContenderList.Count <= 0)
                {
                    Console.WriteLine("Number of Contenders is 0. Please check included file");
                    return false;
                }
                return true;
            }

            public static bool ValidateWinnerList(List<string> WinnerList)
            {
                if (WinnerList.Count == 0)
                {
                    Console.WriteLine("Invalid Winner List");
                    return false;
                }
                return true;
            }

            public static bool ValidateFilePath(string Path)
            {
                if (string.IsNullOrWhiteSpace(Path))
                {
                    Console.WriteLine("File Path is Invalid.\n\n\n");
                    return false;
                }
                return true;
            }
        }

        public class Announcement
        {
            public static void AnnounceWinners(List<string> WinnerList)
            {
                Console.WriteLine("\n\nWinners: \n");
                Console.WriteLine(String.Join("\n", WinnerList));
                Console.ReadLine();
            }
        }
    }
}
