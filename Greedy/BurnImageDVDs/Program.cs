namespace BurnImageDVDs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of images: ");
            int imagesCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter images ranks: ");
            int[]ranks = new int[imagesCount];
            for (int i = 0; i < imagesCount; i++)
            {
                ranks[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter size of each image in GB: ");
            float imageSize;
            float.TryParse(Console.ReadLine(), out imageSize);
            Console.WriteLine("Enter number of DVDs: ");
            int DVDsCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter capacity of each DVD");
            float DVDCapacity;
            float.TryParse(Console.ReadLine(), out DVDCapacity);

            int numOfImagesPerDVD = (int)Math.Floor(DVDCapacity / imageSize);

            Array.Sort(ranks, (x, y) => y.CompareTo(x));

            int [] totalRank = new int[DVDsCount];

            int k = 0;
            for (int i = 0; i < DVDsCount; i++)
            {
                for (int j = 0; j < numOfImagesPerDVD; j++)
                {
                    totalRank[i] += ranks[k];
                    k++;
                }
                Console.WriteLine("DVD number " + (i + 1) + " with total rank: " + totalRank[i]);
            }

        }
    }
}