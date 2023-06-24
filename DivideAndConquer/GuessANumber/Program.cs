namespace GuessANumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets start a funny game :D");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Pick a number between 0 and 10000");
            Console.WriteLine("Answer these questions please with y or n:D");
            Console.WriteLine("The number you picked is ...... ...... ......");
            Console.WriteLine("THE NUMBER IS .... " + Guess(0, 10000));
        }

        private static int Guess(int low, int high)
        {
            if (low == high) return low;
            int mid = (low + high) / 2;
            Console.WriteLine("Is your number == " + mid + "?");
            char c = Convert.ToChar(Console.ReadLine());
            if (c == 'n')
            {
                Console.WriteLine("Is your number > " + mid + "?");
                char c2 = Convert.ToChar(Console.ReadLine());
                if (c2 == 'n') return Guess(low, mid - 1);
                else return Guess(mid + 1, high);
            }
            return mid;
        }
    }
}