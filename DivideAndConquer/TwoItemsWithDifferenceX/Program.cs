namespace TwoItemsWithDifferenceX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome :D");
            Console.WriteLine("-----------");
            Console.WriteLine("Enter number of elements please: ");
            int numOfElements = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter array elements please: ");
            int [] elements = new int[numOfElements];
            for (int i = 0; i < numOfElements; i++) elements[i] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter difference value X: ");
            int x = Convert.ToInt32(Console.ReadLine());
            if (TwoItemsWithDifferenceX(elements, numOfElements - 1, x)) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }

        private static bool TwoItemsWithDifferenceX(int[] elements, int numOfelements, int x)
        {
            Array.Sort(elements);
            foreach (var element in elements)
            {
                int target = x + element;
                int found = BinarySearch(elements, 0, numOfelements, target);
                if(found != -1) return true;  
            }
            return false;
        }

        private static int BinarySearch(int[] elements, int low, int high, int target)
        {
            if (low > high) return -1;
            int mid = (low + high) / 2;
            if (elements[mid] == target) return mid;
            else if (elements[mid] > target) return BinarySearch(elements, low, mid - 1, target);
            else return BinarySearch(elements, mid + 1, high, target);
        }
    }
}