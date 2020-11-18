using System;
using System.Collections.Generic;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"Value of {nameof(number)} cannot be less zero.");
            }

            if (number == int.MaxValue)
            {
                return null;
            }

            var tail = new List<int>();

            while (number != 0)
            {
                var lastNumeral = number % 10;
                var prevNumeral = (number / 10) % 10;
                if (lastNumeral > prevNumeral && prevNumeral != 0)
                {
                    number /= 100;
                    number = (number * 10) + lastNumeral;
                    tail.Add(prevNumeral);
                    break;
                }

                tail.Add(lastNumeral);
                number /= 10;
            }

            if (number == 0)
            {
                return null;
            }

            tail.Sort();
            var result = number;
            for (int i = 0; i < tail.Count; i++)
            {
                result = (result * 10) + tail[i];
            }

            return result;
        }
    }
}
