namespace ZeroOneKnapsack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5, w = 15;
            int [] weights = new int[] { 0, 1, 1, 2, 4, 12 };
            int[] pounds = new int[] { 0, 1, 2, 2, 10, 4 };
            int[,] path = new int[w + 1, n + 1];
            Console.WriteLine(knapsack(n, w, weights, pounds, path));
            for (int i = 0; i <= w; i++)
            {
                for (int j = 0; j <= n; j++)
                    Console.Write(path[i, j] + " ");
                Console.WriteLine();
            }
            printKnapsack(path, weights, w, n);
            Console.ReadLine();
        }
        static int knapsack(int n, int w, int[] weights, int[] pounds, int[,] path, Dictionary<string, int> memo = null)
        {
            memo??= new Dictionary<string, int>();
            string s = w + "," + n;
            if (memo.ContainsKey(s)) return memo[s];
            if (w == 0 || n == 0)
            {
                memo.Add(s, 0);
                return memo[s];
            }
            int helper;
            if (weights[n] > w)
            {
                path[w, n] = 1;
                helper = knapsack(n - 1, w, weights, pounds, path);
            }
            else
            {
                int tmp1 = knapsack(n - 1, w - weights[n], weights, pounds, path) + pounds[n];
                int tmp2 = knapsack(n - 1, w, weights, pounds, path);
                if(tmp1 > tmp2)
                {
                    helper = tmp1;
                    path[w, n] = 2;
                }
                else
                {
                    helper = tmp2;
                    path[w, n] = 1;
                }
            }                         
            memo[s] = helper;
            return memo[s];
        }

        static void printKnapsack(int[,] path, int[] weights, int i , int j)
        {
            if(i == 0 || j == 0) return;
            if (path[i, j] == 1)
            {
                printKnapsack(path, weights, i, j - 1);
            }
            else if (path[i, j] == 2)
            {
                Console.WriteLine("Item Number: " + j);
                printKnapsack(path, weights, i - weights[j], j - 1);
            }
        }
    }
}