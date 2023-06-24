using System;

namespace Highest_Increase_Pair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 31, -41, 59, 26, -53, 58, 97, -93, -23, 84 };
            int min = int.MaxValue;
            int f = -1, l = -1;
            int answer = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (i < arr.Length - 1)
                {
                    if ((arr[i] - min) > answer)
                    {
                        answer = (arr[i] - min);
                        f = i;
                    }
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                    l = i;
                }
                min = Math.Min(arr[i], min);
            }

            Console.WriteLine("Max Increase is: " + answer);
            Console.WriteLine("First element is: " + f);
            Console.WriteLine("Last element is: " + l);

            Console.ReadLine();
        }
    }
}