namespace LeetCode.FindMinimumTimetoReachLastRoomII;

public class Solution
{
    private const int INF = 0x3f3f3f3f;

    class State : IComparable<State>
    {
        public int x, y, dis;
        public State(int x, int y, int dis)
        {
            this.x = x;
            this.y = y;
            this.dis = dis;
        }
        public int CompareTo(State other)
        {
            return dis.CompareTo(other.dis);
        }
    }

    public int MinTimeToReach(int[][] moveTime)
    {
        int n = moveTime.Length, m = moveTime[0].Length;
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
        var q = new PriorityQueue<State, int>();
        q.Enqueue(new State(0, 0, 0), 0);

        while (q.Count > 0)
        {
            State s = q.Dequeue();
            if (v[s.x, s.y])
            {
                continue;
            }
            if (s.x == n - 1 && s.y == m - 1)
            {
                break;
            }
            v[s.x, s.y] = true;

            foreach (var dir in dirs)
            {
                int nx = s.x + dir[0];
                int ny = s.y + dir[1];
                if (nx < 0 || nx >= n || ny < 0 || ny >= m)
                    continue;
                int dist = Math.Max(d[s.x, s.y], moveTime[nx][ny]) +
                           (s.x + s.y) % 2 + 1;
                if (d[nx, ny] > dist)
                {
                    d[nx, ny] = dist;
                    q.Enqueue(new State(nx, ny, dist), dist);
                }
            }
        }
        return d[n - 1, m - 1];
    }
}