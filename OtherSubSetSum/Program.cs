using System;
using System.Collections.Generic;

namespace OtherSubSetSum
{
    internal class Program
    {
        static bool isSubsetSum(int[] set)
        {
            int max = 0;
            List<int> list = new List<int>();
            for (int i = 0; i < set.Length; i++)
            {
                list.Add(set[i]);
                if (set[i] > max)
                {
                    max = set[i];
                }
            }
            list.Remove(max);
            int[] set2 = new int[list.Count];
            for (int i = 0; i < set2.Length; i++)
            {
                set2[i] = list[i];
            }
            int sum = max;
            int n = set2.Length;
            
            bool[,] subset = new bool[sum + 1, n + 1];
            
            for (int i = 0; i <= n; i++)
                subset[0, i] = true;
            
            for (int i = 1; i <= sum; i++)
                subset[i, 0] = false;

            for (int i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    subset[i, j] = subset[i, j - 1];
                    if (i >= set[j - 1])
                        subset[i, j] = subset[i, j] || subset[i - set[j - 1], j - 1];
                }
            }

            return subset[sum, n];
        }

        // Driver code
        public static void Main()
        {
            Console.WriteLine("girin: ");
            int a = int.Parse(Console.ReadLine());
            int[] arr = new int[a];
            for (int i = 0; i < a; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(isSubsetSum(arr));
        }

    }
}
