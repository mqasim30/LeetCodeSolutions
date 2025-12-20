namespace LeetCode.DeleteColumnstoMakeSorted;

public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        var row = strs.Length;
        var col = strs[0].Length;

        var count = 0;
        for (int i = 0; i < col; i++)
        {
            var current_ch = strs[0][i];
            for (int j = 1; j < row; j++)
            {
                var ch = strs[j][i];
                if (ch < current_ch)
                {
                    count++;
                    break;
                }
                current_ch = ch;
            }
        }

        return count;
    }
}