namespace CanConstruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Write a function that accepts target string and and array of strings
            //  The function should return a boolean indicating whether or not target can be constructed by concatenating 
            //  elements of the array
            //  you may reuse elements of the wordbank as many times as needed 

            if (CanConstruct(new string[] {"ab", "abc", "cd", "def", "abcd"}, "abcdef"))
                Console.WriteLine("YESSS");
            else Console.WriteLine("NOOO");
        }

        private static bool CanConstruct(string[] wordbank, string target, Dictionary<string, bool> memo = null)
        {
            memo ??= new Dictionary<string, bool>();
            if(memo.ContainsKey(target)) return memo[target];
            if (target == "") return true;
            foreach (var word in wordbank)
            {
                if(target.IndexOf(word) == 0)
                {
                    var suffix = target.Substring(word.Length);
                    if(CanConstruct(wordbank, suffix, memo))
                    {
                        memo.Add(target, true);
                        return memo[target];
                    }
                }
            }
            memo.Add(target, false);
            return memo[target];
        }
    }
}