namespace CanSumV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanSum(new int[] { 7, 14 }, 300));
            Console.WriteLine(CanSum(new int[] { 2, 3 }, 7));
            Console.WriteLine(CanSum(new int[] { 5, 3, 4, 7 }, 7));

            Console.ReadLine();
        }
        static bool CanSum(int[] arr, int targetSum)
        {
            bool[] table = new bool[targetSum + 1];
            table[0] = true;
            for (int i = 0; i <= targetSum; i++)
            {
                if (table[i])
                {
                    foreach (var item in arr)
                    {
                        if (i + item <= targetSum)
                            table[i + item] = true;
                    }
                }
            }
            return table[targetSum];
        }
    }
}