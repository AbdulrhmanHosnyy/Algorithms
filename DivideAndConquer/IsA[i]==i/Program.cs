namespace IsA_i___i
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HOLA -_-");
            Console.WriteLine("Enter number of array elements please: ");
            int numOfElements = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter array elements please: ");
            int[] elements = new int[numOfElements];
           for (int i = 0; i < numOfElements; i++) {
                elements[i] = Convert.ToInt32(Console.ReadLine());  
           }
            Console.WriteLine("Lets check if there is any element equlas its index!!");
            if(Checker(elements, 0, numOfElements - 1))
            {
                Console.WriteLine("WOW There is !!!");
            }
            else
                Console.WriteLine("Sadly no :(");
        }

        private static bool Checker(int[] elements, int low, int high)
        {
            if(low > high) return false;
            int mid = (low + high) / 2;
            if (elements[mid] == mid) return true;
            else if (elements[mid] > mid) return Checker(elements, low, mid - 1);   
            else return Checker(elements, mid + 1, high);
        }
    }
}