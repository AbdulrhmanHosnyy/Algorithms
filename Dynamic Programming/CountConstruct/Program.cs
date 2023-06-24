namespace CountConstruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Write a function that accepts target string and and array of strings
            //  The function should return num of ways indicating whether or not target can be constructed by concatenating 
            //  elements of the array
            //  you may reuse elements of the wordbank as many times as needed 

            var numOfWays = CountConstruct(new string[] { "purp", "p", "ur", "le", "purpl" }, "purple");
            Console.WriteLine($"Num of ways to construct purple is: " + numOfWays);

            Console.ReadLine(); 
        }
        private static int CountConstruct(string[] wordbank, string target, Dictionary<string, int> memo = null)
        {
            memo ??= new Dictionary<string, int>();
            if (memo.ContainsKey(target)) return memo[target];
            if (target == "") return 1;

            int totalCount = 0;
            foreach (var word in wordbank)
            {
                if (target.IndexOf(word) == 0)
                {
                    var suffix = target.Substring(word.Length);
                    var numOfWays = CountConstruct(wordbank, suffix, memo);
                    totalCount += numOfWays;
                    
                }
            }
            memo.Add(target, totalCount);
            return memo[target];
        }
    }
}