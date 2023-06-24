namespace HowSumV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var result = HowSum(new int[] { 2, 3, 4, 7 }, 8);
            var result = HowSum(new int[] { 2, 3}, 7);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static int[] HowSum(int[] arr, int targetSum)
        {
            List<int[]> table = Enumerable.Repeat<int[]>(null, targetSum + 1).ToList();
            table[0] = Array.Empty<int>();
            for (int i = 0; i <= targetSum; i++)
            {
                if (table[i] != null)
                {
                    foreach (var item in arr)
                    {
                        if (i + item <= targetSum)
                        {
                            table[i + item] = new int[table[i].Length + 1];
                            Array.Copy(table[i], table[i + item], table[i].Length);
                            table[i + item][table[i + item].Length - 1] = item;
                        }
                    }
                }
            }
            return table[targetSum];
        }
    }
}