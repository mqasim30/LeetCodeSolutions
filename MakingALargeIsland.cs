namespace LeetCode.MakingALargeIsland;
public class Solution
{

    private readonly int[][] _directions = [
        [-1, 0], [0, 1], [1, 0], [0, -1]
    ];

    public int LargestIsland(int[][] grid)
    {
        int n = grid.Length;
        UnionFind uf = new(n * n);

        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                if (grid[x][y] == 1)
                {
                    int index = n * x + y;
                    foreach (int[] dir in _directions)
                    {
                        int newX = dir[0] + x;
                        int newY = dir[1] + y;
                        int newIndex = n * newX + newY;

                        if (IsValid(grid, newX, newY, n))
                        {
                            uf.Union(index, newIndex);
                        }
                    }
                }
            }
        }

        int largestIsland = 0;
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                if (grid[x][y] == 0)
                {
                    HashSet<int> components = new();
                    foreach (int[] dir in _directions)
                    {
                        int newX = dir[0] + x;
                        int newY = dir[1] + y;
                        int newIndex = n * newX + newY;

                        if (IsValid(grid, newX, newY, n))
                        {
                            components.Add(uf.Find(newIndex));
                        }
                    }

                    int islandSize = 0;
                    foreach (int v in components)
                    {
                        islandSize += uf.GetGroupSize(v);
                    }
                    largestIsland = Math.Max(largestIsland, islandSize + 1);
                }
            }
        }
        return largestIsland == 0 ? n * n : largestIsland;
    }

    private bool IsValid(int[][] grid, int x, int y, int n)
    {
        return x >= 0 && x < n && y >= 0 && y < n && grid[x][y] == 1;
    }
}

public class UnionFind
{
    private readonly int[] _parent;
    private readonly int[] _rank;
    private readonly int[] _size;

    public UnionFind(int n)
    {
        _parent = new int[n];
        _rank = new int[n];
        _size = new int[n];

        for (int i = 0; i < n; i++)
        {
            _parent[i] = i;
            _rank[i] = 1;
            _size[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (x != _parent[x])
        {
            _parent[x] = Find(_parent[x]);
        }
        return _parent[x];
    }

    public void Union(int a, int b)
    {
        int x = Find(a);
        int y = Find(b);
        if (x != y)
        {
            if (_rank[x] > _rank[y])
            {
                _parent[y] = x;
                _size[x] += _size[y];
            }
            else if (_rank[x] < _rank[y])
            {
                _parent[x] = y;
                _size[y] += _size[x];
            }
            else
            {
                _parent[x] = y;
                _rank[y]++;
                _size[y] += _size[x];
            }
        }
    }

    public int GetGroupSize(int x)
        => _size[x];
}