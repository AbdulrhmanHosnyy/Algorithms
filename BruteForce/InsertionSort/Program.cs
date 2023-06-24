namespace InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to insertion sort algorithm program :D");
            Console.WriteLine("-----------------------------------------------\n");

            Console.WriteLine("Enter number of elements you need to sort: ");
            int NumberOfElements = Convert.ToInt32(Console.ReadLine());
            int[] arrOfElements = new int[NumberOfElements];

            Console.WriteLine("Enter the elements please: ");
            for (int i = 0; i < NumberOfElements; i++)
            {
                arrOfElements[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Array before insertion sort algorithm: ");
            Print(arrOfElements);
            Console.WriteLine("Array after insertion sort algorithm: ");
            InsertionSort(arrOfElements);
            Print(arrOfElements);

            Console.ReadLine();
        }
        static void Print(int[] arrOfElements)
        {
            foreach (var item in arrOfElements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void InsertionSort(int[] arrOfElements)
        {
            for (int i = 1; i < arrOfElements.Length; i++)
            {
                int key = arrOfElements[i];
                int j = i - 1;
                while (j >= 0 && arrOfElements[j] >= key)
                {
                    arrOfElements[j + 1] = arrOfElements[j];
                    j--;
                }
                arrOfElements[j + 1] = key;
            }
        }
    }
}