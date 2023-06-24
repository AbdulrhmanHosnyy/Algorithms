namespace ParentsGift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int w = 40;
            //int w = 7;
            Tuple<int, float>[] items = new Tuple<int, float>[]
            {
                Tuple.Create(30, 10.0f),
                Tuple.Create(10, 50.0f),
                Tuple.Create(20, 20.0f),
                Tuple.Create(40, 80.0f),
                Tuple.Create(25, 200.0f),
                Tuple.Create(50, 150.0f),

                //Tuple.Create(1, 10.0f),
                //Tuple.Create(25, 50.0f),
                //Tuple.Create(4, 20.0f),
                //Tuple.Create(50, 15.0f),
                //Tuple.Create(40, 80.0f),
                //Tuple.Create(25, 100.0f),
            };

            Array.Sort(items, CompareBySecondElementDescending);

            float maxProfit = 0.0f;
            int i = 0;
            while(w > 0)
            {
                if (items[i].Item1 <= w)
                {
                    maxProfit += items[i].Item2;
                    w -= items[i].Item1;
                }
                else
                {
                    maxProfit += w * (items[i].Item2 / items[i].Item1);
                    w -= w;
                }
                i++;
            }
            Console.WriteLine("Max profit: " + maxProfit);

            Console.ReadLine();
        }
        public static int CompareBySecondElementDescending(Tuple<int, float> x, Tuple<int, float> y)
        {
            return (y.Item2 / y.Item1).CompareTo(x.Item2 / x.Item1);
        }
    }
}