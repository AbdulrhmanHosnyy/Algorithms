namespace HowSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Write a function that takes in an targetSum and an array of numbers as arguments
            //  This function should return an array containing any combination of element that end up to exactly the targetSum
            //  if there is no combination that adds up to the targetSum, then retun null 
            //  if there are multiple combinations possible, you may return any
            var result = HowSum(new int[] { 2, 3, 4, 7 }, 8);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
        static int[] HowSum(int[] arr, int targetSum, Dictionary<int, List<int>> memo = null)
        {
            memo??= new Dictionary<int, List<int>>();
            if(memo.ContainsKey(targetSum)) return memo[targetSum].ToArray();
            if (targetSum < 0) return null;
            if (targetSum == 0) return Array.Empty<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var result = HowSum(arr, targetSum - arr[i], memo);
                if (result != null)
                {
                    memo.Add(targetSum, new List<int>(result.Concat(new int[] { arr[i] }).ToList<int>()));
                    return result.Concat(new int[] { arr[i] }).ToArray();
                }
            }
            memo[targetSum] = null;
            return null;
        }
    }
}