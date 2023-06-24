namespace EvenOddChecking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Even Odd Checking program :D");
            Console.WriteLine("-----------------------------------------------\n");

            Console.WriteLine("Enter number of elements: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());
            int[] arrOfElements = new int[numberOfElements];

            Console.WriteLine("Enter the elements please: ");
            for (int i = 0; i < numberOfElements; i++)
            {
                arrOfElements[i] = Convert.ToInt32(Console.ReadLine());
            }

            if(EvenOddChecker(0, numberOfElements - 1, arrOfElements))
                Console.WriteLine("The array summation is Odd");
            else
                Console.WriteLine("The array summation is Even");
        }

        private static bool EvenOddChecker(int first, int last, int[] arrOfElements)
        {
            if(first == last)
            {
                if (arrOfElements[first] % 2 == 0) return false;
                return true;
            }
            int mid = (first + last) / 2;   
            bool a = EvenOddChecker(first, mid, arrOfElements);
            bool b = EvenOddChecker(mid + 1, last, arrOfElements);
            if (a == b) return false;
            return true;    
        }

    }
}