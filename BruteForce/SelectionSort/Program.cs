namespace SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to selection sort algorithm program :D");
            Console.WriteLine("-----------------------------------------------\n");

            Console.WriteLine("Enter number of elements you need to sort: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());
            int[] arrOfElements = new int[numberOfElements];

            Console.WriteLine("Enter the elements please: ");
            for (int i = 0; i < numberOfElements; i++)
            {
                arrOfElements[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Array before selection sort algorithm: ");
            Print(arrOfElements);
            Console.WriteLine("Array after selection sort algorithm: ");
            SelectionSort(arrOfElements, numberOfElements);
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
        static void SelectionSort(int[] arrOfElements, int numberOfElements)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                int mini = i;
                for (int j = i + 1; j < numberOfElements; j++)
                {
                    if (arrOfElements[j] < arrOfElements[mini]) mini = j;
                }
                int tmp = arrOfElements[i];
                arrOfElements[i] = arrOfElements[mini];
                arrOfElements[mini] = tmp;

            }
        }
    }
}