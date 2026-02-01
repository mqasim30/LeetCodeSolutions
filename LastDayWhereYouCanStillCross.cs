namespace LeetCode.LastDayWhereYouCanStillCross;

public class Solution
{
    public int LatestDayToCross(int row, int col, int[][] cells)
    {
        int n = row * col;
        int top = n, bottom = n + 1;
        DSU dsu = new DSU(n + 2);

        bool[,] land = new bool[row, col];
        int[][] dirs = new int[][] {
            new int[]{1,0}, new int[]{-1,0}, new int[]{0,1}, new int[]{0,-1}
        };

        for (int day = cells.Length - 1; day >= 0; day--)
        {
            int r = cells[day][0] - 1;
            int c = cells[day][1] - 1;
            land[r, c] = true;
            int id = r * col + c;

            foreach (var d in dirs)
            {
                int nr = r + d[0], nc = c + d[1];
                if (nr >= 0 && nr < row && nc >= 0 && nc < col && land[nr, nc])
                {
                    dsu.Union(id, nr * col + nc);
                }
            }

            if (r == 0) dsu.Union(id, top);
            if (r == row - 1) dsu.Union(id, bottom);

            if (dsu.Find(top) == dsu.Find(bottom))
            {
                return day;
            }
        }
        return -1;
    }
}

public class DSU
{
    private int[] parent;
    private int[] rank;

    public DSU(int n)
    {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;
    }

    public int Find(int x)
    {
        if (parent[x] != x) parent[x] = Find(parent[x]);
        return parent[x];
    }

    public void Union(int x, int y)
    {
        int rx = Find(x), ry = Find(y);
        if (rx == ry) return;
        if (rank[rx] < rank[ry])
        {
            parent[rx] = ry;
        }
        else if (rank[rx] > rank[ry])
        {
            parent[ry] = rx;
        }
        else
        {
            parent[ry] = rx;
            rank[rx]++;
        }
    }
}