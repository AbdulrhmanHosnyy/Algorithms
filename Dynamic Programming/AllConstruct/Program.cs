namespace AllConstruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Write a function that accepts target string and and array of strings
            //  The function should return all of the ways indicating whether or not target can be constructed by concatenating 
            //  elements of the array
            //  you may reuse elements of the wordbank as many times as needed 


            var numOfWays = AllConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" });
            foreach (var item in numOfWays)
            {
                foreach (var item1 in item)
                {
                    Console.Write(item1);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
        private static List<string> AllConstruct(string target, string[] wordBank, Dictionary<string, List<string>> memo = null)
        {
            memo ??= new Dictionary<string, List<string>>();
            if (memo.ContainsKey(target))
            {
                return memo[target];
            }
            if (target == "")
            {
                return new List<string>() { "" };
            }

            List<string> result = new List<string>();

            foreach (string word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    string suffix = target.Substring(word.Length);
                    List<string> suffixWays = AllConstruct(suffix, wordBank, memo);
                    List<string> targetWays = suffixWays.Select(s => word + (string.IsNullOrEmpty(s) ? "" : " " + s)).ToList();
                    result.AddRange(targetWays);
                }
            }

            memo[target] = result;
            return result;
        }
        
    }
}