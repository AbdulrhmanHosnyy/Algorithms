namespace AssemblyLineScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Number of Stages
            const int n = 6;

            // Time for stage j on line i
            int[,] a = new int[2, n]    
            {
                {7, 9, 3, 4, 8, 4 },
                {8, 5, 6, 4, 5, 7 }
            };

            // Entrance time for line i
            int[] e = new int[2] { 2, 4 };

            // Exit time for line i
            int[] x = new int[2] { 3, 2 };

            // Time to transfer from line i at stage j to next stage on the other line
            int[,] t = new int[2, n - 1]
            {
                {2, 3, 1, 3, 4 },
                {2, 1, 2, 2, 1 }
            };

            int[,] arr = new int[n, 2];
            int[,] p = new int[n, 2];

            arr[0, 0] = a[0, 0] + e[0];
            arr[0, 1] = a[1, 0] + e[1];
            p[0, 0] = 0;
            p[0, 1] = 1;
            for( int i = 1; i < n; i++ )
            {
                for( int j = 0; j < 2; j++ )
                {
                    int r1 = 0, r2 = 0;
                    if(j == 0)
                    {
                        r1 = arr[i - 1, 0] + a[0, i];
                        r2 = arr[i - 1, 1] + a[0, i] + t[1, i - 1];
                    }
                    else
                    {
                        r1 = arr[i - 1, 1] + a[1, i];
                        r2 = arr[i - 1, 0] + a[1, i] + t[0, i - 1];
                    }
                    arr[i, j] = Math.Min(r1, r2);
                    if (r1 < r2) p[i, j] = j;
                    else p[i, j] = (j == 0) ? 1 : 0;
                }
            }
     
            int timeline1 = arr[n - 1, 0] + x[0];
            int timeline2 = arr[n - 1, 1] + x[1];

            int exitline;
            if (timeline1 < timeline2) exitline = 0;
            else exitline = 1;

            if (exitline == 0)
            {
                Console.WriteLine("Min total time: " + timeline1);
                Console.WriteLine("-------------------");
                printPath(p, n - 1, 0);
            }
            else
            {
                Console.WriteLine("Min total time: " + timeline1);
                Console.WriteLine("-------------------");
                printPath(p, n - 1, 1);
            }

            Console.ReadLine();

        }

        public static void printPath(int[,]p , int i, int j)
        {
            if(i == 0) Console.WriteLine("Stage: "  + (i + 1) + " at line: " + (j + 1));
            else
            {
                printPath(p, i - 1, p[i, j]);
                Console.WriteLine("Stage: " + (i + 1) + " at line: " + (j + 1));
            }
        }
    }
}