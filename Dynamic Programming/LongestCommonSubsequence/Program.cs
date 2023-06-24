namespace LongestCommonSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string x = "$abdohosny", y = "$omarhosny";
            //string x = "$abcb", y = "$bdcab";
            int n = x.Length, m = y.Length; 
            int[,] R = new int[n, m];
            int[,] b = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 || j == 0) R[i, j] = 0;
                    else if (x[i] == y[j])
                    {
                        R[i, j] = R[i - 1, j - 1] + 1;
                        b[i, j] = 1;
                    }
                    else
                    {
                        if (R[i, j - 1] > R[i - 1, j])
                        {
                            R[i, j] = R[i, j - 1];
                            b[i, j] = 3;
                        }
                        else
                        {
                            R[i, j] = R[i - 1, j];
                            b[i, j] = 2;
                        }
                    }
                }
            }
            backtrack(b, x, n - 1, m - 1);
 
            Console.ReadLine();
        }
        public static void backtrack(int[,] b, string x, int i, int j)
        {
            if (i == 0 || j == 0) return;
            if (b[i, j] == 1) 
            {
                backtrack(b, x, i - 1, j - 1);
                Console.Write(x[i]);
            }
            else if (b[i, j] == 2)
            {
                backtrack(b, x, i - 1, j);
            }
            else if (b[i, j] == 3)
            {
                backtrack(b, x, i, j - 1);
            }
        }
    }
}