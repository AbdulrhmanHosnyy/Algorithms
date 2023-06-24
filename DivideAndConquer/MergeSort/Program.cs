namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Merge sort algorithm program :D");
            Console.WriteLine("-----------------------------------------------\n");

            Console.WriteLine("Enter number of elements you need to sort: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());
            int[] arrOfElements = new int[numberOfElements];

            Console.WriteLine("Enter the elements please: ");
            for (int i = 0; i < numberOfElements; i++)
            {
                arrOfElements[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            Console.WriteLine("Array before Merge sort algorithm: ");
            Print(arrOfElements);
            Console.WriteLine("Array after Merge sort algorithm: ");
            MergeSort(arrOfElements, 0,  numberOfElements - 1);
            Print(arrOfElements);


        }
        static void Print(int[] arrOfElements)
        {
            foreach (var item in arrOfElements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void MergeSort(int[] elements, int start, int end)
        {
            if(start < end)
            {
                int middle = (start + end) / 2;
                MergeSort(elements, start, middle);
                MergeSort(elements, middle + 1, end);
                Merge(elements, start, end, middle);
            }
        }
        static void Merge(int[] elements, int start,int end, int middle)
        {
            int n1 = middle - start + 1;
            int n2 = end - middle;
            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];

            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;
            for (int o = 0; o < n1; o++)
            {
                L[o] = elements[start + o];
            }
            for (int o = 0; o < n2; o++)
            {
                R[o] = elements[middle + 1 + o];
            }

            int i = 0, j = 0, k = start;
            while (k <= end)
            {
                if (L[i] <= R[j])
                {
                    elements[k] = L[i];
                    i++;
                }
                else
                {
                    elements[k] = R[j];
                    j++;
                }
                k++;
            }
        }
    }
}