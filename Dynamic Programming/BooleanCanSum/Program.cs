namespace BooleanCanSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Write a function that takes in an targetSum and an array of numbers as arguments
            //  This function should return a boolean indicating whether or not it is possible to generate the targetSum using 
            //  numbers from the array
            //  You may use an element of the array as many times as needed
            //  All input elements are nonnegative
            Console.WriteLine(CanSum(new int[] {7, 14}, 300));
        }

        static bool CanSum(int[] arr, int targetSum, Dictionary<int, bool> memo = null)
        {
            memo??= new Dictionary<int, bool>();
            if(memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum < 0) return false;
            if(targetSum == 0) return true;
            for (int i = 0; i < arr.Length; i++)
            {
                if (CanSum(arr, targetSum - arr[i], memo))
                {
                    memo[targetSum] = true;
                    return true;
                }
            }
            memo[targetSum] = false;
            return false;
        }
    }
}