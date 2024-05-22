using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Chips_Redistribution
{
    internal class Program
    {
        /// <summary>
        /// Метод для вычисления минимального количества перемещений фишек для их равномерного распределения.
        /// </summary>
        /// <param name="chips">Массив количества фишек на каждом месте.</param>
        /// <returns>Минимальное количество перемещений.</returns>
        public static int MinMovesToEqualize(int[] chips)
        {
            if (chips == null || chips.Length == 0)
            {
                throw new ArgumentException("Массив фишек не должен быть пустым или null.");
            }

            int totalChips = chips.Sum();
            int n = chips.Length;

            if (totalChips % n != 0)
            {
                throw new InvalidOperationException("Фишки не могут быть распределены равномерно.");
            }

            int target = totalChips / n;
            int moves = 0;
            int currentSurplus = 0;

            for (int i = 0; i < n; i++)
            {
                currentSurplus += chips[i] - target;
                moves += Math.Abs(currentSurplus);
            }

            return moves;
        }

        /// <summary>
        /// Основной метод для запуска тестовых примеров.
        /// </summary>
        static void Main(string[] args)
        {
            var testCases = new List<int[]>
            {
                new int[] {1, 5, 9, 10, 5},
                new int[] {1, 2, 3},
                new int[] {0, 1, 1, 1, 1, 1, 1, 1, 1, 2}
            };

            foreach (var chips in testCases)
            {
                try
                {
                    int result = MinMovesToEqualize(chips);
                    Console.WriteLine($"Фишки: {string.Join(", ", chips)} => Мин. перемещений: {result}");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Фишки: {string.Join(", ", chips)} => Ошибка: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }
    }
}
