namespace CountConstructV2
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
        private static int CountConstruct(string[] wordbank, string target)
        {
            int[] table = new int[target.Length + 1];
            table[0] = 1;

            for (int i = 0; i <= target.Length; i++)
            {

                foreach (var word in wordbank)
                {
                    if (target.Substring(i, i + word.Length) == word)
                    {
                        table[i + word.Length] += table[i];
                    }
                }

            }
            return table[table.Length];
        }
    }
}