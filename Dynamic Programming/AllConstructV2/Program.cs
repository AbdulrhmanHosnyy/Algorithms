namespace AllConstructV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numOfWays = AllConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" });
            foreach (var item in numOfWays)
            {
                foreach (var item1 in item)
                {
                    Console.Write(item1 + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
        private static List<List<string>> AllConstruct(string target, string[] wordBank)
        {
            List<List<string>>[] table = new List<List<string>>[target.Length + 1];
            for (int i = 0; i <= target.Length; i++)
            {
                table[i] = new List<List<string>>();
            }
            table[0].Add(new List<string>());

            for (int i = 0; i <= target.Length; i++)
            {
                foreach (string word in wordBank)
                {
                    if (i + word.Length <= target.Length && target.Substring(i, word.Length) == word)
                    {
                        List<List<string>> newCombinations = new List<List<string>>();
                        foreach (List<string> subArray in table[i])
                        {
                            List<string> newSubArray = new List<string>(subArray);
                            newSubArray.Add(word);
                            newCombinations.Add(newSubArray);
                        }
                        table[i + word.Length].AddRange(newCombinations);
                    }
                }
            }

            return table[target.Length];
        }
    }
}