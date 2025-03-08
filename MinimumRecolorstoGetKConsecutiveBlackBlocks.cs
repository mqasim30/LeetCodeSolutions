namespace LeetCode.MinimumRecolorstoGetKConsecutiveBlackBlocks;

public class Solution
{
    public int MinimumRecolors(string blocks, int k)
    {
        int _min = int.MaxValue;
        int counter;
        for (int i = 0; i < blocks.Length; ++i)
        {
            counter = 0;
            if (k + i <= blocks.Length)
            {
                for (int j = i; j < k + i; ++j)
                {
                    if (blocks[j] == 'W')
                        ++counter;
                }
                _min = Math.Min(_min, counter);
            }
        }
        return _min;
    }
}