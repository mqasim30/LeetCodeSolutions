namespace LeetCode.RegionsCutBySlashes;
public class Solution
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private int[] parent;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private int[] rank;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private int regionCount;

    public int RegionsBySlashes(string[] grid)
    {
        int gridSize = grid.Length;
        int points = gridSize + 1;
        InitializeUnionFind(points);

        ConnectBoundaryPoints(gridSize, points);
        ProcessGrid(grid, gridSize, points);

        return regionCount;
    }

    private void InitializeUnionFind(int points)
    {
        int totalPoints = points * points;
        parent = new int[totalPoints];
        rank = new int[totalPoints];

        for (int i = 0; i < totalPoints; i++)
        {
            parent[i] = i;
            rank[i] = 1;
        }
    }

    private void ConnectBoundaryPoints(int gridSize, int points)
    {
        for (int i = 0; i < points; i++)
        {
            for (int j = 0; j < points; j++)
            {
                if (IsBoundaryPoint(i, j, gridSize))
                {
                    int cellIndex = i * points + j;
                    Union(0, cellIndex);
                }
            }
        }
    }

    private bool IsBoundaryPoint(int row, int col, int gridSize)
    {
        return row == 0 || col == 0 || row == gridSize || col == gridSize;
    }

    private void ProcessGrid(string[] grid, int gridSize, int points)
    {
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                char slash = grid[row][col];
                if (slash == '\\')
                {
                    int topLeft = row * points + col;
                    int bottomRight = (row + 1) * points + (col + 1);
                    Union(topLeft, bottomRight);
                }
                else if (slash == '/')
                {
                    int bottomLeft = (row + 1) * points + col;
                    int topRight = row * points + (col + 1);
                    Union(bottomLeft, topRight);
                }
            }
        }
    }

    private void Union(int pointA, int pointB)
    {
        int rootA = Find(pointA);
        int rootB = Find(pointB);

        if (rootA == rootB)
        {
            regionCount++;
        }
        else
        {
            if (rank[rootA] > rank[rootB])
            {
                parent[rootB] = rootA;
            }
            else if (rank[rootA] < rank[rootB])
            {
                parent[rootA] = rootB;
            }
            else
            {
                parent[rootB] = rootA;
                rank[rootA]++;
            }
        }
    }

    private int Find(int point)
    {
        if (parent[point] == point) return point;
        parent[point] = Find(parent[point]);
        return parent[point];
    }
}
