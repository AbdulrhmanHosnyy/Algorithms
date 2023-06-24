namespace BestSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  write a function that takes in an array of numbers and a targetSum as arguments
            //  The function shoud return an array containing the shortest combination of numbers that adds up yo exactly the targetSum
            //  if there is a tie return any one of the shortest


            var result = BestSum(new int[] { 1, 2, 5, 25 }, 100);
            //var result = BestSum(new int[] { 1, 926, 663, 857, 128, 916, 823, 470, 490, 540, 942, 159, 866, 856, 853, 939, 543 },
            //                     1952844);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static int[] BestSum(int[] arr, int targetSum, Dictionary<int, List<int>> memo = null)
        {
            memo ??= new Dictionary<int, List<int>>();
           if (memo.ContainsKey(targetSum)) return memo[targetSum].ToArray();
            if (targetSum < 0) return null;
            if (targetSum == 0) return Array.Empty<int>();

            int []? shortestCombination = null;

            for (int i = 0; i < arr.Length; i++)
            {
                var result = BestSum(arr, targetSum - arr[i], memo);
                if (result != null)
                {
                    var combination = result.Concat(new int[] { arr[i] }).ToArray();
                    if (shortestCombination == null || combination.Length < shortestCombination.Length) 
                        shortestCombination = combination;
                }
            }
            memo.Add(targetSum, shortestCombination.ToList<int>());
            return shortestCombination;
        }
    }
}