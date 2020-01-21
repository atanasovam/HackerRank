using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    class Implementation
    {
        public void ExecuteImplementationChallenges()
        {
            // this.BonAppetit(new List<int> { 2, 4, 6 }, 2, 6);
            // this.SockMerchant(9, new int[9] { 10, 20, 20, 10, 10, 30, 50, 10, 20 });
            Console.WriteLine(this.PageCount(5, 3));
        }

        int PageCount(int pagesCount, int pageNumber)
        {
            if (pagesCount % 2 != 0 && pagesCount - 1 == pageNumber) return 0;

            int leftTurnsCount = 0;
            int rightTurnsCount = 0;

            for (int i = 1; i <= pagesCount; i += 2)
            {
                if (i < pageNumber) leftTurnsCount++;
                else if (i > pageNumber) rightTurnsCount++;
            }
            if (leftTurnsCount < rightTurnsCount) return leftTurnsCount;

            return rightTurnsCount;
        }

        int SockMerchant(int n, int[] socks)
        {
            int result = 0;
            Dictionary<int, int> socksDict = new Dictionary<int, int>(); // type, value

            foreach (int s in socks)
            {
                if (!socksDict.ContainsKey(s)) socksDict.Add(s, 1);
                else socksDict[s]++;
            }

            foreach (KeyValuePair<int, int> pair in socksDict)
            {
                if (pair.Value > 1 && pair.Value % 2 == 0) result += pair.Value / 2;
                else result += (pair.Value - 1) / 2;
            }

            return result;
        }

        void BonAppetit(List<int> bill, int briansItemIndex, int annasContribution)
        {
            int briansItem = bill[briansItemIndex];
            int annasBill = 0;

            bill.RemoveAt(briansItemIndex);
            bill.ForEach(item => annasBill += item);
            annasBill /= 2;

            if (annasBill == annasContribution) Console.WriteLine("Bon Appetit");
            else Console.WriteLine(annasContribution - annasBill);
        }

        string Kangaroo(int x1, int v1, int x2, int v2)
        {
            if (x2 > x1 && v2 > v1) return "NO";

            int currentX1Position = x1;
            int currentX2Position = x2;
            if ((x1 + v1) % 2 == 0 && (x2 + v2) % 2 != 0) return "NO";

            while (true)
            {
                currentX1Position += v1;
                currentX2Position += v2;
                if (currentX1Position > currentX2Position) return "NO";
                if (currentX1Position == currentX2Position) return "YES";
            }
            // Your Kangaroo submission got 9.46 points
            /** 10/10 solution :(
             if ((v1 > v2) && ((x1 - x2) % (v2 - v1) == 0)) return "YES";
             return "NO";
             */
        }

        void CountApplesAndOranges(int s, int t, int appleTreeIndex, int orangeTreeIndex, int[] apples, int[] oranges)
        {

            List<int> applesIndexes = apples.Select(appleIndex => appleTreeIndex + appleIndex).ToList();
            List<int> orangesIndexes = oranges.Select(orangeIndex => orangeTreeIndex + orangeIndex).ToList();

            int matchingApples = 0;
            int matchingOranges = 0;

            applesIndexes.ForEach(appleIndex =>
            {
                if (appleIndex >= s && appleIndex <= t) matchingApples++;
            });

            orangesIndexes.ForEach(orangeIndex =>
            {
                if (orangeIndex >= s && orangeIndex <= t) matchingOranges++;
            });

            Console.WriteLine(matchingApples);
            Console.WriteLine(matchingOranges);
        }

        List<int> GradingStudents(List<int> grades)
        {
            int firstDigit;
            int secondDigit;
            int nextMultipleOfFive;
            int difference;

            List<int> modifiedGrades = new List<int>(grades.Count);

            foreach (int grade in grades)
            {
                if (grade < 38)
                {
                    modifiedGrades.Add(grade);
                    continue;
                }

                firstDigit = grade / 10;
                secondDigit = grade % 10;
                nextMultipleOfFive = secondDigit < 5 ? firstDigit * 10 + 5 : firstDigit * 10 + 10;

                difference = nextMultipleOfFive - grade;

                if (difference < 3) modifiedGrades.Add(nextMultipleOfFive);
                else modifiedGrades.Add(grade);
            }

            return modifiedGrades;
        }

        int[] BreakingRecords(int[] scores)
        {
            int[] result = new int[2] { 0, 0 }; // h, l
            int lowest = scores[0];
            int highest = scores[0];

            foreach (int score in scores)
            {
                if (score > highest)
                {
                    highest = score;
                    result[0]++;
                }
                else if (score < lowest)
                {
                    lowest = score;
                    result[1]++;
                }
            }
            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);
            return result;
        }

        int Birthday(List<int> squares, int day, int month)
        {
            int result = 0;
            int currentSum;

            for (int i = 0; i < squares.Count; i++)
            {
                currentSum = squares[i];

                for (int j = i + 1, counter = 1; counter < month; j++, counter++)
                {
                    if (currentSum > day || j >= squares.Count) continue;
                    currentSum += squares[j];
                }

                if (currentSum == day) result++;
            }

            return result;
        }

        string DayOfProgrammer(int year)
        {
            bool isLeapYear = false;
            int programmersDay = 255;

            if (year < 1918) isLeapYear = year % 4 == 0;
            else if (year == 1918) programmersDay += 13;
            else isLeapYear = year % 400 == 0 || year % 4 == 0 && year % 100 != 0;


            if (isLeapYear) programmersDay--;

            DateTime date = new DateTime().AddDays(programmersDay);
            StringBuilder stringDate = new StringBuilder();
            string day = (date.Day < 10 ? "0" + date.Day.ToString() : date.Day.ToString()) + ".";
            string month = (date.Month < 10 ? "0" + date.Month.ToString() : date.Month.ToString()) + ".";

            stringDate
                .Append(day)
                .Append(month)
                .Append(year);

            return stringDate.ToString();
        }

        int MigratoryBirds(List<int> birds)
        {
            Dictionary<int, int> birdsCollection = new Dictionary<int, int>()
            {
                {1,0 },
                {2,0 },
                {3,0 },
                {4,0 },
                {5,0 }
            };

            foreach (int bird in birds) birdsCollection[bird]++;

            int mostFriquentlySightedBird = 0;
            int currentBest = 0, currentValue;

            foreach (int key in birdsCollection.Keys)
            {
                currentValue = birdsCollection[key];
                if (currentBest < currentValue)
                {
                    mostFriquentlySightedBird = key;
                    currentBest = currentValue;
                }
            }

            return mostFriquentlySightedBird;
        }

        int DivisibleSumPairs(int arrLength, int k, int[] arr)
        {
            int matchingPairsCount = 0;

            for (int i = 0; i < arrLength - 1; i++)
            {
                for (int j = i + 1; j < arrLength; j++)
                {
                    if ((arr[i] + arr[j]) % k == 0) matchingPairsCount++;
                }

            }

            return matchingPairsCount;
        }
    }
}
