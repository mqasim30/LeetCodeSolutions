namespace LeetCode.PacificAtlanticWaterFlow;

public class Solution
{
    private bool[][] vis;
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        vis = new bool[heights.Length][];
        for (int i = 0; i < vis.Length; i++)
            vis[i] = new bool[heights[i].Length];

        List<IList<int>> lst = new();
        for (int i = 0; i < heights.Length; i++)
        {
            for (int j = 0; j < heights[i].Length; j++)
            {
                bool pacific = false;
                bool atlantic = false;
                bool f = DFS(i, j, heights, ref pacific, ref atlantic);
                if (f)
                {
                    List<int> pair = new();
                    pair.Add(i); pair.Add(j);
                    lst.Add(pair);
                }

                // reset the visited 
                for (int a = 0; a < vis.Length; a++)
                    for (int b = 0; b < vis[a].Length; b++)
                        vis[a][b] = false;
            }
        }
        return lst;
    }
    private int[] dx = { 1, -1, 0, 0 };
    private int[] dy = { 0, 0, 1, -1 };
    private bool DFS(int i, int j, int[][] heights, ref bool pacific, ref bool atlantic)
    {
        vis[i][j] = true;

        if (i == 0 || j == 0) pacific = true;
        if (i == heights.Length - 1 || j == heights[0].Length - 1) atlantic = true;

        bool flag = true;
        for (int dir = 0; dir < 4; dir++)
        {
            int newx = i + dx[dir];
            int newy = j + dy[dir];

            if (newx >= 0 && newy >= 0 && newx < heights.Length && newy < heights[0].Length && heights[i][j] >= heights[newx][newy] && !vis[newx][newy])
            {
                DFS(newx, newy, heights, ref pacific, ref atlantic);
            }
        }
        return pacific & atlantic;
    }
}