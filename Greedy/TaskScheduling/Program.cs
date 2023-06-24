namespace TaskScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] processTime = { 3, 5, 2, 7, 6, 8, 9, 4, }; // Process time for every task
            Array.Sort(processTime);
            int curTime = 0;
            double minAverageTime = 0;
            foreach (var item in processTime)
            {
                curTime += item;    // Finish time of every task
                minAverageTime += curTime;  // Cumulatively add the finish time
            }
            Console.WriteLine(minAverageTime / processTime.Length); // print the average of completion time
        }
    }
}