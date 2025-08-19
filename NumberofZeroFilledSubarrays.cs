namespace LeetCode.NumberofZeroFilledSubarrays;

public class Solution
{
    public long ZeroFilledSubarray(int[] nums)
    {
        long answer = 0;
        long count = 0;
        foreach (var item in nums)
        {
            if (item == 0)
            {
                ++count;
            }
            else
            {
                answer += count * (count + 1) / 2;
                count = 0;
            }
        }
        answer += count * (count + 1) / 2;
        return answer;
    }
}