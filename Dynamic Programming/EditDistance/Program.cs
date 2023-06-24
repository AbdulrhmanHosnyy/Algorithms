namespace EditDistance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string x = "cat", y = "hate";
            //string x = "ABCDEG", y = "BCDEF";
            string x = "AABCDE", y = "BCDEF";

            int n = x.Length, m = y.Length;

            int [,] dp = new int [n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0) dp[i, j] = j;
                    else if (j == 0) dp[i, j] = i;

                    else if (x[i - 1] == y[j - 1]) dp[i, j] = dp[i - 1, j - 1];

                    else dp[i, j] = 1 + Math.Min(dp[i, j - 1], Math.Min(dp[i - 1, j], dp[i - 1, j - 1]));
                }
            }
            Console.WriteLine("Min number of edits is: " + dp[n, m]);

            Console.ReadLine();
        }
    }
}