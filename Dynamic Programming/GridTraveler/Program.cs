namespace GridTraveler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Say that you're a traveler on a 2D grid. you begin in the top-left corner and your goal is to travel to the 
            //  bottom-right corner. you may only move down or right
            //  in how many ways can you travel to the goal on a grid with dimensions m * n?
            Console.WriteLine(gridTraveler(18, 18));

            Console.ReadLine();

        }
        static long gridTraveler(int n, int m, Dictionary<Tuple<int, int>, long> memo = null)
        {
            Tuple<int, int> key = new Tuple<int, int>(n, m);
            memo??= new Dictionary<Tuple<int, int>, long>();
            if (memo.ContainsKey(key)) return memo[key];
            if (n == 1 && m == 1) return 1;
            if(n == 0 || m == 0) return 0;  
            memo[key] = gridTraveler(n - 1, m, memo) + gridTraveler(n, m - 1, memo);
            return memo[key];
        }
    }
}   