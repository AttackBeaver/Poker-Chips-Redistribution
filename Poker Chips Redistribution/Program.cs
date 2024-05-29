using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Chips_Redistribution
{
    class Program
    {
        public static int MinMovesToEquilibrium(int[] chips)
        {
            int totalChips = chips.Sum();
            int numSeats = chips.Length;
            int target = totalChips / numSeats;

            int remainder = totalChips % numSeats;

            int[] diffs = new int[numSeats];
            for (int i = 0; i < numSeats; i++)
            {
                diffs[i] = chips[i] - target;
            }

            for (int i = 0; i < remainder; i++)
            {
                diffs[i]++;
            }

            int maxMoves = 0;
            int currentBalance = 0;

            for (int i = 0; i < numSeats; i++)
            {
                currentBalance += diffs[i];
                maxMoves = Math.Max(maxMoves, Math.Abs(currentBalance));
            }

            return maxMoves;
        }

        static void Main(string[] args)
        {
            int[][] testCases = {
            new int[] {1, 5, 9, 10, 5},
            new int[] {1, 2, 3},
            new int[] {0, 1, 1, 1, 1, 1, 1, 1, 1, 2}
        };

            int[] expectedResults = { 12, 1, 1 };

            for (int i = 0; i < testCases.Length; i++)
            {
                int result = MinMovesToEquilibrium(testCases[i]);
                Console.WriteLine($"Test {i + 1} - Expected: {expectedResults[i]}, Got: {result}");
            }
            Console.ReadKey();
        }
    }
}

