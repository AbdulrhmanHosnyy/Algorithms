namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Quick sort algorithm program :D");
            Console.WriteLine("-----------------------------------------------\n");

            Console.WriteLine("Enter number of elements you need to sort: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());
            int[] arrOfElements = new int[numberOfElements];

            Console.WriteLine("Enter the elements please: ");
            for (int i = 0; i < numberOfElements; i++)
            {
                arrOfElements[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Array before Quick sort algorithm: ");
            Print(arrOfElements);
            Console.WriteLine("Array after Quick sort algorithm: ");
            QuickSort(arrOfElements, 0, numberOfElements - 1);
            Print(arrOfElements);
        }

        private static void QuickSort(int[] arrOfElements, int first, int last)
        {
            int splitPoint = first + 1;
            if (first < last)
            {
                splitPoint = Partition(arrOfElements, first, last);
                QuickSort(arrOfElements, first, splitPoint - 1);
                QuickSort(arrOfElements, splitPoint + 1, last);
            }

        }

        private static int Partition(int[] arrOfElements, int first, int last)
        {
            int pivot = arrOfElements[first];
            int i = first, j = last;

            while(true)
            {
                while (i <= j && arrOfElements[i] <= pivot) i++;
                while (j >= i && arrOfElements[j] >= pivot) j--;

                if (j < i) break;
                else
                {
                    int temp = arrOfElements[i];
                    arrOfElements[i] = arrOfElements[j];
                    arrOfElements[j] = temp;
                }
            }
            int temp2 = arrOfElements[first];
            arrOfElements[first] = arrOfElements[j];
            arrOfElements[j] = temp2;
            return j;
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