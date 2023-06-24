namespace CanConstructV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Write a function that accepts target string and and array of strings
            //  The function should return a boolean indicating whether or not target can be constructed by concatenating 
            //  elements of the array
            //  you may reuse elements of the wordbank as many times as needed 

            if (CanConstruct(new string[] { "ab", "abc", "cd", "def", "abcd" }, "abcdef"))
                Console.WriteLine("YESSS");
            else Console.WriteLine("NOOO");
        }
        private static bool CanConstruct(string[] wordbank, string target)
        {
            bool[] table = new bool[target.Length + 1];
            table[0] = true;

            for (int i = 0; i <= target.Length; i++)
            {
                if (table[i])
                {
                    foreach (var word in wordbank)
                    {
                        if(target.Substring(i, i + word.Length) == word)
                        {
                            table[i +  word.Length] = true;
                        }
                    }
                }
            }
            return table[table.Length];

        }
    }
}