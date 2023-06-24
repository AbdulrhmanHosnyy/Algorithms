namespace CandyAndSugarRush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10, c = 1;
            //int n = 10, c = 5;
            int i = 1, answer = 0;
            while(true)
            {
                if(n - (i * c) >= 0)
                {
                    answer += c;
                    n -= (i * c);
                    i *= 2;
                }
                else
                {
                    answer += (int)Math.Ceiling((float)c / i);
                    break;
                }

            }
            Console.WriteLine(answer);

            Console.ReadLine();
        }
    }
}