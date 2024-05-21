namespace LeetCode.FindTheSafestPathInAGrid
{
    public class Solution
    {
        private int[] roww = { 0, 0, -1, 1 };
        private int[] coll = { -1, 1, 0, 0 };

        private void Bfs(IList<IList<int>> grid, int[][] score, int n)
        {
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        score[i][j] = 0;
                        queue.Enqueue([i, j]);
                    }
                }
            }

            while (queue.Count > 0)
            {
                int[] t = queue.Dequeue();
                int x = t[0], y = t[1];
                int s = score[x][y];

                for (int i = 0; i < 4; i++)
                {
                    int newX = x + roww[i];
                    int newY = y + coll[i];

                    if (newX >= 0 && newX < n && newY >= 0 && newY < n && score[newX][newY] > 1 + s)
                    {
                        score[newX][newY] = 1 + s;
                        queue.Enqueue(new int[] { newX, newY });
                    }
                }
            }
        }

        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            int n = grid.Count;
            if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
            {
                return 0;
            }

            int[][] score = new int[n][];
            for (int i = 0; i < n; i++)
            {
                score[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    score[i][j] = int.MaxValue;
                    Console.WriteLine($"{i},{j} " + score[i][j]);
                }
            }
            Bfs(grid, score, n);
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"{i},{j} " + score[i][j]);
                }
            }
            bool[][] vis = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                vis[i] = new bool[n];
            }

            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => b - a));
            pq.Enqueue(new int[] { score[0][0], 0, 0 }, score[0][0]);

            while (pq.Count > 0)
            {
                int[] temp = pq.Dequeue();
                int safe = temp[0];
                int i = temp[1], j = temp[2];

                if (i == n - 1 && j == n - 1) return safe;
                vis[i][j] = true;

                for (int k = 0; k < 4; k++)
                {
                    int newX = i + roww[k];
                    int newY = j + coll[k];

                    if (newX >= 0 && newX < n && newY >= 0 && newY < n && !vis[newX][newY])
                    {
                        int s = Math.Min(safe, score[newX][newY]);
                        pq.Enqueue(new int[] { s, newX, newY }, s);
                        vis[newX][newY] = true;
                    }
                }
            }

            return -1;
        }
    }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         IList<IList<int>> grid = [[0, 0, 0, 1], [0, 0, 0, 0], [0, 0, 0, 0], [1, 0, 0, 0]];
    //         solution.MaximumSafenessFactor(grid);
    //     }
    // }
}