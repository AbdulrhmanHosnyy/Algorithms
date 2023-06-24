namespace GridTravelerV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(gridTraveler(3, 3));

            Console.ReadLine();
        }
        static int gridTraveler(int m, int n)
        {
            int[,] arr = new int[m + 1, n + 1];
            arr[1, 1] = 1;
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    var current = arr[i, j];
                    if(j + 1 <= n)
                        arr[i, j + 1] += current;
                    if(i + 1 <= m)
                        arr[i + 1, j] += current;
                }
            }
            return arr[n, m];
        }
    }
}