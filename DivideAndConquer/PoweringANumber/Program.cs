namespace PoweringANumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the SMART POWERING :D");
            Console.WriteLine("Please enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the Power: ");
            int power = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(number + " to the power " + power + " Equals: ");
            Console.WriteLine(Power(number, power));
            Console.ReadLine();
        }

        private static int Power(int number, int power)
        {
            if (power == 1)
                return number;
            if (power == 0) 
                return 1;
            int helper = power / 2;
            int p = Power(number, helper);
            if (power % 2 != 0) return p * p * number;
            else return p * p;
        }
    }
}