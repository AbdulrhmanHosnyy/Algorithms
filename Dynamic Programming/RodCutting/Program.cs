namespace RodCutting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int n = 10;
            //int[] cutPrice = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            int n = 8;
            int[] cutPrice = { 0, 1, 5, 8, 9, 10, 17, 17, 20 };

            int[] path = new int[n + 1];

            Console.WriteLine("Memo: " + CRMemo(n, cutPrice, path));
            Console.WriteLine("Construction: ");
            PrintCR(n, path);

            Console.WriteLine("Tabu: " + CRTabu(n, cutPrice, path));
            Console.WriteLine("Construction: ");
            PrintCR(n, path);

            Console.ReadLine();
        }
        static int CRMemo(int n, int[] cutPrice, int[] path, Dictionary<int, int> memo = null)
        {
            memo ??= new Dictionary<int, int>();
            if (memo.ContainsKey(n)) return memo[n];
            if (n == 0) return 0;
            int maxi = 0;
            int b = -1;
            for (int i = 1; i <= n; i++)
            {
                int tmp = CRMemo(n - i, cutPrice, path) + cutPrice[i];
                if (tmp > maxi)
                {
                    maxi = tmp;
                    b = i;
                }
            }
            path[n] = b;
            memo.Add(n, maxi);
            return maxi;
        }
        static int CRTabu(int n, int[] cutPrice, int[] path)
        {
            int[] Result = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                if (i == 0) Result[i] = 0;
                else
                {
                    int maxi = 0;
                    int b = -1;
                    for (int j = 1; j <= i; j++)
                    {
                        if(Result[i - j] + cutPrice[j] > maxi)
                        {
                            b = j;
                            maxi = Result[i - j] + cutPrice[j];
                        }
                    }
                    Result[i] = maxi;
                    path[i] = b;
                    
                }
            }
            return Result[n];
        }

        static void PrintCR(int n, int[] path)
        {
            if (n == 0) return;
            PrintCR(n - path[n], path);
            Console.WriteLine("Cut With Len: " + path[n]);
        }
    }
}