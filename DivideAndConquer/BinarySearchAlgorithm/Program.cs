using System.Collections.Specialized;

namespace BinarySearchAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
            int target = 7;
            if (BinarySearch(elements, target, 0, 10)) Console.WriteLine("Found :D"); 
            else Console.WriteLine("Not found :(");
        }
        static bool BinarySearch(int[] elements, int target, int start, int end)
        {
            if (start > end) return false;
            int middle = ((start + end) / 2);
            if (elements[middle] == target) return true;
            else if (elements[middle] > target) return BinarySearch(elements, target, start, middle - 1);
            else return BinarySearch(elements, target, middle + 1, end);
        }
    }
}