using System;

namespace KnapSack_Dynamic_programming
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxcapacity = 10;
            const int n = 4;
            int[] weights = { 0, 8, 2, 6, 1 };
            int[] values = { 0, 50, 150, 210, 30 };
            int[,] data = new int[5, 11];
            string[] itemNames = { "Microwave", "Drone", "Monitor", "kettle" };

            GetMaxValueInContainer(maxcapacity, n, weights, values, data);
            Console.WriteLine($"Max value of items included in container:{data[n, maxcapacity]}");
            OutputItemInclusionStatus(n, maxcapacity, weights, values, itemNames, data);

            Console.WriteLine( $"Max profit by recussion is {knapsackReccursion(maxcapacity,n,weights,values)} ");
          
        }

        private static void OutputItemInclusionStatus(int n, int maxcapacity, int[] weights, int[] values, string[] itemNames, int[,] data)
        {
            int i = n;
            int j = maxcapacity;
            while(i>0 && j > 0)
            {
                if (data[i, j] == data[i - 1, j]){
                    Console.WriteLine("item "+itemNames[i-1]+"not included in the knapsack" );
                }
                else
                {
                    Console.WriteLine("item " + itemNames[i-1] + " is included in the knapsack");
                    j = j - weights[i];
                }
                i--;
            }
        }

        private static void GetMaxValueInContainer(int maxcapacity, int n, int[] weights, int[] values, int[,] data)
        {
            for (int itemNum = 0; itemNum <= n; itemNum++)
            {
                for (int capacity = 0; capacity <= maxcapacity; capacity++)
                {
                    if (itemNum == 0 || capacity == 0)
                    {
                        data[itemNum, capacity] = 0;
                    }
                    else if (weights[itemNum] <= capacity)
                    {
                        data[itemNum, capacity] =
                             Math.Max(data[itemNum - 1, capacity],
                             values[itemNum] + data[itemNum - 1, capacity - weights[itemNum]]);
                    }
                    else
                    {
                        data[itemNum, capacity] = data[itemNum - 1, capacity];
                    }
                }
            }
        }


        private static int knapsackReccursion(int capacity, int n, int[] weights, int[] values)
        {
            if (n == 0 || capacity == 0)
            {
                return 0;
            }
            else if (weights[n - 1] > capacity)
            {
                return knapsackReccursion(capacity, n - 1, weights, values);
            }
            else
            {
                return Math.Max(values[n - 1] + knapsackReccursion(capacity - weights[n - 1], n - 1, weights, values),
                    knapsackReccursion(capacity, n - 1, weights, values));
            }
        }


    }

  
}
