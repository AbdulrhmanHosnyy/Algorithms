using System.Collections.Generic;

namespace FCISActivities
{
    internal class Program
    {
        struct activity
        {
            public int start;
            public int end;

            public override string ToString()
            {
                return $"Start: {start}  End: {end}";
            }
        }
        static void Main(string[] args)
        {
            activity[] activities =
            {
                new activity
                {
                    start = 1,
                    end = 5
                },
                new activity
                {
                    start = 7,
                    end = 10
                },
                new activity
                {
                    start = 4,
                    end = 8
                },
                //new activity
                //{
                //    start = 1,
                //    end = 4
                //},
                //new activity
                //{
                //    start = 2,
                //    end = 7
                //},
                //new activity
                //{
                //    start = 3,
                //    end = 6
                //},
                //new activity
                //{
                //    start = 5,
                //    end = 9
                //},
                //new activity
                //{
                //    start = 7,
                //    end = 9
                //}
            };
            PriorityQueue<activity, int> queue = new PriorityQueue<activity, int>();
            foreach (var activity in activities)
            {
                queue.Enqueue(activity, activity.start);
            }

            PriorityQueue<int, int> helper = new PriorityQueue<int, int>();
            while (queue.Count > 0)
            {
                if (helper.Count == 0)
                    helper.Enqueue(queue.Peek().end, queue.Peek().end);
                else
                {
                    activity tmp = queue.Peek();
                    if(tmp.start >= helper.Peek())
                    {
                        helper.Enqueue(tmp.end, tmp.end);
                        helper.Dequeue();
                    }
                    else
                    {
                        helper.Enqueue(tmp.end, tmp.end);
                    }
                }
                queue.Dequeue();
            }
            Console.WriteLine("Min number of halls is: " + helper.Count);

            Console.ReadLine();
        }
    }
}