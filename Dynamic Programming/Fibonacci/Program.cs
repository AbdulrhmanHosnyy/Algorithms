namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 1, y = 1;
            Console.WriteLine("Enter n value: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i < n; i++)
            {
                if (i % 2 == 0) x += y;
                else y += x;
            }
            Console.WriteLine(x + y);
        }
    }
}