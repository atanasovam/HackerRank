using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HackerRank
{
    class Warmups
    {
        public void ExecuteWarmupChallenges()
        {
            // List<List<int>> input = new List<List<int>>();
            // input.Add(new List<int>() { 11, 2, 4 });
            // input.Add(new List<int>() { 4, 5, 6 });
            // input.Add(new List<int>() { 10, 8, -12 });
            // 
            // this.DiagonalDifference(input);
            // this.PlusMinus(new int[8] { 1, 2, 3, -1, -2, -3, 0, 0 });
            // this.Staircase(6);
            // this.MiniMaxSum(new int[5] { 793810624, 895642170, 685903712, 623789054, 468592370 });
            // 
            // Console.WriteLine(this.BirthdayCakeCandles(new int[3] { 3, 8, 8 }));
            // Console.WriteLine(this.TimeConversion("12:45:54PM"));
            // Console.WriteLine(this.PalindromicBorder("ababa"));
            // Console.WriteLine(this.GradingStudents(new List<int> { 73, 67, 38, 33 }));
            // this.CountApplesAndOranges(7, 10, 4, 12, new int[3] { 2, 3, -4 }, new int[3] { 3, -2, -4 });
            // this.Kangaroo(0, 3,4,2);
            // this.BreakingRecords(new int[10] { 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 });

            // Console.WriteLine(this.Birthday(new List<int> { 73, 67, 38, 33 }, 3, 2));
            // Console.WriteLine(this.Birthday(new List<int> { 1, 1, 1, 1, 1, 1 }, 3, 2));
            // Console.WriteLine(this.DivisibleSumPairs(6, 3, new int[6] { 1, 3, 2, 6, 1, 2 }));
            // Console.WriteLine(this.DivisibleSumPairs(6, 3, new int[6] { 1, 2, 3, 4, 5, 6 }));
            // Console.WriteLine(this.MigratoryBirds(new List<int> { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4 }));
            //Console.WriteLine(this.DayOfProgrammer(1918));
        }

        int PalindromicBorder(string str)
        {
            int bordersCount = 0;
            char currentFirst, currentLast;
            string substring = str;
            int currentEndIndex;

            for (int strIndex = 0; strIndex < str.Length - 1; strIndex++)
            {
                substring = str.Substring(strIndex);
                if (substring.Length % 2 == 0) currentEndIndex = substring.Length / 2;
                else currentEndIndex = substring.Length / 2 - 1;

                for (int i = 0; i <= currentEndIndex; i++)
                {
                    currentFirst = substring[i];
                    currentLast = substring[substring.Length - 1 - i];

                    if (currentFirst != currentLast) break;
                    bordersCount++;
                }
            }

            for (int strIndex = str.Length - 1; strIndex > 1; strIndex--)
            {
                substring = str.Substring(0, strIndex);
                if (substring.Length % 2 == 0) currentEndIndex = substring.Length / 2;
                else currentEndIndex = substring.Length / 2 - 1;

                for (int i = 0; i <= currentEndIndex; i++)
                {
                    currentFirst = substring[i];
                    currentLast = substring[substring.Length - 1 - i];

                    if (currentFirst != currentLast) break;
                    bordersCount++;
                }
            }

            return bordersCount;
        }

        string TimeConversion(string str)
        {
            Regex regex = new Regex(@"((\d\d):(\d\d:\d\d))(PM|AM)");
            Match match = regex.Match(str);

            if (!match.Success) throw new Exception();

            StringBuilder sb = new StringBuilder(str.Length);
            GroupCollection groups = match.Groups;
            string time = groups[1].ToString();
            string amOrPm = groups[4].ToString().ToLower();
            string hoursResult;

            if (groups[2].ToString() == "12")
            {
                hoursResult = amOrPm == "am" ? "00" : "12";
                sb.Append($"{hoursResult}:{groups[3]}");
                return sb.ToString();
            }

            if (amOrPm == "am") return time;

            int hours = Int16.Parse(groups[2].ToString());
            hoursResult = hours + 12 == 24 ? "00" : (hours + 12).ToString();

            sb.Append($"{hoursResult}:{groups[3]}");
            return sb.ToString();
        }

        int BirthdayCakeCandles(int[] candlesList)
        {
            int tallestCandle = Int32.MinValue;
            int currentTallest, currentFirst, currentSecond;

            for (int i = 0; i < candlesList.Length - 1; i += 2)
            {
                currentFirst = candlesList[i];
                currentSecond = candlesList[i + 1];

                currentTallest = Math.Max(currentFirst, currentSecond);
                tallestCandle = Math.Max(currentTallest, tallestCandle);
            }

            if (candlesList.Length % 2 != 0)
            {
                tallestCandle = Math.Max(candlesList[candlesList.Length - 1], tallestCandle);
            }

            int[] tallestCandleList = candlesList.Where(a => a == tallestCandle).ToArray();

            return tallestCandleList.Length;
        }

        void MiniMaxSum(int[] arr)
        {
            Array.Sort(arr);
            ulong minSum = (ulong)arr[0] + (ulong)arr[1] + (ulong)arr[2] + (ulong)arr[3];
            Array.Reverse(arr);
            ulong maxSum = (ulong)arr[0] + (ulong)arr[1] + (ulong)arr[2] + (ulong)arr[3];

            Console.WriteLine($"{minSum} {maxSum}");
        }

        void Staircase(int n)
        {
            int spacesCount, hashtagsCount;
            StringBuilder currentLine;

            for (int i = 0; i < n; i++)
            {
                spacesCount = n - i - 1;
                hashtagsCount = n - spacesCount;
                currentLine = new StringBuilder().Append(' ', spacesCount).Append('#', hashtagsCount);
                Console.WriteLine(currentLine.ToString());
            }
        }

        void PlusMinus(int[] arr)
        {
            int zeroesCount = 0;
            int positiveNumsCount = 0;
            int negativeNumsCount = 0;

            foreach (int number in arr)
            {
                if (number > 0) positiveNumsCount++;
                else if (number < 0) negativeNumsCount++;
                else zeroesCount++;
            }

            double positiveResult = (double)positiveNumsCount / arr.Length;
            double negativeResult = (double)negativeNumsCount / arr.Length;
            double zeroesResult = (double)zeroesCount / arr.Length;

            Console.WriteLine($"{positiveResult}");
            Console.WriteLine($"{negativeResult}");
            Console.WriteLine($"{zeroesResult}");
        }

        int DiagonalDifference(List<List<int>> arr)
        {
            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int i = 0, j = -1; i < arr.Count; i++, j++)
            {
                firstDiagonalSum += arr[i][j + 1];
            }

            for (int i = arr.Count - 1, j = -1; i >= 0; i--, j++)
            {
                secondDiagonalSum += arr[i][j + 1];
            }

            return Math.Abs(firstDiagonalSum - secondDiagonalSum);
        }
    }
}
