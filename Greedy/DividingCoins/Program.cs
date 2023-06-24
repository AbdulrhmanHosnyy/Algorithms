namespace DividingCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10; 
            int[] coins = new int[10] { 2, 5, 7, 4, 2, 6, 9, 8, 10, 3 };
            Array.Sort(coins, (x, y) => y.CompareTo(x));


            double sum = coins.Sum() / 2.0;

            int count = 0;

            while(sum > 0)
            {
                sum -= coins[count];
                count++;
            }
            Console.WriteLine("Min number of coins is: " + count);
            Console.ReadLine();
        }
    }
}