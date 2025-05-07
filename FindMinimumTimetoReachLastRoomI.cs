namespace LeetCode.FindMinimumTimetoReachLastRoomI;

public class Solution
{
    private const int INF = 0x3f3f3f3f;

    private class State : IComparable<State>
    {
        public int x;
        public int y;
        public int dis;

        public State(int x, int y, int dis)
        {
            this.x = x;
            this.y = y;
            this.dis = dis;
        }

        public int CompareTo(State other)
        {
            return this.dis.CompareTo(other.dis);
        }
    }

    public int MinTimeToReach(int[][] moveTime)
    {
        int n = moveTime.Length;
        int m = moveTime[0].Length;
        int[,] d = new int[n, m];
        bool[,] v = new bool[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                d[i, j] = INF;
            }
        }

        int[][] dirs = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 },
                                     new int[] { 0, 1 }, new int[] { 0, -1 } };

        d[0, 0] = 0;
        var pq = new PriorityQueue<State, int>();
        pq.Enqueue(new State(0, 0, 0), 0);

        while (pq.Count > 0)
        {
            State s = pq.Dequeue();
            if (v[s.x, s.y])
            {
                continue;
            }
            v[s.x, s.y] = true;
            foreach (var dir in dirs)
            {
                int nx = s.x + dir[0];
                int ny = s.y + dir[1];
                if (nx < 0 || nx >= n || ny < 0 || ny >= m)
                {
                    continue;
                }
                int dist = Math.Max(d[s.x, s.y], moveTime[nx][ny]) + 1;
                if (d[nx, ny] > dist)
                {
                    d[nx, ny] = dist;
                    pq.Enqueue(new State(nx, ny, dist), dist);
                }
            }
        }

        return d[n - 1, m - 1];
    }
}