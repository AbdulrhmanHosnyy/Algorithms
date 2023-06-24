namespace FibonacciV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fib(6));
            Console.WriteLine(Fib(7));
            Console.WriteLine(Fib(8));
            Console.WriteLine(Fib(50));
            Console.ReadLine();
        }
        static long Fib(int n)
        {
            long [] arr = new long[n + 3];
            arr[1] = 1;
            for (int i = 0; i <= n; i++)
            {
                arr[i + 1] += arr[i];
                arr[i + 2] += arr[i];
            }
            return arr[n];
        }
    }
}