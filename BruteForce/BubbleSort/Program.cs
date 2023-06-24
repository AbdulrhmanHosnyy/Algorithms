namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to bubble sort algorithm program :D");
            Console.WriteLine("-----------------------------------------------\n");

            Console.WriteLine("Enter number of elements you need to sort: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());
            int[] arrOfElements = new int[numberOfElements];

            Console.WriteLine("Enter the elements please: ");
            for (int i = 0; i < numberOfElements; i++)
            {
                arrOfElements[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Array before bubble sort algorithm: ");
            Print(arrOfElements);
            Console.WriteLine("Array after bubble sort algorithm: ");
            BubbleSort(arrOfElements, numberOfElements);
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
        static void BubbleSort(int[] arrOfElements, int numberOfElements)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < numberOfElements; i++)
                {
                    if (arrOfElements[i] < arrOfElements[i - 1])
                    {
                        int tmp = arrOfElements[i];
                        arrOfElements[i] = arrOfElements[i - 1];
                        arrOfElements[i - 1] = tmp;
                        swapped = true;
                    }
                }
                numberOfElements--;
            } while (swapped);
        }
    }
}