using Problem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public struct Location
    {
        int x, y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
    }
    public static class DarkKnight
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given the dimention of the board and the current location of the DarkKnight, calculate the min number of moves to reach the given target or return -1 if can't be reach ed
        /// </summary>
        /// <param name="N">board dimension</param>
        /// <param name="src">current location of the DarkKnight</param>
        /// <param name="target">target location</param>
        /// <returns>min number of moves to reach the target OR -1 if can't reach the target</returns>
        public static int Play(int N, Location src, Location target)
        {
            //  Greedy Solution:
            //  ----------------

            //int tmp1 = Math.Abs(src.X - target.X);
            //int tmp2 = Math.Abs(src.Y - target.Y);
            //if (tmp1 % 2 == 0 && tmp2 % 4 == 0) return tmp1 + tmp2 % 4;
            //if (tmp1 % 2 != 0 && tmp2 % 2 == 0) return tmp1 + tmp2 % 2;
            //return -1;

            //  Graph Solution:
            //  ---------------
            if (src.X == target.X && src.Y == target.Y) return 0;
            if (!isValid(N, src.X, src.Y) || !isValid(N, target.X, target.Y)) return -1;
            int[] visited = new int[(N + 1) * (N + 1)];
            Queue<Location> queue = new Queue<Location>();
            Location[] moves = {
                new Location { X = 1, Y = 2 },
                new Location { X = 1, Y = -2 },
                new Location { X = -1, Y = 2 },
                new Location { X = -1, Y = -2 }
            };
            int srcIndex = (src.X - 1) * (N + 1) + src.Y;
            int targetIndex = (target.X - 1) * (N + 1) + target.Y;
            queue.Enqueue(src);
            visited[srcIndex] = 1;
            while (queue.Count > 0)
            {
                Location pair = queue.Dequeue();
                int pairIndex = (pair.X - 1) * (N + 1) + pair.Y;
                if (pairIndex == targetIndex) return visited[pairIndex] - 1;
                if (visited[pairIndex] >= visited[targetIndex] && visited[targetIndex] > 0) continue;
                for (int i = 0; i < 4; i++)
                {
                    int newX = pair.X + moves[i].X;
                    int newY = pair.Y + moves[i].Y;
                    if (isValid(N, newX, newY))
                    {
                        int newIndex = (newX - 1) * (N + 1) + newY;
                        if (visited[newIndex] == 0)
                        {
                            visited[newIndex] = visited[pairIndex] + 1;
                            queue.Enqueue(new Location { X = newX, Y = newY });
                        }
                    }
                }
            }
            return -1;
        }
        private static bool isValid(int N, int x, int y)
        {
            return x >= 1 && x <= N && y >= 1 && y <= N;
        }
        #endregion
    }
}

