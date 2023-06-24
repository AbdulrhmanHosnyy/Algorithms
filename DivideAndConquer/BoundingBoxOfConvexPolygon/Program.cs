namespace BoundingBoxOfConvexPolygon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Xs = new int[] { 0, 1, 3, 4, 3, 2, };
            int[] Ys = new int[] { 0, -3, -2, 0, 3, 5, };

            int minX = Xs[0];
            Console.WriteLine($"Min X is: {minX}");
            int maxX = MaxUnimodalSearch(Xs, 0, Xs.Length - 1);
            Console.WriteLine($"Max X is: {maxX}");
            int minY = MinUnimodalSearch(Ys, 0, Ys.Length - 1);
            Console.WriteLine($"Min Y is: {minY}");
            int maxY = MaxUnimodalSearch(Ys, 0, Ys.Length - 1);
            Console.WriteLine($"Max Y is: {maxY}");


            Console.ReadLine();
        }
        private static int MaxUnimodalSearch(int[] arrOfElements, int low, int high)
        {
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int left = (mid + arrOfElements.Length - 1) % arrOfElements.Length;
                int right = (mid + 1) % arrOfElements.Length;

                if ((arrOfElements[mid] > arrOfElements[left] && arrOfElements[mid] > arrOfElements[right]))
                    return arrOfElements[mid];

                if (arrOfElements[mid] > arrOfElements[left])
                    low = (mid + 1) % arrOfElements.Length;
                else
                    high = (mid - 1 + arrOfElements.Length) % arrOfElements.Length;
            }
            throw new Exception("Error finding max element");
        }
        private static int MinUnimodalSearch(int[] arrOfElements, int low, int high)
        {
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int left = (mid + arrOfElements.Length - 1) % arrOfElements.Length;
                int right = (mid + 1) % arrOfElements.Length;

                if ((arrOfElements[mid] < arrOfElements[left] && arrOfElements[mid] < arrOfElements[right]))
                    return arrOfElements[mid];

                if (arrOfElements[mid] < arrOfElements[left])
                    low = (mid + 1) % arrOfElements.Length;
                else
                    high = (mid - 1 + arrOfElements.Length) % arrOfElements.Length;
            }
            throw new Exception("Error finding min Y");

        }

    }
}