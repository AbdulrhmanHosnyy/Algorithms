namespace UnimodalSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Unimodal search program :D");
            Console.WriteLine("-----------------------------------------------\n");

            Console.WriteLine("Enter number of elements: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());
            int[] arrOfElements = new int[numberOfElements];

            Console.WriteLine("Enter the elements in Unimodal sequence please: ");
            for (int i = 0; i < numberOfElements; i++)
            {
                arrOfElements[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Array before Unimodal search: ");
            Print(arrOfElements);
            Console.WriteLine("Max element in the array is:");
            Console.WriteLine(UnimodalSearch(arrOfElements, 0, numberOfElements - 1));

        }

        private static int UnimodalSearch(int[] arrOfElements, int low, int high)
        {
            int mid = low + (high - low) / 2;
            if (arrOfElements[mid] > arrOfElements[mid - 1] && arrOfElements[mid] > arrOfElements[mid + 1])
                return arrOfElements[mid];
            if (arrOfElements[mid] > arrOfElements[mid - 1])
                return UnimodalSearch(arrOfElements, mid + 1, high);
            else
                return UnimodalSearch(arrOfElements, low, mid - 1);
        }

        static void Print(int[] arrOfElements)
        {
            foreach (var item in arrOfElements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}