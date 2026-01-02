namespace LeetCode.NRepeatedElementinSize2NArray;

public class Solution
{
    public int RepeatedNTimes(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int num in nums)
        {
            if (seen.Contains(num))
            {
                return num;
            }
            seen.Add(num);
        }
        return -1;
    }
}