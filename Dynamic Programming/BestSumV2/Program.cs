namespace BestSumV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  write a function that takes in an array of numbers and a targetSum as arguments
            //  The function shoud return an array containing the shortest combination of numbers that adds up yo exactly the targetSum
            //  if there is a tie return any one of the shortest


            //var result = BestSum(new int[] { 1, 2, 5, 25 }, 100);
            var result = BestSum(new int[] { 5, 3, 4, 7 }, 7);

            //var result = BestSum(new int[] { 1, 926, 663, 857, 128, 916, 823, 470, 490, 540, 942, 159, 866, 856, 853, 939, 543 },
            //                     1952844);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static int[] BestSum(int[] arr, int targetSum)
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
                            int [] combination = new int[table[i].Length + 1];
                            Array.Copy(table[i], combination, table[i].Length);
                            combination[table[i].Length] = item;
                            if (table[i + item] == null || table[i + item].Length > combination.Length)
                            {
                                table[i + item] = new int[table[i].Length + 1];
                                table[i + item] = combination;
                            }
                            
                        }
                    }
                }
            }
            return table[targetSum];
        }
    }
}