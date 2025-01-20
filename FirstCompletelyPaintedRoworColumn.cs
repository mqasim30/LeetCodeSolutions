namespace LeetCode.FirstCompletelyPaintedRoworColumn;

public class Solution
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        int rows = mat.Length, cols = mat[0].Length;
        HashSet<int>[] columnsSetArr = new HashSet<int>[cols];
        HashSet<int>[] rowsSetArr = new HashSet<int>[rows];
        Dictionary<int, int> numRowMap = new();
        Dictionary<int, int> numColMap = new();

        for (int i = 0; i < rows; i++)
        {
            rowsSetArr[i] = new HashSet<int>();
        }

        for (int i = 0; i < cols; i++)
        {
            columnsSetArr[i] = new HashSet<int>();
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                rowsSetArr[row].Add(mat[row][col]);
                columnsSetArr[col].Add(mat[row][col]);
                numRowMap.Add(mat[row][col], row);
                numColMap.Add(mat[row][col], col);
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            int row = numRowMap[arr[i]];
            int col = numColMap[arr[i]];
            rowsSetArr[row].Remove(arr[i]);
            columnsSetArr[col].Remove(arr[i]);

            if (rowsSetArr[row].Count == 0 || columnsSetArr[col].Count == 0)
            {
                return i;
            }
        }

        return -1;
    }
}