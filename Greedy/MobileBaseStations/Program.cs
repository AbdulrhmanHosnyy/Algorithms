namespace MobileBaseStations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] houses = new int[] { 4, 5, 6, 8, 11, 13, 16, 19, 25, 31, 35 };
            //int[] houses = new int[] { 1, 10, 20, 30 };
            //int[] houses = new int[] { 5, 7, 8, 9, 11 };
            //int[] houses = new int[] { 2, 7, 10, 20, 21, 23, 24 };

            int helper = houses[0] + 4;
            int answer = 1;
            for (int i = 1; i < houses.Length; i++)
            {
                if (!(Math.Abs(houses[i] - helper) <= 4))
                {
                    helper = houses[i] + 4;
                    answer++;
                }
            }
            Console.WriteLine(answer);

            Console.ReadLine();
        }
    }
}