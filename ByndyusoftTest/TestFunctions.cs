using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ByndyusoftTest
{
    public static class TestFunctions
    {
        public static Task<double> SumTwoMinAsync<T>(this IEnumerable<T> enumerable, [NotNull] Func<T, double> selector)
        {
            return Task.Run(() => enumerable.SumTwoMin(selector));
        }
        
        public static Task<double> SumTwoMinAsync<T>(double[] arr)
        {
            return Task.Run(() => SumTwoMin(arr));
        }
        
        /// <summary>Slow, but for IEnumerable</summary>
        /// <returns>The sum of the two minimum values</returns>
        public static double SumTwoMin<T>(this IEnumerable<T> enumerable, Func<T, double> selector)
        {
            if (enumerable is null || selector is null) throw new ArgumentNullException();
            else if (enumerable.Count() == 0) throw new InvalidOperationException("Enumerable is empty");

            var doubles = enumerable.Select(selector);
            var min1 = double.NaN;
            var min2 = double.NaN;
            
            foreach (var element in doubles)
            {
                if (double.IsNaN(min1))
                {
                    min1 = element;
                }
                else if (double.IsNaN(min2))
                {
                    min2 = element;
                }
                else if (min1 > element)
                {
                    if (min2 > min1)
                    {
                        min2 = min1;
                    }
                    min1 = element;
                }
                else if (min2 > element)
                {
                    min2 = element;
                }
            }

            return min1 + (double.IsNaN(min2) ? 0 : min2);
        }
        
        /// <summary>Faster than IEnumerable, but only for double arrays</summary>
        /// <returns>The sum of the two minimum values</returns>
        public static double SumTwoMin(double[] arr)
        {
            if (arr is null) throw new ArgumentNullException();
            else if (arr.Length == 0) throw new InvalidOperationException("Array is empty");
            
            var min1 = arr[0];
            var min2 = arr.Length > 1 ? arr[1] : 0;
            for (int i = 2; i < arr.Length; i++)
            {
                if (min1 > arr[i])
                {
                    if (min2 > min1)
                    {
                        min2 = min1;
                    }
                    min1 = arr[i];
                }
                else if (min2 > arr[i])
                {
                    min2 = arr[i];
                }
            }

            return min1 + min2;
        }
    }
}